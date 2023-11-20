using TournamentPulse.Application.Interface;
using TournamentPulse.Core.Entities;
using TournamentPulse.Infrastructure.Data;

namespace TournamentPulse.Application.Repository
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly ApplicationDataContext _context;

        public TournamentRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public bool CreateTournament(Tournament tournament)
        {
            try
            {
                if (!TournamentExist(tournament))
                {
                    _context.Tournaments.Add(tournament);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public Tournament GetById(int id)
        {
            return _context.Tournaments.Where(t => t.Id == id).FirstOrDefault();
        }

        public ICollection<Tournament> GetTournaments()
        {
            return _context.Tournaments.OrderBy(t => t.Id).ToList();
        }

        public bool TournamentExist(Tournament tournament)
        {
            return _context.Tournaments.Any(t => t.Name == tournament.Name);
        }

    }
}
