using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gear.Models;


/// <summary>
/// Tadas Kalvaitis
/// </summary>
namespace Gear.Controllers
{
    public class GameController : Controller
    {
        // GET: GamePage
        public ActionResult Index()
        {
            var game = new Game()
            {
                Name = "The Witcher® 3: Wild Hunt",
                Description = "Experience the epic conclusion to the story of professional monster slayer, witcher Geralt of Rivia. As war rages on throughout the Northern Realms, you take on the greatest contract of your life — tracking down the Child of Prophecy, a living weapon that can alter the shape of the world."
            };
            return View(game);
        }
        public ActionResult AgeValidation()
        {
            var game = new Game()
            {
                Name = "The Witcher® 3: Wild Hunt",
                AgeRestriction = 14
            };
            return View(game);
        } 

    }
}