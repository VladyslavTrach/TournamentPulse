using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TournamentPulse.Core.Entities;

namespace TournamentPulse.Infrastructure.Data.EntityTypeConfiguration
{
    internal class TournamentEntityConfiguration : IEntityTypeConfiguration<Tournament>
    {
        public void Configure(EntityTypeBuilder<Tournament> builder)
        {
            builder.HasKey(t => t.Id); // Define the primary key

            builder.Property(t => t.Name)
                .IsRequired(); // Name is required

            builder.Property(t => t.Description)
                .IsRequired(); // Description is required

            builder.Property(t => t.Country)
                .IsRequired(); // Country is required

            builder.Property(t => t.City)
                .IsRequired(); // City is required

            builder.Property(t => t.Date)
                .IsRequired(); // Date is required

            builder.Property(t => t.MaxParticipants)
               .IsRequired(); // MaxParticipants is required

            builder.Property(t => t.Email)
              .IsRequired(); // Email is required

            builder.Property(t => t.Price)
              .IsRequired(); // Price is required

            builder.HasMany(t => t.Matches)
                .WithOne(m => m.Tournament)
                .HasForeignKey(m => m.TournamentId);

        }
    }
}
