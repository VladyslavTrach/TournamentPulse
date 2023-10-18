using TournamentPulse.Core.Entities;
using TournamentPulse.WebUI.Models.Fighter;

namespace TournamentPulse.WebUI.Models.CategoryFighter
{
    public class CategoryFighterListViewModel
    {
        public string Category { get; set; }
        public List<FighterListViewModel> Fighters { get; set; }
    }
}
