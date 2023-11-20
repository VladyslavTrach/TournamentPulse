using TournamentPulse.Core.Entities;

namespace TournamentPulse.Application.Interface
{
    public interface IAssociationRepository
    {
        ICollection<Association> GetAllAssociations();
        Association GetAssociationById(int id);
        Association GetAssociationByName(string Name);
        int CountFightersByAssociation(int id);
        void AddAssociation(Association association);
        void DeleteAssociation(int id);
    }
}
