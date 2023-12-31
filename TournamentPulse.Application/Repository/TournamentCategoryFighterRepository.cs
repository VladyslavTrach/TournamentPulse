﻿using Microsoft.EntityFrameworkCore;
using TournamentPulse.Application.Interface;
using TournamentPulse.Core.Entities;
using TournamentPulse.Infrastructure.Data;

namespace TournamentPulse.Application.Repository
{
    public class TournamentCategoryFighterRepository : ITournamentCategoryFighterRepository
    {
        private readonly ApplicationDataContext _context;

        public TournamentCategoryFighterRepository(ApplicationDataContext context)
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
                // ADD Logger
                return false; // Failed to add the record
            }
        }

        public TournamentCategoryFighter GetTCFRecord(int tournamentId, int fighterId)
        {
            return _context.TournamentCategoryFighter
                .FirstOrDefault(tcf => tcf.TournamentId == tournamentId && tcf.FighterId == fighterId);
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
            var fighters = _context.TournamentCategoryFighter
                .Where(tcf => tcf.TournamentId == tournamentId && tcf.CategoryId == categoryId)
                .Join(
                    _context.Fighters,
                    tcf => tcf.FighterId,
                    f => f.Id,
                    (tcf, f) => f
                )
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

        public int CntFighters(int tournamentId)
        {
            return _context.TournamentCategoryFighter.Count(f => f.TournamentId == tournamentId);
        }
    }
}
