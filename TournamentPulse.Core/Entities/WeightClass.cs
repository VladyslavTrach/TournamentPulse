using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentPulse.Core.Entities
{
    public class WeightClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinWeight { get; set; }
        public int MaxWeight { get; set; }

        public ICollection<Fighter> Fighters { get; set; }
    }
}
