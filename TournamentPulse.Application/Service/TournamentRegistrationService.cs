using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentPulse.Application.Interface;
using TournamentPulse.Core.Entities;

namespace TournamentPulse.Application.Service
{
    public class TournamentRegistrationService
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IFighterRepository _fighterRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITournamentCategoryFighterRepository _tournamentCategoryFighterRepository;

        public TournamentRegistrationService(
            ITournamentRepository tournamentRepository,
            IFighterRepository fighterRepository,
            ICategoryRepository categoryRepository,
            ITournamentCategoryFighterRepository tournamentCategoryFighterRepository)
        {
            _tournamentRepository = tournamentRepository;
            _fighterRepository = fighterRepository;
            _categoryRepository = categoryRepository;
            _tournamentCategoryFighterRepository = tournamentCategoryFighterRepository;
        }

        public void RegisterFighterForTournament(int tournamentId, int fighterId)
        {
            // Fetch the tournament, fighter, and their respective categories
            var tournament = _tournamentRepository.GetById(tournamentId);
            var fighter = _fighterRepository.GetFighterById(fighterId);
            var categories = _categoryRepository.GetAllCategories();

            // Determine the suitable category for the fighter
            var suitableCategory = DetermineSuitableCategory(fighter, categories);

            if (suitableCategory == null)
            {
                // Handle the case where no suitable category is found
                return;
            }

            // Create a new record in the TournamentCategoryFighter table
            var tournamentCategoryFighter = new TournamentCategoryFighter
            {
                Tournament = tournament,
                Category = suitableCategory,
                Fighter = fighter,
            };

            _tournamentCategoryFighterRepository.AddTCFRecord(tournamentCategoryFighter);
        }

        public void UnregisterFighterFromTournament(int tournamentId, int fighterId)
        {
            _tournamentCategoryFighterRepository.UnregisterFighterFromTournament(tournamentId, fighterId);
        }

        public ICollection<TournamentCategoryFighter> GetCategoryFighter(int tournamentId)
        {
            return _tournamentCategoryFighterRepository.GetCategoryFighter(tournamentId);
        }

        private Category DetermineSuitableCategory(Fighter fighter, ICollection<Category> categories)
        {
            foreach (var category in categories)
            {
                if (fighter.Weight >= category.MinWeight && fighter.Weight < category.MaxWeight
                    && fighter.Age >= category.MinAge && fighter.Age < category.MaxAge
                    && fighter.Weight >= category.MinWeight && fighter.Weight < category.MaxWeight
                    && fighter.Rank == category.Rank)
                    return category;
            }
            return null;
        }
    }

}
