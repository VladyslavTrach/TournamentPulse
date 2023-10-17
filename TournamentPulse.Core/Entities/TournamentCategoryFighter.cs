using System;
using System.ComponentModel.DataAnnotations;

namespace TournamentPulse.Core.Entities
{
    public class TournamentCategoryFighter
    {
        //here was [Key]
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int FighterId { get; set; }
        public Fighter Fighter { get; set; }
    }
}
