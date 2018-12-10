using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gear.Models;

namespace Gear.Controllers
{
    public class ControllerBase : Controller
    {
        protected GearDBEntities db;

        public ControllerBase()
        {
            db = new GearDBEntities();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Session["LoggedIn"] = Session["LoggedIn"] == null ? false : Session["LoggedIn"];
        }
    }
}