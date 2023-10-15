using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TournamentPulse.Core.Entities;

internal class AssociationEntityConfiguration : IEntityTypeConfiguration<Association>
{
    public void Configure(EntityTypeBuilder<Association> builder)
    {
        builder.ToTable("Associations");

        builder.HasKey(association => association.Id);

        builder.Property(association => association.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasMany(association => association.Academies)
            .WithOne(academy => academy.Association)
            .HasForeignKey(academy => academy.AssociationId);
    }
}
