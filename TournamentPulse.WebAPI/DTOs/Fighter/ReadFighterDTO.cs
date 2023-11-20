namespace TournamentPulse.WebAPI.DTOs.Fighter
{
    public class ReadFighterDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public float Weight { get; set; }
        public string Rank { get; set; }
        public string Email { get; set; }
    }
}
