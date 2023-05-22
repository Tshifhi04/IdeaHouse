using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace IdeaHouse.ViewModel
{
    public class IdeaViewModel
    {
        [Required(ErrorMessage = "Please enter the name of the idea.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the description of the idea.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter the rating of the idea.")]
        public string Rating { get; set; }

        [Required(ErrorMessage = "Please enter the status of the idea.")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Please enter the date of the idea.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        public int CategoryId { get; set; }

    }
}
