using TournamentPulse.Core.Entities;

namespace TournamentPulse.Application.Interface
{
    public interface IAcademyRepository
    {
        ICollection<Academy> GetAllAcademies();
        List<Academy> GetAcademiesByAssociation(int associationId);
        Academy GetAcademyById(int id);
        Academy GetAcademyByName(string academyName);
        int CountAcademiesByAssociation(int id);
        void AddAcademy(Academy academy);
    }
}
