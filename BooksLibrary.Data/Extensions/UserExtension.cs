using System.Linq;
using BooksLibrary.Data.Repositories;
using BooksLibrary.Membership;

namespace BooksLibrary.Data.Extensions
{
    public static class UserExtensions
    {
        public static User GetSingleByUsername(this IEntityBaseRepository<User> userRepository, string username)
        {
            return userRepository.GetAll().FirstOrDefault(x => x.Username == username);
        }
    }
}
