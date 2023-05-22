using IdeaHouse.Models;

namespace IdeaHouse.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int id);
        bool Add(Category categories);
        bool Update(Category categories);
        bool Delete(Category categories);
        bool save();
    }
}
