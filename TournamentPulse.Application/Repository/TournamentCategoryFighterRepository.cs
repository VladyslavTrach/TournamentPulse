using Microsoft.EntityFrameworkCore;
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
    public class TournamentCategoryFighterRepository : ITournamentCategoryFighterRepository
    {
        private readonly DataContext _context;

        public TournamentCategoryFighterRepository(DataContext context)
        {
            _context = context;
        }

        public bool AddTCFRecord(TournamentCategoryFighter tcf)
        {
            try
            {
                _context.Add(tcf);
                _context.SaveChanges();
                return true; // Success
            }
            catch (Exception ex)
            {
                return false; // Failed to add the record
            }
        }

        public ICollection<TournamentCategoryFighter> GetCategoryFighter(int tournamentId)
        {
            return _context.TournamentCategoryFighter.Where(tcf => tcf.TournamentId == tournamentId)
                .Include(tcf => tcf.Category)
                .Include(tcf => tcf.Fighter)
                .ThenInclude(fighter => fighter.Academy) // Correct the ThenInclude statement
                .ToList();
        }

    }
}
