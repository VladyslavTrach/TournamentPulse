using TournamentPulse.WebUI.Models.Fighter;

namespace TournamentPulse.WebUI.Models.Academy
{
    public class AcademyDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Association { get; set; }
        public string Country { get; set; }
        public int FightersCnt { get; set; }
        public List<FighterListViewModel> Fighters { get; set; }
    }
}
