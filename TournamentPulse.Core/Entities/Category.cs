using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentPulse.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int WeightClassId { get; set; }
        public int RankClassId { get; set; }
        public int AgeClassId { get; set; }

        public WeightClass WeightClass { get; set; }
        public RankClass RankClass { get; set; }
        public AgeClass AgeClass { get; set; }

        public ICollection<FighterCategoryTournament> FighterCategoryTournaments { get; set; }
    }
}
