using Microsoft.AspNetCore.Mvc;
using TournamentPulse.Application.Interface;
using TournamentPulse.WebUI.Models.Academy;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using TournamentPulse.WebUI.Models.Fighter;

namespace TournamentPulse.WebUI.Controllers
{
    public class AcademyController : Controller
    {
        private readonly IAcademyRepository _academyRepository;
        private readonly IMapper _mapper;
        private readonly IFighterRepository _fighterRepository;

        public AcademyController(IAcademyRepository academyRepository, IMapper mapper, IFighterRepository fighterRepository)
        {
            _academyRepository = academyRepository;
            _mapper = mapper;
            _fighterRepository = fighterRepository;
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

    }
}
