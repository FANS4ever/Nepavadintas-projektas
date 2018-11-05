using Gear.Models;
using Newtonsoft.Json;
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
        public ActionResult Edit()
        {
            return View(@"~/Views/Creator/Edit.cshtml");
        }
        public ActionResult Statistics()
        {
            double count = 1000, y = 100;
            Random random = new Random();
            List<DataPoint> dataPoints = new List<DataPoint>();

            for (int i = 0; i < count; i++)
            {
                y += random.Next(-10, 11);
                dataPoints.Add(new DataPoint(i, y));
            }

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View(@"~/Views/Creator/Statistics.cshtml");
        }
        public ActionResult Create()
        {
            return View(@"~/Views/Creator/Create.cshtml");
        }
    }
}