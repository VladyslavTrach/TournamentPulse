using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TournamentPulse.Application.Interface;
using TournamentPulse.Application.Repository;
using TournamentPulse.Core.Entities;
using TournamentPulse.WebUI.Models.Fighter;

namespace TournamentPulse.WebUI.Controllers
{
    public class FighterController : Controller
    {
        private readonly IFighterRepository _fighterRepository;
        private readonly IMapper _mapper;

        public FighterController(IFighterRepository fighterRepository, IMapper mapper)
        {
            _fighterRepository = fighterRepository;

            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var fightersFromDb = _fighterRepository.GetAllFighters();
            var fighters = _mapper.Map<List<FighterListViewModel>>(fightersFromDb);

            return View(fighters);
        }
    }
}
