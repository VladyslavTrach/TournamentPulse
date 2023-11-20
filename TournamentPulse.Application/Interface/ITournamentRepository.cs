using TournamentPulse.Core.Entities;

namespace TournamentPulse.Application.Interface
{
    public interface ITournamentRepository
    {
        ICollection<Tournament> GetTournaments();
        Tournament GetById(int id);
        bool CreateTournament(Tournament tournament);
        bool TournamentExist(Tournament tournament);
    }
}
