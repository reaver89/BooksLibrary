using BooksLibrary.Membership;

namespace BooksLibrary.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BooksLibrary.Data.BooksLibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BooksLibrary.Data.BooksLibraryContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.RoleSet.AddOrUpdate(new Role() { Id = 1, Name = "Admin" });

        }
    }
}
