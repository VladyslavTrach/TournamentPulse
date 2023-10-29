using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentPulse.Application.Interface;
using TournamentPulse.Core.Entities;
using TournamentPulse.Infrastructure.Data;
using TournamentPulse.Infrastructure.Data.Generator;

namespace TournamentPulse.Application.Service
{
    public class SeedFightersInDbService : ISeedFightersInDbService
    {
        private readonly IFighterRepository _fighterRepository;
        private readonly DataGenerator _dataGenerator;
        private readonly IMapper _mapper;

        public SeedFightersInDbService(IFighterRepository fighterRepository, DataGenerator dataGenerator, IMapper mapper)
        {
            _fighterRepository = fighterRepository;
            _dataGenerator = dataGenerator;
            _mapper = mapper;
        }

        public void GenerateFighter()
        {
            FighterRecordModel fighterRecordModel = _dataGenerator.GenerateFighter();

            // Create a new Fighter instance by passing the FighterRecordModel to the constructor
            Fighter fighter = _mapper.Map<Fighter>(fighterRecordModel);

            _fighterRepository.AddFighter(fighter);
        }

        public void GenerateFighters()
        {
            IEnumerable<FighterRecordModel> fighterRecordModels = _dataGenerator.GenerateFighters().Take(10);

            IEnumerable<Fighter> fighters = fighterRecordModels.Select(fr => _mapper.Map<Fighter>(fr));

            _fighterRepository.AddFighters(fighters);
        }

    }
}
