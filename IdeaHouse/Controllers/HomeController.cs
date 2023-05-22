using IdeaHouse.Data;
using IdeaHouse.Interfaces;
using IdeaHouse.Models;
using IdeaHouse.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Diagnostics;

namespace IdeaHouse.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IIdeaRepository _ideaRepository;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ICategoryRepository categoryRepository,IIdeaRepository ideaRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
            _ideaRepository = ideaRepository;

        }

        public IActionResult Index()
        {
            return View();
        }

        //Creates A category successfully
        public IActionResult AddCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            _categoryRepository.Add(category);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> AddIdea()
        {
            var viewModel = new Idea
            {
                Categories = await _categoryRepository.GetAllCategories()
            };

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> AddIdea(Idea viewModel)
        {
            if (ModelState.IsValid)
            {
                var idea = new Idea
                {
                    Name = viewModel.Name,
                    Description = viewModel.Description,
                    Rating = viewModel.Rating,
                    Status = viewModel.Status,
                    Date = viewModel.Date,
                    CategoryId = viewModel.Category.Id,
                    Categories = viewModel.Categories,
                    
                };

                _ideaRepository.Add(idea);
                return RedirectToAction("Index"); // Redirect to home or any other page
            }

            var categories = await _categoryRepository.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            return View(viewModel);
        }



        public async Task<IActionResult> Categories() 
        {
            IEnumerable<Category> categories = await _categoryRepository.GetAllCategories();
            return View(categories);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}