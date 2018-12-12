using Gear.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

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

        public ActionResult Edit(int id)
        {
            Game game = db.Games.Where(x => x.Id == id).ToList()[0];
            return View(@"~/Views/Creator/Edit.cshtml", game);
        }
        [HttpPost]
        public ActionResult Edit(string id, string messageShort, string message, HttpPostedFileBase pic, string trailer, string version, string numberV, string genre, string age, DateTime date, HttpPostedFileBase file, string price)
        {
            string loggedUserName = (string)Session["Username"];
            Developer developer = db.Developers.Where(x => x.Users.Any(y => y.Username.Contains(loggedUserName))).ToList()[0];
             int ids = int.Parse(id);
            Game game = db.Games.Where(x => x.Id ==ids).FirstOrDefault();
            String gamename = game.Name;
            if (pic != null)
            {
                var fileName = Path.GetFileName(pic.FileName);
                string[] values = fileName.Split('.');
                string temp = values[1];
                var path = Path.Combine(Server.MapPath("~/Files/" + gamename), "icon." + temp);
                Directory.CreateDirectory(Server.MapPath("~/Files/" + gamename));
                file.SaveAs(path);

            }
           
            


            game.Name = gamename;
            game.Description = message;
            game.ShortDescription = messageShort;
            game.TrailerURL = trailer;
            game.Price = double.Parse(price);
            game.VersionBranch = version;
            game.VersionNumber = int.Parse(numberV);
            game.Dir = gamename;
            game.Available = (sbyte)1;
            game.ReleaseDate = date;
            game.AgeRestriction = int.Parse(age);


            db.SaveChanges();
            return RedirectToAction("Index");
        }
            public ActionResult Statistics(int id)
        {
            Game game = db.Games.Where(x => x.Id == id).FirstOrDefault();

            List<Visit> visits = game.Visits.ToList();
            List<DataPoint> dataPoints = new List<DataPoint>();

            int num = 0;

            foreach (Visit item in visits)
            {
                dataPoints.Add(new DataPoint(num++,item.Amount));
            }

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

         

            return View(@"~/Views/Creator/Statistics.cshtml");
        }
        public ActionResult Create()
        {
            return View(@"~/Views/Creator/Create.cshtml");
        }

        [HttpPost]
        public ActionResult Create(string gamename, string messageShort, string message, HttpPostedFileBase pic, string trailer, string version, string numberV,string genre, string age, DateTime date, HttpPostedFileBase file, string price)
        {
            string loggedUserName = (string)Session["Username"];
            Developer developer = db.Developers.Where(x => x.Users.Any(y => y.Username.Contains(loggedUserName))).ToList()[0];

            if (pic != null)
            {
                var fileName = Path.GetFileName(pic.FileName);
                string[] values = fileName.Split('.');
                string temp = values[1];
                var path = Path.Combine(Server.MapPath("~/Files/" + gamename), "icon." +temp);
                Directory.CreateDirectory(Server.MapPath("~/Files/" + gamename));
                file.SaveAs(path);
                
            }

            Game addGame = new Game()
            {
                Name = gamename,
                Description = message,
                ShortDescription = messageShort,
                TrailerURL = trailer,
                Price = double.Parse(price),
                VersionBranch = version,
                VersionNumber = int.Parse(numberV),
                Dir = gamename,
                Available = (sbyte)1,
                ReleaseDate = date,
                AgeRestriction = int.Parse(age)
                
            };
            addGame.Developer_Id = developer.Id;
            db.Games.Add(addGame);
            db.SaveChanges();
            return RedirectToAction("Index");
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