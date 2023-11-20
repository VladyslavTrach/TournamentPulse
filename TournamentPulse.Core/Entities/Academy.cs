namespace TournamentPulse.Core.Entities
{
    public class Academy
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int AssociationId { get; set; }
        public int CountryId { get; set; }

        public Association Association { get; set; }
        public Country Country { get; set; }

        public ICollection<Fighter> Fighters { get; set; }
    }
}
