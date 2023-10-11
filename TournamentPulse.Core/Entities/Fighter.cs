using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentPulse.Core.Entities
{
    public class Fighter
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public float Weight { get; set; }
        public string Rank { get; set; }



        public int WeightClassId { get; set; }
        public int RankClassId { get; set; }
        public int AgeClassId { get; set; }
        public int CategoryId { get; set; }
        public int AcademyId { get; set; }
        public int UserId { get; set; }
        public int? TournamentId { get; set; }


        public WeightClass WeightClass { get; set; }
        public RankClass RankClass { get; set; }
        public AgeClass AgeClass { get; set; }
        public Academy Academy { get; set; }
        public User User { get; set; }
        public Tournament Tournament { get; set; }
        public Category Category { get; set; }

        public ICollection<FighterCategoryTournament> FighterCategoryTournaments { get; set; }
    }
}
