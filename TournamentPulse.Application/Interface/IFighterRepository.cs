using TournamentPulse.Core.Entities;

namespace TournamentPulse.Application.Interface
{
    public interface IFighterRepository
    {
        ICollection<Fighter> GetAllFighters();
        ICollection<Fighter> GetFightersByAcademy(int academyId);
        Fighter GetFighterByEmail(string email);
        Fighter GetFighterByFullName(string fullName);
        Fighter GetFighterById(int id);
        int GetFighterIdByFullName(string fullName);
        int CountFightersByAcademy(int id);
        public bool AddFighter(Fighter fighter);
        public bool AddFighters(IEnumerable<Fighter> fighters);
        public bool FighterExists(Fighter fighter);
        public void UpdateFighter(Fighter fighter);
    }
}
