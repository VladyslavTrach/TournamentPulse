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
    public class AssociationRepository : IAssociationRepository
    {
        private readonly ApplicationDataContext _context;
        private readonly IFighterRepository _fighterRepository;

        public AssociationRepository(ApplicationDataContext context, IFighterRepository fighterRepository)
        {
            _context = context;
            _fighterRepository = fighterRepository;
        }

        public int CountFightersByAssociation(int id)
        {
            return _context.Fighters.Count(f => _context.Academies.Any(a => a.AssociationId == id && a.Id == f.AcademyId));
        }


        public ICollection<Association> GetAllAssociations()
        {
            return _context.Associations
                .Include(a => a.Academies)
                .ThenInclude(a => a.Fighters)
                .ToList();
        }

        public Association GetAssociationById(int id)
        {
            return _context.Associations.Where(a => a.Id == id).FirstOrDefault();
        }

        public Association GetAssociationByName(string Name)
        {
            return _context.Associations.Where(a => a.Name == Name).FirstOrDefault();
        }
    }
}
