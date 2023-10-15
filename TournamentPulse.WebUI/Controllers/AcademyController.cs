using Microsoft.AspNetCore.Mvc;
using TournamentPulse.Application.Interface;
using TournamentPulse.Core.Entities;
using TournamentPulse.WebUI.Models.Academy;
using TournamentPulse.WebUI.Models.Tournament;

namespace TournamentPulse.WebUI.Controllers
{
    public class AcademyController : Controller
    {
        private readonly IAcademyRepository _academyRepository;
        private readonly IAssociationRepository _associationRepository;
        private readonly ICountryRepositry _countryRepositry;

        public AcademyController(IAcademyRepository academyRepository, IAssociationRepository associationRepository, ICountryRepositry countryRepositry)
        {
            _academyRepository = academyRepository;
            _associationRepository = associationRepository;
            _countryRepositry = countryRepositry;
        }

        public IAcademyRepository AcademyRepository { get; }

        public IActionResult Index()
        {
            var academiesFromDb = _academyRepository.GetAllAcademies();
            var academies = AcademyListMapper(academiesFromDb);

            return View(academies);
        }

        public List<AcademyListViewModel> AcademyListMapper(IEnumerable<Academy> academies)
        {
            return academies.Select(academy => new AcademyListViewModel
            {
                Id = academy.Id,
                Name = academy.Name,
                Association = _associationRepository.GetAssociationById(academy.AssociationId).Name,
                Country = _countryRepositry.GetCountryById(academy.CountryId).Name                
            }).ToList();
        }
    }
}
