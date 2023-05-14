using IdeaHouse.Models;

namespace IdeaHouse.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategories();
        bool Add(Category categories);
        bool Update(Category categories);
        bool Delete(Category categories);
        bool save();
    }
}
