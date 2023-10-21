﻿using Microsoft.EntityFrameworkCore;
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
    public class TournamentCategoryFighterRepository : ITournamentCategoryFighterRepository
    {
        private readonly DataContext _context;

        public TournamentCategoryFighterRepository(DataContext context)
        {
            _context = context;
        }

        public bool AddTCFRecord(TournamentCategoryFighter tcf)
        {
            try
            {
                _context.Add(tcf);
                _context.SaveChanges();
                return true; // Success
            }
            catch (Exception ex)
            {
                return false; // Failed to add the record
            }
        }

        public ICollection<TournamentCategoryFighter> GetCategoryFighter(int tournamentId)
        {
            return _context.TournamentCategoryFighter.Where(tcf => tcf.TournamentId == tournamentId)
                .Include(tcf => tcf.Category)
                .Include(tcf => tcf.Fighter)
                .ThenInclude(fighter => fighter.Academy) // Correct the ThenInclude statement
                .ToList();
        }

        public ICollection<Fighter> GetFightersInCategoryAndTournament(int tournamentId, int categoryId)
        {
            // Retrieve the list of fighter IDs for the given tournament and category
            var fighterIds = _context.TournamentCategoryFighter
                .Where(tcf => tcf.TournamentId == tournamentId && tcf.CategoryId == categoryId)
                .Select(tcf => tcf.FighterId)
                .ToList();

            // Retrieve the fighters with the matching IDs
            var fighters = _context.Fighters
                .Where(f => fighterIds.Contains(f.Id))
                .ToList();

            return fighters;
        }


        public void UnregisterFighterFromTournament(int tournamentId, int fighterId)
        {
            var entry = _context.TournamentCategoryFighter
                .FirstOrDefault(tc => tc.TournamentId == tournamentId && tc.FighterId == fighterId);

            if (entry != null)
            {
                _context.TournamentCategoryFighter.Remove(entry);
                _context.SaveChanges();
            }
        }
    }
}
