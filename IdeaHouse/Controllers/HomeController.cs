using IdeaHouse.Interfaces;
using IdeaHouse.Models;
using IdeaHouse.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Immutable;
using System.Diagnostics;

namespace IdeaHouse.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IIdeaRepository _ideaRepository;

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

        [HttpGet]
        public async Task<IActionResult> AddIdea()
        {
            var categories = await _categoryRepository.GetAllCategories();
            var viewModel = new IdeaViewModel();

            if (categories != null)
            {
                viewModel.Categories = categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                });
            }
            else
            {
                viewModel.Categories = Enumerable.Empty<SelectListItem>();
            }

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> AddIdea(IdeaViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = (await _categoryRepository.GetAllCategories())
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    });
                return View(viewModel);
            }

            var idea = new Idea
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                Rating = viewModel.Rating,
                Status = viewModel.Status,
                Date = viewModel.Date,
                CategoryId = viewModel.CategoryId,
               // Categories = viewModel.Categories
            };

            _ideaRepository.Add(idea);

            return RedirectToAction("Index", "Home");
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