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
    public class ProfileController : Controller
    {
        //IList<User> userList = new List<User>()
        //{
        //    new User(){Username = "Karolissto",
        //        Email = "ltkarolissto@gmail.com",
        //        Name = "Karolis",
        //        Surname = "Stončius",
        //        Avatar = "/Content/images/avatar.jpg"}
        //};
        //// GET: Profile
        //public ActionResult Index()
        //{
        //    UserGame UG = new UserGame();
        //    UG.user = GetUser();
        //    UG.games = GetGames();
        //    return View(UG);
        //}

        //public ActionResult Edit()
        //{
        //    UserGame UG = new UserGame();
        //    UG.user = GetUser();
        //    UG.games = GetGames();
        //    UG.country = new Country() { };          
        //    return View(UG);
        //}

        //public ActionResult ChatRoom()
        //{
        //    Message M = new Message();
        //    M.messages = GetMessage();
        //    return View(M);
        //}

        //[HttpPost]
        //public ActionResult Edit(UserGame UG)
        //{
        //    return RedirectToAction("Index");
        //}

        //public List<Message> GetMessage()
        //{
        //    List<Message> messages = new List<Message>();
        //    messages.Add(new Message() { Id = 1, Contents = "Laba diena", SendDate = DateTime.Now });
        //    messages.Add(new Message() { Id = 2, Contents = "Kaip sekasi?", SendDate = DateTime.Now });
        //    messages.Add(new Message() { Id = 3, Contents = "Ka veiki?", SendDate = DateTime.Now });
        //    messages.Add(new Message() { Id = 4, Contents = "Sumetam cs matcha?", SendDate = DateTime.Now });
        //    messages.Add(new Message() { Id = 5, Contents = "Noobas", SendDate = DateTime.Now });
        //    return messages;
        //}

        //public User GetUser()
        //{
        //    var profile = new User()
        //    {
        //        Username = "Karolissto",
        //        Email = "ltkarolissto@gmail.com",
        //        Name = "Karolis",
        //        Surname = "Stončius",
        //        Avatar = "/Content/images/avatar.jpg"
        //    };
        //    return profile;
        //}
        //public List<Game> GetGames()
        //{
        //    List<Game> games = new List<Game>();
        //    games.Add(new Game() { Name = "Civilization V", Id = 1, Description = "2018-10-05"});
        //    games.Add(new Game() { Name = "Arma 3", Id = 2, Description = "2018-11-01"});
        //    games.Add(new Game() { Name = "Team Fortress", Id = 3, Description = "2018-05-15"});
        //    games.Add(new Game() { Name = "Warframe", Id = 4, Description = "2018-10-03"});
        //    games.Add(new Game() { Name = "CSGO", Id = 5, Description = "2018-09-24"});
        //    return games;
        //}

        //public class ViewModel
        //{
        //    public IEnumerable<User> Users { get; set; }
        //    public IEnumerable<Game> Games { get; set; }
        //}

        //public ActionResult Register()
        //{
        //    return View();
        //}

        //public ActionResult Login()
        //{
        //    return View();
        //}
    }
}