using IdeaHouse.Models;

namespace IdeaHouse.Interfaces
{
    public interface IIdeaRepository
    {
        Task<Idea> GetIdeaById(int id);
        Task<IEnumerable<Idea>> GetAllIdeasWithCategories();
        Task<IEnumerable<Idea>> GetAllIdeas();
        bool Add(Idea ideas);
        bool Update(Idea ideas);
        bool Delete(Idea ideas);
        bool save();
        Task<Idea> FindAsync(int id);
    }
}
