using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gear.Models;
using Gear.ViewModels;


/// <summary>
/// Karolis Stončius
/// </summary>
namespace Gear.Controllers
{
    public class ProfileController : ControllerBase
    {
        public class loginFb
        {
            public string name { get; set; }
            public string surename { get; set; }
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<User> Users = db.Users.ToList();
            List<Game> Games = db.Games.ToList();
            string loggedUserName = (string)Session["Username"];
            User loggedUser = db.Users.Where(u => u.Username.Equals(loggedUserName)).FirstOrDefault();
            User usr = new User()
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

            List<Mark> marked = db.Marks.Where(m => m.User_Username.Equals(loggedUserName)).ToList();

            CountryViewModel model = new CountryViewModel()
            {
                Countries = db.Countries.ToList(),
                user = usr,
                marks = marked
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            string loggedUserName = (string)Session["Username"];
            User loggedUser = db.Users.Where(u => u.Username.Equals(loggedUserName)).FirstOrDefault();
            User usr = new User()
            {
                Username = loggedUser.Username,
                Password = loggedUser.Password,
                Name = loggedUser.Name,
                Surname = loggedUser.Surname,
                Email = loggedUser.Email,
                Birthday = loggedUser.Birthday,
                Country_Code = loggedUser.Country_Code,
            };
            CountryViewModel model = new CountryViewModel()
            {
                Countries = db.Countries.ToList(),
                user = usr
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(string username, string email, string name, string surename, DateTime birthday, string password, int country)
        {
            string loggedUserName = (string)Session["Username"];
            User loggedUser = db.Users.Where(usr => usr.Username.Equals(loggedUserName)).FirstOrDefault();
            //loggedUser.Username = username;
            if(password != "")
                loggedUser.Password = password;
            loggedUser.Email = email;
            loggedUser.Name = name;
            loggedUser.Surname = surename;
            loggedUser.Birthday = birthday;
            if(country != 0)
                loggedUser.Country_Code = country;
            db.SaveChanges();
            return RedirectToAction("Index", "Profile"); ;
        }

        public ActionResult Remove()
        {
            string loggedUserName = (string)Session["Username"];
            User loggedUser = db.Users.Where(usr => usr.Username.Equals(loggedUserName)).FirstOrDefault();
            db.Users.Remove(loggedUser);
            Session.Clear();
            db.SaveChanges();
            return RedirectToAction("Index", "Store"); ;
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
        public ActionResult Register(string username, string email, string password, string confirmPassword, string name, string surename, DateTime birthday, int country)
        {
            //Game g = db.Games.ToList().Where(game => game.Name == "Witcher").ToList()[0];
            //List<Genre> genres = g.Genres.ToList();
            //foreach (Genre gen in genres)
            //{
            //    string name = gen.Name;
            //}
            User user = new User()
            {
                Username = username,
                Password = password,
                Name = name,
                Surname = surename,
                Birthday = birthday,
                Email = email,
                Blocked = 0,
                Country_Code = country,
                Rank_Name = "User"
            };

            User temp = db.Users.Where(u => u.Username.Equals(username)).FirstOrDefault();
            if (temp == null)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login", "Profile"); ;
            }
            else
            {
                return RedirectToAction("Register", "Profile"); ;
            }
         
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
                    return RedirectToAction("Index", "Store"); ;
                } 
            }

            return RedirectToAction("Index", "Store");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            
            return RedirectToAction("Index","Store");
        }

        [HttpGet]
        public ActionResult LoginFB(JsonResult obj)
        {
            //string name = obj[0];
            //string surename = obj[1];

            //User user = db.Users.Where(u => u.Name.Equals(name) && u.Surname.Equals(surename)).FirstOrDefault();

            //if (user != null)
            //{

            //    Session["LoggedIn"] = true;
            //    Session["Username"] = user.Username;
            //    Session["Rank"] = user.Rank_Name;
            //    return RedirectToAction("Index", "Store"); ;
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Store"); ;
            //}
            return RedirectToAction("Index", "Store"); ;
        }
    }
}