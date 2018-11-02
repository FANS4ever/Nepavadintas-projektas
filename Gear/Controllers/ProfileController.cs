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
            var profile = new User()
            {
                Username = "Karolissto",
                Email = "ltkarolissto@gmail.com",
                Name = "Karolis",
                Surname = "Stončius",
                Avatar = "/Content/images/avatar.jpg"
            };
            return View(profile);
        }
    }
}