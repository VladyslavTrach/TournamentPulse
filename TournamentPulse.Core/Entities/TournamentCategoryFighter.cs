using System;
using System.ComponentModel.DataAnnotations;

namespace TournamentPulse.Core.Entities
{
    public class TournamentCategoryFighter
    {
        [Key]
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }

        [Key]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Key]
        public int FighterId { get; set; }
        public Fighter Fighter { get; set; }
    }
}
