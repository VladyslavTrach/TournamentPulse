using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentPulse.Core.Entities
{
    public class Match
    {
        public int Id { get; set; }
        public int Round { get; set; }

        public int? Score1 { get; set; }
        public int? Score2 { get; set; }
        public string MatchStatus { get; set; } // Scheduled / Occurred(someone won) / Canceled(both fighters didnt appear)
        public string? WinningMethod { get; set; } //By : submition, points, walkover, disqualification

        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int Fighter1Id { get; set; }
        public Fighter Fighter1 { get; set; }

        public int Fighter2Id { get; set; }
        public Fighter Fighter2 { get; set; }

        public int? WinnerId { get; set; }
        public Fighter Winner { get; set; }

    }
}
