﻿using System;
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
        GearDBEntities db = new GearDBEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Edit()
        {
            return View();
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
        public ActionResult Register(string username, string email, string password, string confirmPassword, int country)
        {
            //Game g = db.Games.ToList().Where(game => game.Name == "Witcher").ToList()[0];
            //List<Genre> genres = g.Genres.ToList();
            //foreach (Genre gen in genres)
            //{
            //    string name = gen.Name;
            //}


            db.Users.Add(new User()
            {
                Username = username,
                Password = password,
                Email = email,
                Blocked = 0,
                Country_Code = country,
                Rank_Name = "User"
            });
            db.SaveChanges();

            return Content("Good");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            List<User> users = db.Users.ToList();
            foreach (User item in users)
            {
                if (item.Username == username && item.Password == password)
                {
                    Session["User"] = item;
                    
                    return Content("Logged in");
                }
            }
            return View();
        }
    }
}