using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gear.Models;


/// <summary>
/// Karolis Stončius
/// </summary>
namespace Gear.Controllers
{
    public class ProfileController : ControllerBase
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<User> Users = db.Users.ToList();
            List<Game> Games = db.Games.ToList();
            User loggedUser = Session["User"] as User;

            User user = new User()
            {
                Username = loggedUser.Username,
                Password = loggedUser.Password,
                Name = loggedUser.Name,
                Surname = loggedUser.Surname,
                Email = loggedUser.Email,
                Birthday = loggedUser.Birthday,
                Blocked = loggedUser.Blocked,
                Country_Code = loggedUser.Country_Code,
                Rank_Name = loggedUser.Rank_Name,
                LibraryGames = loggedUser.LibraryGames.ToList(),
            };
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(string password, string email, string name, string surename)
        {
            User loggedUser = Session["User"] as User;
            var currUser = db.Users.SingleOrDefault(usr => usr.Username.Equals(loggedUser.Username));
            //currUser.Username = username;
            currUser.Password = password;
            currUser.Email = email;
            currUser.Name = name;
            currUser.Surname = surename;
            //currUser.Birthday = birthday;
            db.SaveChanges();
            return View();
        }

        public ActionResult ChatRoom()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Register()
        {
            List<Country> model = db.Countries.ToList();
            return View(model);
        }

       [HttpPost]
        public ActionResult Register(string username, string email, string password, string confirmPassword, int country)
        {
            //Game g = db.Games.ToList().Where(game => game.Name == "Witcher").ToList()[0];
            //List<Genre> genres = g.Genres.ToList();
            //foreach (Genre gen in genres)
            //{
            //    string name = gen.Name;
            //}


            db.Users.Add(new User()
            {
                Username = username,
                Password = password,
                Email = email,
                Blocked = 0,
                Country_Code = country,
                Rank_Name = "User"
            });
            db.SaveChanges();

            return Content("Good");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            User user = db.Users.Where(u => u.Username.Equals(username)).FirstOrDefault();

            if (user != null)
            {
                //Hash here
                password = password;

                if (user.Password == password)
                {
                    Session["LoggedIn"] = true;
                    Session["Username"] = user.Username;
                    Session["Rank"] = user.Rank_Name;
                } 
            }

            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index","Store"); ;
        }
    }
}