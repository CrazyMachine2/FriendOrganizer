using FriendOrganizer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace FriendOrganizer.DataAccess.Configurations
{
    public class FriendConfiguration : IEntityTypeConfiguration<Friend>
    {

        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.HasData(
              new Friend { ID = 1, FirstName = "Bobe", LastName = "Turboto" },
              new Friend { ID = 2, FirstName = "Stefko", LastName = "Oboista" },
              new Friend { ID = 3, FirstName = "Mario", LastName = "Kitarista" },
              new Friend { ID = 4, FirstName = "Forever", LastName = "Alone" }
              );
        }
    }
}
