using System.Data.Entity;
using GigHub.IdentityModels.DomainModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GigHub.IdentityModels.IdentityProviders
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("GigHub", throwIfV1Schema: false)
        {
        }

        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Genre>()
            //    .HasMany(genre => genre.Gigs)
            //    .WithRequired(gig => gig.Genre)
            //    .HasForeignKey(gig => gig.GenreId);

            modelBuilder.Entity<Gig>()
                .HasRequired(gig => gig.Genre)
                .WithMany(genre => genre.Gigs)
                .HasForeignKey(gig => gig.GenreId);

            base.OnModelCreating(modelBuilder);
        }
    }
}