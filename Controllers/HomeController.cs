﻿using ePharma_asp_mvc.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ePharma_asp_mvc.Controllers
{
    public class HomeController : Controller
    {

        private readonly IProductsService _service;

        public HomeController(IProductsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        public async Task<IActionResult> Shop()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        public async Task<IActionResult> Search(string searchString)
        {
            var data = await _service.Search(searchString);
            return View("Shop", data);
        }

        public async Task<IActionResult> Sort(string order)
        {
            var data = await _service.Sort(order);
            return View("Shop", data);
        }

        public async Task<IActionResult> SingleProduct(int id)
        {
            var data = await _service.GetByID(id);
            return View(data);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
