using Microsoft.AspNetCore.Mvc;
using TournamentPulse.Application.Interface;
using TournamentPulse.Application.Repository;
using TournamentPulse.Core.Entities;
using TournamentPulse.WebUI.Models.Academy;
using TournamentPulse.WebUI.Models.Association;

namespace TournamentPulse.WebUI.Controllers
{
    public class AssociationController : Controller
    {
        private readonly IAcademyRepository _academyRepository;
        private readonly IAssociationRepository _associationRepository;

        public AssociationController(IAssociationRepository associationRepository, IAcademyRepository academyRepository)
        {
            _academyRepository = academyRepository;
            _associationRepository = associationRepository;
        }
        public IActionResult Index()
        {
            var associationsFromDb = _associationRepository.GetAllAssociations();
            var associations = AsscoiationListMapper(associationsFromDb);

            return View(associations);
        }

        public List<AssociationListViewModel> AsscoiationListMapper(IEnumerable<Association> associations)
        {
            return associations.Select(association => new AssociationListViewModel
            {
                Id = association.Id,
                Name = association.Name,
                AcademiesCnt = _academyRepository.CountAcademiesByAssociation(association.Id)
            }).ToList();
        }
    }
}
