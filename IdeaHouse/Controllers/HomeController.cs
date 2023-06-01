using IdeaHouse.Data;
using IdeaHouse.Data.Enum;
using IdeaHouse.Interfaces;
using IdeaHouse.Models;
using IdeaHouse.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
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

        [ Route("Home/IdeaDetail/{id}")]
        public async Task<IActionResult> IdeaDetail(int id)
        {
            var idea = _ideaRepository.GetIdeaById(id);
            if (idea == null)
            {
                return NotFound(); // Or handle the case when the idea is not found
            }

            return View(idea);
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

        [HttpGet]
        public async Task<IActionResult> AddIdea()
        {
            var categories = await _categoryRepository.GetAllCategories();
            var categoryList = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            });

            var idea = new Idea
            {
                CategoryList = categoryList
            };

            return View(idea);
        }


        [HttpPost]
        public async Task<IActionResult> AddIdea(Idea viewModel)
        {
            if (ModelState.IsValid)
            {


                var idea = new Idea
                {
                    Id = viewModel.Id,
                    Name = viewModel.Name,
                    Description = viewModel.Description,
                    Rating = viewModel.Rating,
                    Status = viewModel.Status,
                    Date = viewModel.Date,
                    CategoryId = viewModel.CategoryId,
                   CategoryList = viewModel.CategoryList,
                    Category = await _categoryRepository.GetCategoryById(viewModel.CategoryId),
                      


                };



                _ideaRepository.Add(idea);
                return RedirectToAction("ideas"); // Redirect to home or any other page
            }

            var allCategories = await _categoryRepository.GetAllCategories();
            viewModel.CategoryList = new SelectList(allCategories, "Id", "Name");

            return View(viewModel);
        }


        public async Task<IActionResult> Ideas()
        {
            var ideasWithCategories = await _ideaRepository.GetAllIdeasWithCategories();

            var ideaViewModels = ideasWithCategories.Select(idea => new IdeaViewModel
            {
                Id = idea.Id,
                Name = idea.Name,
                Description = idea.Description,
                Rating = idea.Rating,
                Status = idea.Status,
                Date = idea.Date,
                CategoryId = idea.CategoryId,
                CategoryName = idea.Category?.Name,
                CategoryDescription = idea.Category?.Description
            }).ToList();

            return View(ideaViewModels);
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