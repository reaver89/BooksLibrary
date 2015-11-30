using BooksLibrary.Membership;

namespace BooksLibrary.Data.Configuration
{
    public class UserRoleConfiguration:EntityBaseConfiguration<UserRole>
    {
        public UserRoleConfiguration()
        {
            Property(ur => ur.Id).HasColumnName("user_role_id");
            Property(ur => ur.UserId).IsRequired().HasColumnName("user_id");
            Property(ur => ur.RoleId).IsRequired().HasColumnName("role_id");
        }
    }
}
