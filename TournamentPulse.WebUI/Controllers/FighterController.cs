﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TournamentPulse.Application.Interface;
using TournamentPulse.Application.Repository;
using TournamentPulse.Application.Service;
using TournamentPulse.Core.Entities;
using TournamentPulse.Infrastructure.Data.Generator;
using TournamentPulse.WebUI.Models.Fighter;

namespace TournamentPulse.WebUI.Controllers
{
    public class FighterController : Controller
    {
        private readonly IFighterRepository _fighterRepository;
        private readonly IMapper _mapper;
        private readonly ISeedFightersInDbService _seedFightersInDbService;

        public FighterController(IFighterRepository fighterRepository, IMapper mapper, ISeedFightersInDbService seedFightersInDbService)
        {
            _fighterRepository = fighterRepository;

            _seedFightersInDbService = seedFightersInDbService;

            _mapper = mapper;
        }
        public IActionResult Index()
        {
            //_seedFightersInDbService.GenerateFighters(); //Seeding Example

            var fightersFromDb = _fighterRepository.GetAllFighters();
            var fighters = _mapper.Map<List<FighterListViewModel>>(fightersFromDb);

            return View(fighters);
        }

        public IActionResult Details(string fighterName)
        {
            if (string.IsNullOrEmpty(fighterName))
            {
                return NotFound();
            }

            var fighterFromDb = _fighterRepository.GetFighterByFullName(fighterName);

            if (fighterFromDb == null)
            {
                return NotFound();
            }

            var fighter = _mapper.Map<FighterListViewModel>(fighterFromDb);

            return View(fighter);
        }

        [Authorize(Roles = "User")]
        public IActionResult Add()
        {
            return View();
        }
    }
}
