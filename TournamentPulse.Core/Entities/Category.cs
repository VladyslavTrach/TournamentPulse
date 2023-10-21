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
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public float MinWeight { get; set; }
        public float MaxWeight { get; set; }
        public string Rank { get; set; }

        public ICollection<Match> Matches { get; set; }
    }
}
