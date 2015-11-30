

using BooksLibrary.Membership;

namespace BooksLibrary.Data.Configuration
{
    public class RoleConfiguration:EntityBaseConfiguration<Role>
    {
        public RoleConfiguration()
        {
            Property(r => r.Name).IsRequired().HasMaxLength(50);
        }
    }
}
