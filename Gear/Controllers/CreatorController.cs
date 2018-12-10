using Gear.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


/// <summary>
/// Gabrielius Ulejevas
/// </summary>
namespace Gear.Controllers
{
    public class CreatorController : ControllerBase
    {
        
        // GET: CreatorPage
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View(@"~/Views/Creator/Edit.cshtml");
        }
        public ActionResult Statistics()
        {
            double count = 1000, y = 100;
            Random random = new Random();
            //List<DataPoint> dataPoints = new List<DataPoint>();

            for (int i = 0; i < count; i++)
            {
                y += random.Next(-10, 11);
                //dataPoints.Add(new DataPoint(i, y));
            }

            //ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View(@"~/Views/Creator/Statistics.cshtml");
        }
        public ActionResult Create()
        {
            return View(@"~/Views/Creator/Create.cshtml");
        }

        [HttpPost]
        public ActionResult Create(string gamename, string message, HttpPostedFileBase pic, string trailer, string version,string genre, string age, string date, HttpPostedFileBase file, string price)
        {

            return View(@"~/Views/Creator/Create.cshtml");
        }
        public ActionResult BecomingCreator()
        {
            return View(@"~/Views/Creator/BecomingCreator.cshtml");
        }

        [HttpPost]
        public ActionResult BecomingCreator(string name, string website)
        {
            //Changes users status to Creator
            var user = Session["User"] as User;
            User userInfo = db.Users.Where(s=>s.Username == user.Username).FirstOrDefault();
            if (userInfo != null)
            {
                userInfo.Rank_Name = "Creator";
                var dev= db.Developers.Add(new Developer()
            {
                Name = name,
                Website = website
            }
            );
                dev.Users.Add(userInfo);
            }

            db.SaveChanges();
            var connection = db.Developers.Where(x => x.Users.Any(r => userInfo.Username.Contains(r.Username)));
            return Content(connection.ToList()[0].Id.ToString());
        }
    }
}