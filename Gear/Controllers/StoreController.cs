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
            DateTime from = DateTime.Now.AddMonths(-1);
            StoreViewModel model = new StoreViewModel()
            {
                Showcase = db.Games.ToList(),
                Discounted = db.Discounts.Where(d => d.ExpireDate > DateTime.Now).ToList(),
                Newest = db.Games.Where(g => g.ReleaseDate >= from).ToList()

            };
            return View(model);
        }

        public ActionResult Search()
        {
            return View();
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