
namespace BooksLibrary.Data.Configuration
{
    public class GenreConfiguration : EntityBaseConfiguration<Genre>
    {
        public GenreConfiguration()
        {
            Property(g => g.Id).HasColumnName("genre_id");
            Property(g => g.Name).IsRequired().HasMaxLength(200);
            Property(g => g.ParentGenreId).HasColumnName("parent_genre_id").IsOptional();
            HasMany(g => g.Books).WithMany(b => b.Genres).Map(cs =>
            {
                cs.MapLeftKey("book_id");
                cs.MapRightKey("genre_id");
                cs.ToTable("BOOK_GENRE");
            });
        }
    }
}
