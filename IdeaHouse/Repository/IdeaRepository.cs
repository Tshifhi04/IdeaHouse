using IdeaHouse.Data;
using IdeaHouse.Interfaces;
using IdeaHouse.Models;
using Microsoft.EntityFrameworkCore;

namespace IdeaHouse.Repository
{
    public class IdeaRepository : IIdeaRepository
    {
        private readonly ApplicationDbContext _context;

        public IdeaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Idea ideas)
        {
            _context.Add(ideas);
            return save();
        }
        public bool Update(Idea ideas)
        {
            _context.Update(ideas);
            return save();
        }

        public bool Delete(Idea ideas)
        {
            _context.Remove(ideas);
            return save();



        }


     
        public async Task<IEnumerable<Idea> > GetAllIdeasWithCategories()
        {
            return  _context.Ideas.Include(idea => idea.Category).ToList();
        }
        public async Task<IEnumerable<Idea>> GetAllIdeas()
        {
            return await _context.Ideas.ToListAsync();
        }
        public async Task<Idea> GetIdeaById(int id)
        {
            return await _context.Ideas.FindAsync(id);
        }

        public bool save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

      
        public async Task<Idea> FindAsync(int id)
        {
            return await _context.Ideas.FindAsync(id);

        }
    }
}
