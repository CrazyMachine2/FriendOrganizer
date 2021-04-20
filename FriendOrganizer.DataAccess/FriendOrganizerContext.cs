using FriendOrganizer.DataAccess.Configurations;
using FriendOrganizer.Model;
using Microsoft.EntityFrameworkCore;

namespace FriendOrganizer.DataAccess 
{
    public class FriendOrganizerContext : DbContext
    {
        public DbSet<Friend> Friends { get; set; }

        public FriendOrganizerContext(DbContextOptions<FriendOrganizerContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new FriendConfiguration());
        }
    }
}
