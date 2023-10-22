using TournamentPulse.Core.Entities;

namespace TournamentPulse.WebUI.Models.Match
{
    public class MatchViewModel
    {
        public int Id { get; set; }

        public int? Score1 { get; set; }
        public int? Score2 { get; set; }
        public string MatchStatus { get; set; } // Scheduled / Occurred(someone won) / Canceled(both fighters didnt appear)
        public string? WinningMethod { get; set; } //By : submition, points, walkover, disqualification

        public int TournamentId { get; set; }

        public int CategoryId { get; set; }

        public string Fighter1 { get; set; }

        public string Fighter2 { get; set; }

        public string? Winner { get; set; }
    }
}
