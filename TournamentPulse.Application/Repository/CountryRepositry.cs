using TournamentPulse.Application.Interface;
using TournamentPulse.Core.Entities;
using TournamentPulse.Infrastructure.Data;

namespace TournamentPulse.Application.Repository
{
    public class CountryRepositry : ICountryRepositry
    {
        private readonly ApplicationDataContext _context;

        public CountryRepositry(ApplicationDataContext context)
        {
            _context = context;
        }

        public ICollection<Country> GetAllCountries()
        {
            return _context.Countries.OrderBy(c => c.Id).ToList();
        }

        public Country GetCountryById(int id)
        {
            return _context.Countries.Where(c => c.Id == id).FirstOrDefault();
        }

        public Country GetCountryByName(string name)
        {
            return _context.Countries.Where(c => c.Name == name).FirstOrDefault();
        }
    }
}
