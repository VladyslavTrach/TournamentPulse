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
        private readonly IFighterRepository _fighterRepository;

        public AssociationRepository(DataContext context, IFighterRepository fighterRepository)
        {
            _context = context;
            _fighterRepository = fighterRepository;
        }

        public int CountFightersByAssociation(int id)
        {
            int cnt = 0;
            var academies = _context.Academies.Where(a => a.AssociationId == id).ToList(); // Materialize the query result

            foreach (var academie in academies)
            {
                cnt += _fighterRepository.CountFightersByAcademy(academie.Id);
            }

            return cnt;
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
