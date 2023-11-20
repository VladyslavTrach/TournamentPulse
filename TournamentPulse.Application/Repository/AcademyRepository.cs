using Microsoft.EntityFrameworkCore;
using TournamentPulse.Application.Interface;
using TournamentPulse.Core.Entities;
using TournamentPulse.Infrastructure.Data;

namespace TournamentPulse.Application.Repository
{
    public class AcademyRepository : IAcademyRepository
    {
        private readonly ApplicationDataContext _context;

        public AcademyRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public void AddAcademy(Academy academy)
        {
            if (IsAcademyNameUnique(academy.Name))
            {
                _context.Academies.Add(academy);
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Academy with the same name already exists.");
            }
        }

        public int CountAcademiesByAssociation(int id)
        {
            return _context.Academies.Where(a => a.AssociationId == id).Count();
        }

        public void DeleteAcademy(int id)
        {
            var academy = _context.Academies.FirstOrDefault(a => a.Id == id);

            if (academy != null)
            {
                _context.Academies.Remove(academy);
                _context.SaveChanges();
            }
        }

        public List<Academy> GetAcademiesByAssociation(int associationId)
        {
            return _context.Academies
                .Include(a => a.Country)
                .Include(a => a.Fighters)
                .Where(a => a.AssociationId == associationId).ToList();
        }

        public Academy GetAcademyById(int id)
        {
            return _context.Academies.Where(a => a.Id == id).FirstOrDefault();
        }

        public Academy GetAcademyByName(string academyName)
        {
            return _context.Academies
                .Include(a => a.Association)
                .Include(a => a.Country)
                .Include(a => a.Fighters)
                .Where(a => a.Name == academyName).FirstOrDefault();
        }

        public ICollection<Academy> GetAllAcademies()
        {
            return _context.Academies
                .Include(a => a.Association)
                .Include(a => a.Country)
                .Include(a => a.Fighters)
                .ToList();
        }

        public ICollection<Academy> GetAllAcademiesAPI()
        {
            return _context.Academies.ToList();
        }

        private bool IsAcademyNameUnique(string name)
        {
            // Check if there is any academy with the same name in the database
            return !_context.Academies.Any(a => a.Name == name);
        }
    }
}
