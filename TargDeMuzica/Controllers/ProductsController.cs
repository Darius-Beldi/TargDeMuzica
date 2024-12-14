using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TargDeMuzica.Data;
using TargDeMuzica.Models;

namespace TargDeMuzica.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext db;

        public ProductsController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var products = db.Products;
            ViewBag.Products = products;
            return View();
        }


        public IActionResult Show(int id)
        {

            Product product = db.Products.Include("Artists")
                                         .Include("Reviews")
                                         .Include("MusicSuports")
                              .Where(product => product.ProductID == id)
                              .First();
            return View(product);
        }
    }
}
