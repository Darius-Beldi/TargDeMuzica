using Microsoft.AspNetCore.Mvc;
using TargDeMuzica.Data;
using TargDeMuzica.Models;

namespace TargDeMuzica.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly ApplicationDbContext db;
      

        public ArtistsController(ApplicationDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            if (TempData.ContainsKey("message"))
            {
                ViewBag.message = TempData["message"].ToString();
            }
            var artists = from artist in db.Artists
                             orderby artist.ArtistName
                             select artist;

            ViewBag.Artists = artists;
            return View();
        }
        public ActionResult Show(int id)
        {
            Artist artist = db.Artists.Find(id);
            return View(artist);
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(Artist art)
        {
            try
            {
                db.Artists.Add(art);
                db.SaveChanges();
                TempData["message"] = "Artistul a fost adaugat";
                return RedirectToAction("Index");
            }

            catch (Exception e)
            {
                return View(art);
            }
        }

        public ActionResult Edit(int id)
        {
            Artist artist = db.Artists.Find(id);
            return View(artist);
        }

        [HttpPost]
        public ActionResult Edit(int id, Artist requestArtist)
        {
            Artist artist = db.Artists.Find(id);

            try
            {

                artist.ArtistName = requestArtist.ArtistName;
                db.SaveChanges();
                TempData["message"] = "Artistul a fost adaugat cu succes!";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(requestArtist);
            }
        }

        public ActionResult Delete(int id)
        {
            Artist artist = db.Artists.Find(id);
            db.Artists.Remove(artist);
            db.SaveChanges();
            TempData["message"] = "Artistul a fost sters";
            return RedirectToAction("Index");
        }
    }
}
