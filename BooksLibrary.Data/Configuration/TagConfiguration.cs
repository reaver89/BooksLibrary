
namespace BooksLibrary.Data.Configuration
{
    public class TagConfiguration:EntityBaseConfiguration<Tag>
    {
        public TagConfiguration()
        {
            Property(t => t.Id).HasColumnName("tag_id");
            Property(t => t.Name).IsRequired().HasMaxLength(50);
            HasMany(g => g.Books).WithMany(b => b.Tags).Map(cs =>
            {
                cs.MapLeftKey("book_id");
                cs.MapRightKey("tag_id");
                cs.ToTable("BOOK_TAG");
            });
        }
    }
}
