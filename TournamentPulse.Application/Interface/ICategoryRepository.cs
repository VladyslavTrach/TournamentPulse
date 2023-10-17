using TournamentPulse.Core.Entities;

namespace TournamentPulse.Application.Interface
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetAllCategories();
    }
}