using TournamentPulse.WebUI.Models.Match;

namespace TournamentPulse.WebUI.Models.Fighter
{
    public class FighterWithMatchesViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public float Weight { get; set; }
        public string Rank { get; set; }
        public string? Academy { get; set; }

        public List<MatchViewModel> Matches { get; set; }
    }
}
