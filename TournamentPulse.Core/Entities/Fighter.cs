namespace TournamentPulse.Core.Entities
{
    public class Fighter
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public float Weight { get; set; }
        public string Rank { get; set; }
        public string Email { get; set; }

        public int AcademyId { get; set; }

        public Academy Academy { get; set; }
    }
}
