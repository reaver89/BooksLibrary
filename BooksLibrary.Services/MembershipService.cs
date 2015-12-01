using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using BooksLibrary.Data;
using BooksLibrary.Data.Extensions;
using BooksLibrary.Data.Infrastructure;
using BooksLibrary.Data.Repositories;
using BooksLibrary.Membership;
using BooksLibrary.Services.Abstract;

namespace BooksLibrary.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IEntityBaseRepository<User> _userRepository;
        private readonly IEntityBaseRepository<Role> _roleRepository;
        private readonly IEntityBaseRepository<UserRole> _userRoleRepository;
        private readonly IEncryptionService _encryptionService;
        private readonly IUnitOfWork _unitOfWork;

        public MembershipService(IEntityBaseRepository<User> userRepository,
            IEntityBaseRepository<Role> roleRepository,
            IEntityBaseRepository<UserRole> userRoleRepository,
            IEncryptionService encryptionService,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _encryptionService = encryptionService;
            _unitOfWork = unitOfWork;
        }

        private void AddUserToRole(User user, int roleId)
        {
            var role = _roleRepository.GetSingle(roleId); if (role == null) throw new ApplicationException("Role doesn't exist.");
            var userRole = new UserRole() { RoleId = role.Id, UserId = user.Id }; _userRoleRepository.Add(userRole);
        }

        private bool IsPasswordValid(User user, string password) => string.Equals(_encryptionService.EncryptPassword(password, user.Salt), user.HashedPassword);

        private bool IsUserValid(User user, string password)
        {
            if (IsPasswordValid(user, password))
            {
                return !user.IsLocked;
            }
            return false;
        }

        public MembershipContext ValidateUser(string username, string password)
        {
            var membershipCtx = new MembershipContext();
            var user = _userRepository.GetSingleByUsername(username);
            if (user != null && IsUserValid(user, password))
            {
                var userRoles = GetUserRoles(user.Username);
                membershipCtx.User = user;
                var identity = new GenericIdentity(user.Username);
                membershipCtx.Principal = new GenericPrincipal(identity, userRoles.Select(x => x.Name).ToArray());
            }
            return membershipCtx;
        }

        public User CreateUser(string username, string email, string password, int[] roles)
        {
            var existingUser = _userRepository.GetSingleByUsername(username);
            if (existingUser != null)
            {
                throw new Exception("Username is already in use");
            }
            var passwordSalt = _encryptionService.CreateSalt();
            var user = new User()
            {
                Username = username,
                Salt = passwordSalt,
                Email = email,
                IsLocked = false,
                HashedPassword = _encryptionService.EncryptPassword(password, passwordSalt),
                DateCreated = DateTime.Now
            };

            _userRepository.Add(user);
            _unitOfWork.Commit();

            if (roles != null && roles.Length > 0)
            {
                foreach (var role in roles)
                {
                    AddUserToRole(user, role);
                }
            }
            _unitOfWork.Commit();
            return user;
        }

        public User GetUser(int userId)
        {
            return _userRepository.GetSingle(userId);
        }

        public List<Role> GetUserRoles(string username)
        {
            List<Role> result = new List<Role>();
            var existingUser = _userRepository.GetSingleByUsername(username);
            if (existingUser != null)
            {
                foreach (var userRole in existingUser.UserRoles)
                {
                    result.Add(userRole.Role);
                }
            }
            return result.Distinct().ToList();
        }
    }
}
