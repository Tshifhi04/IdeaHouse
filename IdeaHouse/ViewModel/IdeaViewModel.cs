using IdeaHouse.Data.Enum;
using IdeaHouse.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdeaHouse.ViewModel
{
    public class IdeaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the name of the idea.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the description of the idea.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter the rating of the idea.")]
        public string Rating { get; set; }

        [Required(ErrorMessage = "Please enter the status of the idea.")]
        public Status Status { get; set; }

        [Required(ErrorMessage = "Please enter the date of the idea.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }

}
