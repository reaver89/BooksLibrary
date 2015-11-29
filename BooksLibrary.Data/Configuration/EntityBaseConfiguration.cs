using System.Data.Entity.ModelConfiguration;

namespace BooksLibrary.Data.Configuration
{
    public class EntityBaseConfiguration<T> : EntityTypeConfiguration<T> where T : class, IEntityBase
    {
        public EntityBaseConfiguration() { HasKey(e => e.Id); }
    }
}
