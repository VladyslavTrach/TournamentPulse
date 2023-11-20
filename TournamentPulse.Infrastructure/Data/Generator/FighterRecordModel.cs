namespace TournamentPulse.Infrastructure.Data.Generator
{
    public record FighterRecordModel
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public float Weight { get; set; }
        public Rank Rank { get; set; }
        public int AcademyId { get; set; }
    }
}
