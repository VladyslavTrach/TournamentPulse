using Microsoft.AspNetCore.Mvc;
using TournamentPulse.Application.Interface;
using TournamentPulse.WebUI.Models.Academy;
using AutoMapper;
using System.Collections.Generic;

namespace TournamentPulse.WebUI.Controllers
{
    public class AcademyController : Controller
    {
        private readonly IAcademyRepository _academyRepository;
        private readonly IMapper _mapper;

        public AcademyController(IAcademyRepository academyRepository, IMapper mapper)
        {
            _academyRepository = academyRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var academiesFromDb = _academyRepository.GetAllAcademies();
            var academies = _mapper.Map<List<AcademyListViewModel>>(academiesFromDb);

            return View(academies);
        }
    }
}
