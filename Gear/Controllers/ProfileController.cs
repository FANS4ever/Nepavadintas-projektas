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
                //Avatar = "/Content/images/Avatars/avatar.jpg"
        //    };
        //    return profile;
        //}
        //public List<Game> GetGames()
        //{
        //    List<Game> games = new List<Game>();
            //games.Add(new Game() { Name = "Civilization V", Id = 1, Description = "Turn-Based Strategy", ReleaseTime = new DateTime(2010,09,23), Icon = "/Content/images/GameIcons/Civ5.jpg" });
            //games.Add(new Game() { Name = "Arma 3", Id = 2, Description = "Simulation, FPS", ReleaseTime = new DateTime(2013, 09, 12), Icon = "/Content/images/GameIcons/Arma3.jpg" });
            //games.Add(new Game() { Name = "Team Fortress 2", Id = 3, Description = "Multiplayer, FPS", ReleaseTime = new DateTime(2007, 10, 10), Icon = "/Content/images/GameIcons/TeamFortress2.jpg" });
            //games.Add(new Game() { Name = "Warframe", Id = 4, Description = "Action", ReleaseTime = new DateTime(2013, 03, 25), Icon = "/Content/images/GameIcons/Warframe.jpg" });
            //games.Add(new Game() { Name = "Counter-strike: Global Offensive", Id = 5, Description = "FPS", ReleaseTime = new DateTime(2012, 08, 21), Icon = "/Content/images/GameIcons/CSGO.jpg" });
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