namespace TournamentPulse.WebAPI.DTOs.Fighter
{
    public class CreateFighterDTO
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public float Weight { get; set; }
        public string Rank { get; set; }
        public int AcademyId { get; set; }
        public string Email { get; set; }

    }
}
