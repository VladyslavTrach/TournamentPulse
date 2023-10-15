using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TournamentPulse.Core.Entities;

internal class AcademyEntityConfiguration : IEntityTypeConfiguration<Academy>
{
    public void Configure(EntityTypeBuilder<Academy> builder)
    {
        builder.ToTable("Academies");

        builder.HasKey(academy => academy.Id);

        builder.Property(academy => academy.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(academy => academy.AssociationId)
            .IsRequired();
        builder.HasOne(academy => academy.Association)
            .WithMany(association => association.Academies)
            .HasForeignKey(academy => academy.AssociationId);

        builder.Property(academy => academy.CountryId)
            .IsRequired();
        builder.HasOne(academy => academy.Country)
            .WithMany(country => country.Academies)
            .HasForeignKey(academy => academy.CountryId);

        builder.HasMany(academy => academy.Fighters)
           .WithOne(fighter => fighter.Academy)
           .HasForeignKey(fighter => fighter.AcademyId);
    }
}
