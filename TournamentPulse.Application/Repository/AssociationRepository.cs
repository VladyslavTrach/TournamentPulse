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
        private readonly DataContext _context;

        public AssociationRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Association> GetAllAssociations()
        {
            return _context.Associations.OrderBy(a => a.Id).ToList();
        }

        public Association GetAssociationById(int id)
        {
            return _context.Associations.Where(a => a.Id == id).FirstOrDefault();
        }
    }
}
