﻿using IdeaHouse.Data;
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

        public bool Delete(Idea ideas)
        {
            _context.Remove(ideas);
            return save();

        }

        public async Task<IEnumerable<Idea>> GetAllIdeas()
        {
            return await _context.Ideas.ToListAsync();
        }

        public bool save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Idea ideas)
        {
            throw new NotImplementedException();
        }
    }
}