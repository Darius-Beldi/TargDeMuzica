using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;
using System.Composition;
using System.Drawing.Printing;
using TargDeMuzica.Data;
using TargDeMuzica.Models;
using static TargDeMuzica.Models.IncomingRequest;

namespace TargDeMuzica.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ProductsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
                                    RoleManager<IdentityRole> roleManager)
        {
            db = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        
        public IActionResult Index()
        {
            if (TempData.ContainsKey("message"))
            {
                ViewBag.message = TempData["message"].ToString();
            }
            var products = from product in db.Products
                          orderby product.ProductName
                          select product;

            ViewBag.Products = products;
            return View();
        }








        public ActionResult Show(int id)
        {

            Product product = db.Products
                .Include(p => p.Reviews)
                .Include(p => p.MusicSuport)
                .Include(p => p.Artist)
                .FirstOrDefault(p => p.ProductID == id);

            if (product != null && product.Reviews != null && product.Reviews.Any())
            {
                // Calculate average star rating
                product.ProductScore = (float)product.Reviews.Average(r => r.StarRating);
                db.SaveChanges();  // Save the updated score to the database
            }

            return View(product);
        }


        [NonAction]
        public IEnumerable<SelectListItem> GetAllMusicSup()
        {
            // generam o lista de tipul SelectListItem fara elemente

            var selectList = new List<SelectListItem>();

            // extragem toate categoriile din baza de date
            var sup = from su in db.MusicSuports
                             select su;

            // iteram prin categorii
            foreach (var su in sup)
            {
                selectList.Add(new SelectListItem
                {
                    Value = su.MusicSuportID.ToString(),
                    Text = su.MusicSuportName
                });
            }

            return selectList;
        }
        [NonAction]
        public IEnumerable<SelectListItem> GetAllArtists()
        {
            // generam o lista de tipul SelectListItem fara elemente

            var selectList = new List<SelectListItem>();

            // extragem toate categoriile din baza de date
            var artist = from art in db.Artists
                      select art;

            // iteram prin categorii
            foreach (var art in artist)
            {
                selectList.Add(new SelectListItem
                {
                    Value = art.ArtistID.ToString(),
                    Text = art.ArtistName
                });
            }

            return selectList;
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult New()
        {
            Product produs = new Product();
            produs.MusicSup = GetAllMusicSup();
            produs.ArtistList = GetAllArtists();
            return View(produs);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult New(Product prod)
        {

            
            // rev.ReviewDate = DateTime.Now;

            try
            {
                prod.ProductGenres = prod.ProductGenresTemp.Split(' ').ToList();
                db.Products.Add(prod);
                db.SaveChanges();
                TempData["message"] = "Review-ul a fost adaugat";
                return RedirectToAction("Index");
            }

            catch (Exception e)
            {
                prod.MusicSup = GetAllMusicSup();
                prod.ArtistList = GetAllArtists();
                return View(prod);
            }

        }
        [Authorize(Roles = "Colaborator,Administrator")]
        public ActionResult Edit(int id)
        {
            Product prod = db.Products.Find(id);
            return View(prod);
        }

        [Authorize(Roles = "Colaborator,Administrator")]
        [HttpPost]
        public ActionResult Edit(int id, Product requestProd)
        {
            Product prod = db.Products.Find(id);

            try
            {

                prod.ProductName = requestProd.ProductName;
                prod.ProductDescription = requestProd.ProductDescription;
                prod.MusicSuportID = requestProd.MusicSuportID;
                prod.ProductPrice = requestProd.ProductPrice;
                prod.ProductStock = requestProd.ProductStock;
                prod.ProductImageLocation = requestProd.ProductImageLocation;
                prod.ProductScore = requestProd.ProductScore;
                prod.ProductGenres = requestProd.ProductGenres;
                prod.ArtistID = requestProd.ArtistID;
                prod.Carts = requestProd.Carts;
                prod.Reviews = requestProd.Reviews;
                prod.User = requestProd.User;

                //de trimis in incomingrequests si sa fie de acolo bagat in
                //baza de date ce am facut mai sus

                db.SaveChanges();
                TempData["message"] = "Produsul a fost editat cu succes";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(requestProd);
            }
        }

        [Authorize(Roles = "Colaborator,Administrator")]
        public ActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            TempData["message"] = "Produsul a fost sters";
            return RedirectToAction("Index");
        }
        // Modified ProductsController.cs - New method
        [Authorize(Roles = "Colaborator,Administrator")]
        public ActionResult Submit()
        {
            Product product = new Product();
            product.MusicSup = GetAllMusicSup();
            product.ArtistList = GetAllArtists();
            return View(product);
        }

        [Authorize(Roles = "Colaborator,Administrator")]
        [HttpPost]
        public async Task<ActionResult> Submit(Product product)
        {
            if (!ModelState.IsValid)
            {
                product.MusicSup = GetAllMusicSup();
                product.ArtistList = GetAllArtists();
                return View(product);
            }
            // Instead of redirecting with the product, we'll handle the submission right here
            var user = await _userManager.GetUserAsync(User);

            // Process the genres if provided
            if (!string.IsNullOrEmpty(product.ProductGenresTemp))
            {
                product.ProductGenres = product.ProductGenresTemp.Split(' ').ToList();
            }

            // Create the incoming request
            var request = new IncomingRequest
            {
                RequestDate = DateTime.Now,
                Status = RequestStatus.Pending,
                ProposedProduct = product,
                User = user
            };

            // Add to database
            db.IncomingRequests.Add(request);
            await db.SaveChangesAsync();

            TempData["message"] = "Your product has been submitted for review. An administrator will review it shortly.";
            return RedirectToAction("Index", "Products");
        }
    }
}
