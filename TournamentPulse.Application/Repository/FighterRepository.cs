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
    public class FighterRepository : IFighterRepository
    {
        private readonly DataContext _context;

        public FighterRepository(DataContext context)
        {
            _context = context;
        }
        public int CountFightersByAcademy(int id)
        {
            return _context.Fighters.Where(f => f.AcademyId == id).Count();
        }

        public ICollection<Fighter> GetAllFighters()
        {
            return _context.Fighters.Include(f => f.Academy).ToList();
        }

        public Fighter GetFighterById(int id)
        {
            return _context.Fighters.Where(f => f.Id == id).First();
        }
    }
}
