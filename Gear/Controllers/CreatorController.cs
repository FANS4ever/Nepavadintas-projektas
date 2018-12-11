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
            Developer developer = null;
            List<Game> games = new List<Game>();
            string loggedUserName = (string)Session["Username"];
            if ((bool)Session["LoggedIn"])
            {
               developer = db.Developers.Where(x => x.Users.Any(y => y.Username.Contains(loggedUserName))).ToList()[0];
               games = db.Games.Where(x => x.Developer_Id == developer.Id).ToList();
            }
             

            return View(games);
        }
        public ActionResult Remove(int id) {

            Game game = db.Games.Where(x => x.Id == id).ToList()[0];
            db.Games.Remove(game);
            db.SaveChanges();
            return RedirectToAction("Index");
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
        public ActionResult Create(string gamename, string message, string pic, string trailer, string version,string genre, string age, DateTime date, HttpPostedFileBase file, string price)
        {
            string loggedUserName = (string)Session["Username"];
            Developer developer = db.Developers.Where(x => x.Users.Any(y => y.Username.Contains(loggedUserName))).ToList()[0];

            Game addGame = new Game()
            {
                Name = gamename,
                Description = message,
                ShortDescription = "ner",
                TrailerURL = trailer,
                Price = double.Parse(price),
                VersionBranch = version,
                VersionNumber = 1.0,
                Dir = pic,
                Available = (sbyte)1,
                ReleaseDate = date,
                AgeRestriction = int.Parse(age)
                
            };
            addGame.Developer_Id = developer.Id;
            db.Games.Add(addGame);
            db.SaveChanges();
            return View();
    }
        public ActionResult BecomingCreator()
        {
            return View(@"~/Views/Creator/BecomingCreator.cshtml");
        }

        [HttpPost]
        public ActionResult BecomingCreator(string name, string website)
        {
            //Changes users status to Creator
            var username = (string)Session["Username"];
            User userInfo = db.Users.Where(s=>s.Username == username).FirstOrDefault();
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
            return RedirectToAction("Index");
        }
    }
}