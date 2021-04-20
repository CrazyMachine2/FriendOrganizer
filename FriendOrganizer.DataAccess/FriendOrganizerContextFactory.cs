using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FriendOrganizer.DataAccess
{
    public class FriendOrganizerContextFactory : IDesignTimeDbContextFactory<FriendOrganizerContext>
    {
        public FriendOrganizerContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../FriendOrganizer.UI"))
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            var optionsBuilder = new DbContextOptionsBuilder<FriendOrganizerContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("FriendOrganizerDb"));
            return new FriendOrganizerContext(optionsBuilder.Options);
        }
    }
}
