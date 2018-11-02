using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


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
            return View();
        }
    }
}