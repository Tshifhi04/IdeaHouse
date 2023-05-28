using IdeaHouse.Data.Enum;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public Status Status { get; set; }
        public DateTime Date { get; set; }

       [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }


        //public string? CategoryName { get; set; }
        //public string? CategoryDescription { get; set; }



        [NotMapped]
        public IEnumerable<SelectListItem>? CategoryList { get; set; }

    }

}
