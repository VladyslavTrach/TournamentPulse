using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TournamentPulse.Core.Entities;

internal class CountryEntityConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Countries");

        builder.HasKey(country => country.Id);

        builder.Property(country => country.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasMany(country => country.Academies)
            .WithOne(academy => academy.Country)
            .HasForeignKey(academy => academy.CountryId);
    }
}
