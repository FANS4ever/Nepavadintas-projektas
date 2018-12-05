using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gear.Models;

/// <summary>
/// Domantas Banionis
/// </summary>
namespace Gear.Controllers
{
    public class StoreController : Controller
    {
        GearDBEntities db = new GearDBEntities();



        // GET: Store
        public ActionResult Index()
        {
            List<Game> tmp = db.Games.ToList();
            return View(tmp);
        }

        public ActionResult Search()
        {
            //var tmp = new Gear.ViewModels.StoreViewModel()
            //{
            //    Showcase = TemporarySet,
            //    Newest = TemporarySet,
            //    Pupular = TemporarySet,
            //    Discounted = TemporarySet,

            //};

           
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