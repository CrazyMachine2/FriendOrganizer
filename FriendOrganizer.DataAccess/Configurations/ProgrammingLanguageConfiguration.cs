using FriendOrganizer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FriendOrganizer.DataAccess.Configurations
{
    class ProgrammingLanguageConfiguration : IEntityTypeConfiguration<ProgrammingLanguage>
    {
        public void Configure(EntityTypeBuilder<ProgrammingLanguage> builder)
        {
            builder.HasData(
                new ProgrammingLanguage { ID = 1, Name = "C#" },
                new ProgrammingLanguage { ID = 2, Name = "Java" },
                new ProgrammingLanguage { ID = 3, Name = "JavaScript" },
                new ProgrammingLanguage { ID = 4, Name = "PHP" },
                new ProgrammingLanguage { ID = 5, Name = "Python" }
                );
        }
    }
}
