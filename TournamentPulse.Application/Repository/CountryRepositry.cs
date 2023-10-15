using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentPulse.Application.Interface;
using TournamentPulse.Core.Entities;
using TournamentPulse.Infrastructure.Data;

namespace TournamentPulse.Application.Repository
{
    public class CountryRepositry : ICountryRepositry
    {
        private readonly DataContext _context;

        public CountryRepositry(DataContext context)
        {
            _context = context;
        }

        public ICollection<Country> GetAllCountries()
        {
            throw new NotImplementedException();
        }

        public Country GetCountryById(int id)
        {
            return _context.Countries.Where(c => c.Id == id).FirstOrDefault();
        }
    }
}
