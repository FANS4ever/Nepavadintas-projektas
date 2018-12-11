using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gear.Models;
using Gear.ViewModels;

/// <summary>
/// Domantas Banionis
/// </summary>
namespace Gear.Controllers
{
    public class StoreController : ControllerBase
    {
        // GET: Store
        public ActionResult Index()
        {
            DateTime now = DateTime.Now;

            List<Game> popular = db.Games.OrderByDescending(
                    g => g.Visits.Where(v => v.Game_Id == g.Id)
                    .Sum(x => x.Amount)).Take(10).ToList();
            List<Game> newest = db.Games.Where(
                    g => g.ReleaseDate < now)
                    .OrderByDescending(g => g.ReleaseDate).Take(10).ToList();
            List<Discount> discounted = db.Discounts.Where(
                    d => d.ExpireDate > now).Where(d => d.Hidden != 1).Take(10).ToList();

            Random rand = new Random();
            List<Game> showcase = db.Games.OrderByDescending(
                    g => g.GameRatings.Where(r => r.Game_Id == g.Id)
                    .Sum(x => x.Rating)).Take(6).ToList();

            string user = (string)Session["Username"];
            Cart cart = (bool)Session["LoggedIn"] == true ? db.Carts.Where(c => c.User_Username.Equals(user)).Where(c => c.Receipts.Count == 0).FirstOrDefault() : null;

            StoreViewModel model = new StoreViewModel()
            {
                Popular = popular,
                Discounted = discounted,
                Newest = newest,
                Showcase = showcase,
                Cart = cart
            };
            return View(model);
        }

        public ActionResult Search(string search, string tag)
        {
            search = search == null ? "" : search;

            List<Game> show = db.Games.Where(g => g.Name.Contains(search)).OrderBy(g=>g.Name).ToList();
            List<Genre> genre = db.Genres.ToList();

            string user = (string)Session["Username"];
            Cart cart = (bool)Session["LoggedIn"] == true ? db.Carts.Where(c => c.User_Username.Equals(user)).Where(c => c.Receipts.Count == 0).FirstOrDefault() : null;

            if (tag != null)
            {
                show = show.Where(s=>s.Genres.Where(g=>g.Name == tag).FirstOrDefault() != null).ToList();
            }


            SearchViewModel model = new SearchViewModel() {
                View = show,
                Cart = cart,
                Tags = genre,
                Selected = tag,
                Search = search
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult Payment()
        {
            string user = (string)Session["Username"];
            Cart cart = db.Carts.Where(c => c.User_Username.Equals(user)).Where(c => c.Receipts.Count == 0).FirstOrDefault();

            return View(cart);
        }

        public ActionResult Receipt()
        {
            return View();
        }

        public ActionResult RemoveFromCart(int id)
        {
            CartItem item = db.CartItems.Where(c => c.Id == id).SingleOrDefault();
            db.CartItems.Remove(item);
            db.SaveChanges();

            return RedirectToAction("Payment");
        }

        public ActionResult ChangeCartItemAmount(int id, int amount)
        {
            if (amount <= 0)
            {
                return RedirectToAction("RemoveFromCart",new { id = id });
            }
            CartItem item = db.CartItems.Where(c => c.Id == id).SingleOrDefault();

            if (item.Amount == amount)
            {
                return RedirectToAction("Payment");
            }

            item.Amount = amount;
            db.SaveChanges();

            return RedirectToAction("Payment");
        }
    }
}