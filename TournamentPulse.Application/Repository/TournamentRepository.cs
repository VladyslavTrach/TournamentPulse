using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentPulse.Application.Interface;
using TournamentPulse.Core.Entities;
using TournamentPulse.Infrastructure.Data;

namespace TournamentPulse.Application.Repository
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly DataContext _context;

        public TournamentRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateTournament(Tournament tournament)
        {
            try
            {
                if(!TournamentExist(tournament))
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
            var existingTournament = _context.Tournaments.FirstOrDefault(t => t.Name == tournament.Name);

            return existingTournament != null;
        }
    }
}
