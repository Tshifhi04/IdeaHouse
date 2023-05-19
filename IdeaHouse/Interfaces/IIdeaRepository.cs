using IdeaHouse.Models;

namespace IdeaHouse.Interfaces
{
    public interface IIdeaRepository
    {
        Task<IEnumerable<Idea>> GetAllIdeas();
        bool Add(Idea ideas);
        bool Update(Idea ideas);
        bool Delete(Idea ideas);
        bool save();
    }
}
