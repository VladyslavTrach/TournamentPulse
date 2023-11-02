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
        private readonly ApplicationDataContext _context;

        public FighterRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public bool AddFighter(Fighter fighter)
        {
            try
            {
                if (!FighterExists(fighter))
                {
                    _context.Fighters.Add(fighter);
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

        public bool AddFighters(IEnumerable<Fighter> fighters)
        {
            var newFighters = fighters.Where(f => !FighterExists(f)).ToList();

            if (newFighters.Any())
            {
                _context.Fighters.AddRange(newFighters);
                _context.SaveChanges();

                return true;
            }
            return false;
        }


        public int CountFightersByAcademy(int id)
        {
            return _context.Fighters.Where(f => f.AcademyId == id).Count();
        }

    public bool FighterExists(Fighter fighter)
    {
        return _context.Fighters.Any(f => 
            f.FullName == fighter.FullName && 
            f.AcademyId == fighter.AcademyId && 
            f.Age == fighter.Age
        );
    }



        public ICollection<Fighter> GetAllFighters()
        {
            return _context.Fighters.Include(f => f.Academy).ToList();
        }

        public Fighter GetFighterById(int id)
        {
            var fighter = _context.Fighters.FirstOrDefault(f => f.Id == id);
                return fighter;
        }

    }
}
