using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TournamentPulse.Application.Interface;
using TournamentPulse.Core.Entities;
using TournamentPulse.WebUI.Models.Academy;
using TournamentPulse.WebUI.Models.Fighter;

namespace TournamentPulse.WebUI.Controllers
{
    public class AcademyController : Controller
    {
        private readonly IAcademyRepository _academyRepository;
        private readonly IMapper _mapper;
        private readonly IFighterRepository _fighterRepository;
        private readonly IAssociationRepository _associationRepository;
        private readonly ICountryRepositry _countryRepository;

        public AcademyController(IAcademyRepository academyRepository, IMapper mapper, IFighterRepository fighterRepository, IAssociationRepository associationRepository, ICountryRepositry countryRepository)
        {
            _academyRepository = academyRepository;
            _mapper = mapper;
            _fighterRepository = fighterRepository;
            _associationRepository = associationRepository;
            _countryRepository = countryRepository;
        }

        public IActionResult Index()
        {
            var academiesFromDb = _academyRepository.GetAllAcademies();
            var academies = _mapper.Map<List<AcademyListViewModel>>(academiesFromDb);

            return View(academies);
        }
        public IActionResult Detail(string academyName)
        {
            var academyFromDb = _academyRepository.GetAcademyByName(academyName);
            var fighters = _fighterRepository.GetFightersByAcademy(academyFromDb.Id);

            AcademyDetailsViewModel academy = _mapper.Map<AcademyDetailsViewModel>(academyFromDb);

            // Map the fighters to FighterListViewModel
            List<FighterListViewModel> fighterListViewModels = fighters.Select(fighter => _mapper.Map<FighterListViewModel>(fighter)).ToList();

            academy.Fighters = fighterListViewModels;

            return View(academy);
        }

        [Authorize(Roles = "Admin,Organizer")]
        public IActionResult Add()
        {

            return View();
        }

        [Authorize(Roles = "Admin,Organizer")]
        [HttpPost]
        public IActionResult Add(AcademyViewModel model)
        {
            if (ModelState.IsValid)
            {
                Academy academy = new Academy(); // Instantiate an instance of Academy

                academy.Name = model.Name;
                academy.AssociationId = _associationRepository.GetAssociationByName(model.Association).Id;
                academy.CountryId = _countryRepository.GetCountryByName(model.Country).Id;

                _academyRepository.AddAcademy(academy);

                return RedirectToAction("Index");
            }


            // If the model is not valid, redisplay the form with validation errors
            return View(model);
        }

    }
}
