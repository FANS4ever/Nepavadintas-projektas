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
    public class CreatorController : Controller
    {
        // GET: CreatorPage
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View(@"~/Views/Creator/Edit.cshtml");
        }
    }
}