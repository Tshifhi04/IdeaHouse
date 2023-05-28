using IdeaHouse.Models;
using Microsoft.EntityFrameworkCore;

namespace IdeaHouse.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Idea> Ideas { get; set; }

      

    }
}
