using Microsoft.EntityFrameworkCore;
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

        public void AddAssociation(Association association)
        {
            if (IsAssociationNameUnique(association.Name))
            {
                _context.Associations.Add(association);
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Association with the same name already exists.");
            }
        }




        public int CountFightersByAssociation(int id)
        {
            return _context.Fighters.Count(f => _context.Academies.Any(a => a.AssociationId == id && a.Id == f.AcademyId));
        }

        public void DeleteAssociation(int id)
        {
            var association = _context.Associations.FirstOrDefault(a => a.Id == id);

            if (association != null)
            {
                _context.Associations.Remove(association);
                _context.SaveChanges();
            }
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

        private bool IsAssociationNameUnique(string name)
        {
            return !_context.Associations.Any(a => a.Name == name);
        }
    }
}
