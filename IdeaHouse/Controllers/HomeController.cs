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

        public HomeController(ILogger<HomeController> logger, ICategoryRepository categoryRepository, IIdeaRepository ideaRepository)
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

        public async Task<IActionResult> Delete(int id)
        {
            Idea idea = await _ideaRepository.FindAsync(id);

            if (idea != null)
            {
                _ideaRepository.Delete(idea);
                return RedirectToAction("Ideas"); // Redirect to the Index action or any other desired action
            }

            return RedirectToAction("Not Found"); // Redirect to the Index action or any other desired action
        }


        [HttpGet]
        public async Task<IActionResult> IdeaDetail(int id)
        {
            Idea idea = await _ideaRepository.GetIdeaById(id);

            return View(idea);
        }



        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var idea = await _ideaRepository.FindAsync(id);

            if (idea == null)
            {
                return RedirectToAction("NotFound"); // Redirect to a "not found" action or error page
            }

            var allCategories = await _categoryRepository.GetAllCategories();
            var categoryList = allCategories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            var viewModel = new Idea
            {
                Id = idea.Id,
                Name = idea.Name,
                Description = idea.Description,
                Status = idea.Status,
                Date = idea.Date,
                Rating = idea.Rating,
                CategoryId = idea.CategoryId,
                CategoryList = categoryList
            };

            ViewData["CategoryList"] = categoryList; // Pass the categoryList to ViewData

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Update(Idea viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var idea = await _ideaRepository.FindAsync(viewModel.Id);

            if (idea == null)
            {
                return RedirectToAction("NotFound"); // Redirect to a "not found" action or error page
            }

            idea.Name = viewModel.Name;
            idea.Description = viewModel.Description;
            idea.Status = viewModel.Status;
            idea.Date = viewModel.Date;
            idea.Rating = viewModel.Rating;
            idea.CategoryId = viewModel.CategoryId;

            _ideaRepository.Update(idea);

            return RedirectToAction("Index"); // Redirect to the appropriate action after the update
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