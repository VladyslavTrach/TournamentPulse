using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentPulse.Core.Entities
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string? ImageName { get; set; }
        public int MaxParticipants { get; set; }
        public string? CreditCard { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }


        public ICollection<Fighter> Fighters { get; set; }

        public ICollection<FighterCategoryTournament> FighterCategoryTournaments { get; set; }
    }
}
