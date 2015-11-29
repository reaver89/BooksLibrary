
namespace BooksLibrary.Data.Configuration
{
    public class GenreConfiguration : EntityBaseConfiguration<Genre>
    {
        public GenreConfiguration()
        {
            Property(x => x.Id).HasColumnName("genre_id");
            Property(x => x.Name).IsRequired().HasMaxLength(200);
            Property(x => x.ParentGenreId).HasColumnName("paren_genre_id").IsOptional();
        }
    }
}
