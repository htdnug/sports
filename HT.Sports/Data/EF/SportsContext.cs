using HT.Sports.Data.EF.Mappers;
using HT.Sports.Entities;
using Microsoft.EntityFrameworkCore;

namespace HT.Sports.Data.EF
{
    public class SportsContext : DbContext
    {
        public SportsContext()
        {
        }

        public SportsContext(DbContextOptions<SportsContext> options)
            : base(options)
        {
        }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TripMap());
            modelBuilder.ApplyConfiguration(new UserProfileMap());
            // may use this method at a later date
            //var assembly = typeof(SportsContext).Assembly;
            //modelBuilder.ApplyConfigurationsFromAssembly(assembly, x => x.Namespace.Contains("EF.Mappers"));
            base.OnModelCreating(modelBuilder);
        }
    }
}
