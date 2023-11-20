using TournamentPulse.Application.Interface;
using TournamentPulse.Core.Entities;
using TournamentPulse.Infrastructure.Data;

namespace TournamentPulse.Application.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDataContext _context;

        public CategoryRepository(ApplicationDataContext context)
        {
            _context = context;
        }
        public ICollection<Category> GetAllCategories()
        {
            return _context.Categories.OrderBy(c => c.Id).ToList();
        }

        public int GetCategoryId(string Name)
        {
            return _context.Categories.Where(c => c.Name == Name).First().Id;
        }
    }
}
