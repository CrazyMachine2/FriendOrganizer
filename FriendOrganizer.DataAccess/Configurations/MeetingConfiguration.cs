using FriendOrganizer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendOrganizer.DataAccess.Configurations
{
    public class MeetingConfiguration : IEntityTypeConfiguration<Meeting>
    {
        public void Configure(EntityTypeBuilder<Meeting> builder)
        {
            builder.HasData(
                new Meeting
                {
                    ID = 1,
                    Title = "Football game",
                    DateFrom = new DateTime(2021, 5, 26),
                    DateTo = new DateTime(2021, 5, 26)
                }
            );
        }
    }
}
