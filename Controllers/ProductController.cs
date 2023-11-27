using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AMS23_BordaDourada.Models;
using AMS23_BordaDourada.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AMS23_Carousel.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [Route("Product")]
        public async Task<IActionResult> Index()
        {
            var allProducts = await _productRepository.GetAll();
            return View(allProducts);
        }
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductModel request)
        {
            _productRepository.Add(request);
            await _productRepository.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        [Route("Edit")]
        public IActionResult Edit(Guid id)
        {
            ProductModel product = _productRepository.Get(id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductModel request)
        {
            _productRepository.Update(request);
            await _productRepository.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var productToDelete = _productRepository.Get(id);
            _productRepository.Delete(productToDelete);
            await _productRepository.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}