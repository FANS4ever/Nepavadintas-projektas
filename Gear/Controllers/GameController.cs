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

        GearDBEntities db = new GearDBEntities();

        // GET: GamePage
        public ActionResult Index(string name)
        {
            name = "The Witcher 3: Wild Hunt";
            var gameInfo = db.Games.Where(g => g.Name.Equals(name)).ToList();
            int gameId = gameInfo[0].Id;
            int devId = gameInfo[0].Developer_Id;
            var dev = db.Developers.Where(d => d.Id == devId).ToList();


            TwitchStreamers streamer = getTwitchStreamer(gameInfo[0].Name);

            if (streamer != null)
            {
                Game game = new Game()
                {
                    Streamer = streamer.channel.display_name,

                    Name = gameInfo[0].Name,
                    Description = gameInfo[0].Description,
                    Dir = gameInfo[0].Dir,
                    Developer = dev[0],
                    ReleaseDate = gameInfo[0].ReleaseDate,
                    Price = gameInfo[0].Price,
                    GameRatings = db.GameRatings.Where(g => g.Game_Id == gameId).ToList()

                };
                return View(game);
            }

            else
            {
                var game = new Game()
                {
                    Name = gameInfo[0].Name,
                    Description = gameInfo[0].Description,
                    Dir = gameInfo[0].Dir
                };
                return View(game);
            }


        }

        //public ActionResult AgeValidation()
        //{
        //    var game = new Game()
        //    {

        //        Name =  "The Witcher® 3: Wild Hunt",
        //        AgeRestriction = 14
        //    };
        //    return View(game);
        //}



        public TwitchStreamers getTwitchStreamer(string name)
        {
            var webClient = new WebClient();
            webClient.Headers.Add("Client-ID", "9biq0mp63j7qbe0pv8x3sugesx1ezr");

            var json = webClient.DownloadString(@"https://api.twitch.tv/kraken/streams?game=" + name);

            var contentJo = (JObject)JsonConvert.DeserializeObject(json);
            var streamersJArray = contentJo["streams"].Value<JArray>();

            var rez = streamersJArray.ToObject<List<TwitchStreamers>>();

            List<TwitchStreamers> enStreamers = new List<TwitchStreamers>();

            foreach (var item in rez)
                if (item.channel.language == "en")
                    enStreamers.Add(item);

            Random rand = new Random();


            int stream = -1;
            if (enStreamers != null && enStreamers.Count > 0)
                stream = rand.Next(0, enStreamers.Count);


            if (stream != -1)
                return enStreamers[stream];
            else
                return null;
        }
    }
}