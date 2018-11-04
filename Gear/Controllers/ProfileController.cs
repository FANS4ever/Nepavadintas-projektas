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
        // GET: Profile
        public ActionResult Index()
        {
            UserGame UG = new UserGame();
            UG.user = GetUser();
            UG.games = GetGames();
            return View(UG);
        }

        public User GetUser()
        {
            var profile = new User()
            {
                Username = "Karolissto",
                Email = "ltkarolissto@gmail.com",
                Name = "Karolis",
                Surname = "Stončius",
                Avatar = "/Content/images/avatar.jpg"
            };
            return profile;
        }
        public List<Game> GetGames()
        {
            List<Game> games = new List<Game>();
            games.Add(new Game() { Name = "Civilization V", Id = 1, Description = "2018-10-05", Icon = "25"});
            games.Add(new Game() { Name = "Arma 3", Id = 2, Description = "2018-11-01", Icon = "105" });
            games.Add(new Game() { Name = "Team Fortress", Id = 3, Description = "2018-05-15", Icon = "54" });
            games.Add(new Game() { Name = "Warframe", Id = 4, Description = "2018-10-03", Icon = "12" });
            games.Add(new Game() { Name = "CSGO", Id = 5, Description = "2018-09-24", Icon = "2" });
            return games;
        }

        public class ViewModel
        {
            public IEnumerable<User> Users { get; set; }
            public IEnumerable<Game> Games { get; set; }
        }
    }

   

    
}