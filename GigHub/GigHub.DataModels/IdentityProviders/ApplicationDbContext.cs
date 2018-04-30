using GigHub.IdentityModels.DomainModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

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
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Following> Followings { get; set; }

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

            modelBuilder.Entity<Attendance>()
                .HasRequired(a => a.Gig)
                .WithMany()
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Attendance>()
            //    .HasRequired(a => a.Attendee)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Following>()
                .HasRequired(f => f.Followee)
                .WithMany(f => f.Followers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Following>()
                .HasRequired(f => f.Follower)
                .WithMany(f => f.Followees)
                .WillCascadeOnDelete(false);
                

            base.OnModelCreating(modelBuilder);
        }
    }
}