using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TournamentPulse.Core.Entities;

internal class FighterEntityConfiguration : IEntityTypeConfiguration<Fighter>
{
    public void Configure(EntityTypeBuilder<Fighter> builder)
    {
        builder.ToTable("Fighters");

        builder.HasKey(fighter => fighter.Id);

        builder.Property(fighter => fighter.FullName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(fighter => fighter.Age)
            .IsRequired();

        builder.Property(fighter => fighter.Weight)
            .IsRequired();

        builder.Property(fighter => fighter.Rank)
            .HasMaxLength(255);

        builder.Property(fighter => fighter.AcademyId)
            .IsRequired();


        builder.HasOne(fighter => fighter.Academy)
            .WithMany(academy => academy.Fighters)
            .HasForeignKey(fighter => fighter.AcademyId);
    }
}
