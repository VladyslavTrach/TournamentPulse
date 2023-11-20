namespace TournamentPulse.WebAPI.DTOs.Tournament
{
    public class CreateTournamentDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime Date { get; set; }
        public string? ImageName { get; set; }
        public int MaxParticipants { get; set; }
        public string? CreditCard { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public int Price { get; set; }
    }
}
