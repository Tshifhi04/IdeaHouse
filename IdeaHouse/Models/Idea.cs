using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdeaHouse.Models
{   
    public class Idea
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Rating { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
       public  IEnumerable<Category>? Categories { get; set; }

    }

}
