using Microsoft.AspNetCore.Mvc;

namespace TargDeMuzica.Controllers
{
    public class ReviewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
