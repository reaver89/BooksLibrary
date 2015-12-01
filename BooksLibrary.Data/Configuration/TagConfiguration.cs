
namespace BooksLibrary.Data.Configuration
{
    public class TagConfiguration:EntityBaseConfiguration<Tag>
    {
        public TagConfiguration()
        {
            Property(t => t.Id).HasColumnName("tag_id");
            Property(t => t.Name).IsRequired().HasMaxLength(50);
            HasMany(t => t.Books).WithMany(b => b.Tags).Map(cs =>
            {
                cs.MapLeftKey("tag_id");
                cs.MapRightKey("book_id");
                cs.ToTable("BOOK_TAG");
            });
        }
    }
}
