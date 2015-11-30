using BooksLibrary.Membership;

namespace BooksLibrary.Data.Configuration
{
    public class UserConfiguration:EntityBaseConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(u => u.Id).HasColumnName("user_id");
            Property(u => u.Username).IsRequired().HasMaxLength(100).HasColumnName("user_name");
            Property(u => u.Email).IsRequired().HasMaxLength(200);
            Property(u => u.HashedPassword).IsRequired().HasMaxLength(200).HasColumnName("hashed_password");
            Property(u => u.Salt).IsRequired().HasMaxLength(200);
            Property(u => u.IsLocked).IsRequired().HasColumnName("is_locked");
            Property(u => u.DateCreated).HasColumnName("date_created");
        }
    }
}
