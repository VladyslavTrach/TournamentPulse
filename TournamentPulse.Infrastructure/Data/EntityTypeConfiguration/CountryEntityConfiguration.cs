using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TournamentPulse.Core.Entities;

namespace TournamentPulse.Infrastructure.Data.EntityTypeConfiguration
{
    internal class CountryEntityConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            // PK
            builder.HasKey(c => c.Id);

            // Name is required
            builder.Property(c => c.Name).IsRequired();

            // Define the relationship with Academy (ONE Country has MANY Academies)
            builder
                .HasMany(c => c.Academies)
                .WithOne(a => a.Country)
                .HasForeignKey(a => a.CountryId);
        }
    }
}
