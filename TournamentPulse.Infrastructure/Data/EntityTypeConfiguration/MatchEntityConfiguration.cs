using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TournamentPulse.Core.Entities;

internal class MatchEntityConfiguration : IEntityTypeConfiguration<Match>
{
    public void Configure(EntityTypeBuilder<Match> builder)
    {
        builder.ToTable("Matches");

        builder.HasKey(match => match.Id);

        builder.Property(match => match.MatchStatus)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(match => match.TournamentId)
            .IsRequired();

        builder.Property(match => match.CategoryId)
            .IsRequired();

        builder.Property(match => match.Fighter1Id)
            .IsRequired();

        builder.Property(match => match.Fighter2Id)
            .IsRequired();

        builder.Property(match => match.WinnerId)
            .IsRequired(false);

        builder.HasOne(match => match.Tournament)
            .WithMany(tournament => tournament.Matches)
            .HasForeignKey(match => match.TournamentId);

        builder.HasOne(match => match.Category)
            .WithMany(category => category.Matches)
            .HasForeignKey(match => match.CategoryId);

        builder.HasOne(match => match.Fighter1)
            .WithMany()
            .HasForeignKey(match => match.Fighter1Id)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(match => match.Fighter2)
            .WithMany()
            .HasForeignKey(match => match.Fighter2Id)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(match => match.Winner)
            .WithMany()
            .HasForeignKey(match => match.WinnerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
