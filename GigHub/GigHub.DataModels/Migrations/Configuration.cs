using System.Data.Entity.Migrations;
using GigHub.IdentityModels.DomainModels;
using GigHub.IdentityModels.IdentityProviders;

namespace GigHub.IdentityModels.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            context.Genres.AddOrUpdate(new []
            {
                new Genre{Id = 1, Name = "Jazz"},
                new Genre{Id = 2, Name = "Blues"},
                new Genre{Id = 3, Name = "Rock"},
                new Genre{Id = 4, Name = "Country"}
            });
        }
    }
}
