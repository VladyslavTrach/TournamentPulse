using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentPulse.Core.Entities
{
    public class FighterCategoryTournament
    {
        public int FighterId { get; set; }
        public int CategoryId { get; set; }
        public int TournamentId { get; set; }

        public Fighter Fighter { get; set; }
        public Category Category { get; set; }
        public Tournament Tournament { get; set; }
    }
}
