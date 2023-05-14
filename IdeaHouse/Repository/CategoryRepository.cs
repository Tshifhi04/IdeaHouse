using IdeaHouse.Data;
using IdeaHouse.Interfaces;
using IdeaHouse.Models;
using Microsoft.EntityFrameworkCore;

namespace IdeaHouse.Repository
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;            
        }

        public bool Add(Category categories)
        {
            _context.Add(categories);
            return save();
        }

        public bool Delete(Category categories)
        {
            _context.Remove(categories);
            return save();
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public bool save()
        {

            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Category categories)
        {
            throw new NotImplementedException();
        }
    }
}
