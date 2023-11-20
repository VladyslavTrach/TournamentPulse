using TournamentPulse.Core.Entities;

namespace TournamentPulse.Application.Interface
{
    public interface ICountryRepositry
    {
        ICollection<Country> GetAllCountries();
        Country GetCountryById(int id);
        Country GetCountryByName(string name);
    }
}
