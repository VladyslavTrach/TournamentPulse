using TournamentPulse.WebUI.Models.Academy;

namespace TournamentPulse.WebUI.Models.Association
{
    public class AssociationDetailsListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AcademiesCnt { get; set; }
        public int FightersCnt { get; set; }
        public List<AcademyListViewModel> Academies { get; set; }
    }
}
