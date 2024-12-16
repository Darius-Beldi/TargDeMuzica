using Microsoft.AspNetCore.Mvc;
using TargDeMuzica.Data;
using TargDeMuzica.Models;

namespace TargDeMuzica.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly ApplicationDbContext db;


        public ReviewsController(ApplicationDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            if (TempData.ContainsKey("message"))
            {
                ViewBag.message = TempData["message"].ToString();
            }
            var reviews = from review in db.Reviews
                          orderby review.ReviewContent
                          select review;

            ViewBag.Reviews = reviews;
            return View();
        }
        public ActionResult Show(int id)
        {
            Review review = db.Reviews.Find(id);
            return View(review);
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(Review rev)
        {


            rev.ReviewDate = DateTime.Now;

            try
            {
                db.Reviews.Add(rev);
                db.SaveChanges();
                TempData["message"] = "Review-ul a fost adaugat";
                return RedirectToAction("Index");
            }

            catch (Exception e)
            {
                return View(rev);
            }
        }

        public ActionResult Edit(int id)
        {
            Review review = db.Reviews.Find(id);
            return View(review);
        }

        [HttpPost]
        public ActionResult Edit(int id, Review requestReview)
        {
            Review review = db.Reviews.Find(id);

            try
            {

                review.ReviewContent = requestReview.ReviewContent;
                review.ReviewDate = requestReview.ReviewDate;
                review.StarRating = requestReview.StarRating;

                db.SaveChanges();
                TempData["message"] = "Comentariul a fost adugat cu succes!!";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(requestReview);
            }
        }

        public ActionResult Delete(int id)
        {
           Review review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
            db.SaveChanges();
            TempData["message"] = "Review-ul a fost sters";
            return RedirectToAction("Index");
        }
    }
}
