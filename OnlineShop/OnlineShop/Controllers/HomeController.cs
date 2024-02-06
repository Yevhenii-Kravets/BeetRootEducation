using Microsoft.AspNetCore.Mvc;
using OnlineShop.Context;
using OnlineShop.Models;
using System.Diagnostics;
using System.Globalization;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly OnlineShopDbContext _products;

        public HomeController(ILogger<HomeController> logger, OnlineShopDbContext products)
        {
            _logger = logger;
            _products = products;
        }

        public IActionResult Index()
        {
            var model = new OnlineShopModel();
            model.Products = _products.Products.ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Item product, string Price)
        {
            var number = Price.Replace(".", ",");
            decimal.TryParse(number, out decimal trueDecimal);
            product.Price = trueDecimal;

            var model = new OnlineShopModel();
            _products.Products.Add(product);
            _products.SaveChanges();

            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
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