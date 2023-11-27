using AMS23_BordaDourada.Data.Repository;
using AMS23_BordaDourada.Models.Interfaces;
using AMS23_Carousel.Models;
using Microsoft.AspNetCore.Mvc;

namespace AMS23_Carousel.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IActionResult> Index()
        {
            var allCategories = await _categoryRepository.GetAll();
            return View(allCategories);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryModel request)
        {
            _categoryRepository.Add(request);
            await _categoryRepository.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(Guid id)
        {
            CategoryModel category = _categoryRepository.Get(id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryModel request)
        {
            _categoryRepository.Update(request);
            await _categoryRepository.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Delete(Guid id)
        {
            var categoryToDelete = _categoryRepository.Get(id);
            _categoryRepository.Delete(categoryToDelete);
            await _categoryRepository.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}