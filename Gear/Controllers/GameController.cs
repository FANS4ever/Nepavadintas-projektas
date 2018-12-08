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
        public ActionResult Index(int id)
        {
            //name = "The Witcher 3: Wild Hunt";
            var gameInfo = db.Games.Where(g => g.Id.Equals(id)).ToList()[0];
            int gameId = gameInfo.Id;
            int devId = gameInfo.Developer_Id;
            var dev = db.Developers.Where(d => d.Id == devId).ToList()[0];

            Game ga = db.Games.ToList().Where(game => game.Id.Equals(gameInfo.Id)).ToList()[0];
            List<Genre> genres = ga.Genres.ToList();
            foreach (Genre gen in genres)
            {
                string name = gen.Name;
            }

            TwitchStreamers streamer = getTwitchStreamer(gameInfo.Name);

            if (streamer != null)
            {
                Game game = new Game()
                {
                    Streamer = streamer.channel.display_name,

                    Id = gameInfo.Id,
                    Name = gameInfo.Name,
                    Description = gameInfo.Description,
                    Dir = gameInfo.Dir,
                    Developer = dev,
                    ReleaseDate = gameInfo.ReleaseDate,
                    Price = gameInfo.Price,
                    GameRatings = db.GameRatings.Where(g => g.Game_Id == gameInfo.Id).ToList(),
                    Genres = genres
                    

                };
                return View(game);
            }

            else
            {
                var game = new Game()
                {
                    Name = gameInfo.Name,
                    Description = gameInfo.Description,
                    Dir = gameInfo.Dir
                };
                return View(game);
            }


        }

        public ActionResult AgeValidation(int id)
        {
            var gameInfo = db.Games.Where(g => g.Id.Equals(id)).ToList()[0];


            var game = new Game()
            {
                Id = gameInfo.Id,
                Name = gameInfo.Name,
                Dir = gameInfo.Dir,
                AgeRestriction = gameInfo.AgeRestriction
        };
            return View(game);
        }



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