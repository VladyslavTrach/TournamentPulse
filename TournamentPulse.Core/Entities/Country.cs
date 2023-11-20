namespace TournamentPulse.Core.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Academy> Academies { get; set; }
    }
}
