using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gear.Models;



using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net;
using Newtonsoft.Json.Linq;

/// <summary>
/// Tadas Kalvaitis
/// </summary>
namespace Gear.Controllers
{
    public class GameController : Controller
    {
        //// GET: GamePage
        //public ActionResult Index()
        //{
        //    Random rand = new Random();
        //    var rez = data("The Witcher 3: Wild Hunt");
        //    int stream = -1;
        //    if (rez != null)
        //        stream = rand.Next(0, rez.Count);

        //    if (stream != -1)
        //    { 
        //        var game = new Game()
        //        {
        //            Streamer = rez[stream].channel.display_name,
        //            Name = "The Witcher 3: Wild Hunt",
        //            Description = "Experience the epic conclusion to the story of professional monster slayer, witcher Geralt of Rivia. As war rages on throughout the Northern Realms, you take on the greatest contract of your life — tracking down the Child of Prophecy, a living weapon that can alter the shape of the world."
        //        };
        //        return View(game);
        //    }

        //    else
        //    {
        //        var game = new Game()
        //        {
        //            Name = "The Witcher 3: Wild Hunt",
        //            Description = "Experience the epic conclusion to the story of professional monster slayer, witcher Geralt of Rivia. As war rages on throughout the Northern Realms, you take on the greatest contract of your life — tracking down the Child of Prophecy, a living weapon that can alter the shape of the world."
        //        };
        //        return View(game);
        //    }

           
        //}

        //public ActionResult AgeValidation()
        //{
        //    var game = new Game()
        //    {
                
        //        Name =  "The Witcher® 3: Wild Hunt",
        //        AgeRestriction = 14
        //    };
        //    return View(game);
        //}



        //public List<TwitchStreamers> data(string name)
        //{
        //    var webClient = new WebClient();
        //    webClient.Headers.Add("Client-ID", "9biq0mp63j7qbe0pv8x3sugesx1ezr");

        //    var json = webClient.DownloadString(@"https://api.twitch.tv/kraken/streams?game=" + name);

        //    var contentJo = (JObject)JsonConvert.DeserializeObject(json);
        //    var streamersJArray = contentJo["streams"].Value<JArray>();

        //    return streamersJArray.ToObject<List<TwitchStreamers>>();
        //}
    }
}