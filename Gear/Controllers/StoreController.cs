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
                    .Sum(x => x.Rating)).Take(3).ToList();

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


        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            string[] spl = search.Split(',');

            List<Game> show = new List<Game>();

            if (spl.Count() == 1)
            {
                show = db.Games.Where(g=>g.Name.Contains(search)).ToList();
            }


            return View(show);
        }

        public ActionResult Payment()
        {
            return View();
        }

        public ActionResult Receipt()
        {
            return View();
        }
    }
}