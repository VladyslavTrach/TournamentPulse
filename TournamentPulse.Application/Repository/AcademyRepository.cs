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
    public class AcademyRepository : IAcademyRepository
    {
        private readonly DataContext _context;

        public AcademyRepository(DataContext context)
        {
            _context = context;
        }

        public int CountAcademiesByAssociation(int id)
        {
            return _context.Academies.Where(a => a.AssociationId == id).Count();
        }

        public Academy GetAcademyById(int id)
        {
            return _context.Academies.Where(a => a.Id == id).FirstOrDefault();
        }

        public ICollection<Academy> GetAllAcademies()
        {
            return _context.Academies
                .Include(a => a.Association)
                .Include(a => a.Country)
                .Include(a => a.Fighters)
                .ToList();
        }
    }
}
