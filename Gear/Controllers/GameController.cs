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
    public class GameController : ControllerBase
    {

        GearDBEntities db = new GearDBEntities();

        // GET: GamePage
        public ActionResult Index(int id)
        {


            //name = "The Witcher 3: Wild Hunt";
            Game gameInfo = db.Games.Where(g => g.Id.Equals(id)).ToList()[0];
            int devId = gameInfo.Developer_Id;
            Developer dev = db.Developers.Where(d => d.Id == devId).ToList()[0];

            Game ga = db.Games.ToList().Where(game => game.Id.Equals(gameInfo.Id)).ToList()[0];
            List<Genre> genres = ga.Genres.ToList();
            List<Discount> discounts = ga.Discounts.Where(d => d.ExpireDate > DateTime.Now).ToList();

            List<Game> allGames = db.Games.ToList();

            List<Game> recomended = RecomendedGames(genres, allGames, gameInfo);

            List<Comment> com = ga.Comments.ToList();

            double price = gameInfo.Price;
            foreach (var item in discounts)
            {
                price *= item.Modifier;
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
                    Price = price,
                    GameRatings = db.GameRatings.Where(g => g.Game_Id == gameInfo.Id).ToList(),
                    Genres = genres,
                    TrailerURL = gameInfo.TrailerURL,
                    Recomended = recomended,
                    User = Session["User"] as User,
                    Comments = com
                    
            };
                return View(game);
            }

            else
            {
                var game = new Game()
                {
                    Id = gameInfo.Id,
                    Name = gameInfo.Name,
                    Description = gameInfo.Description,
                    Dir = gameInfo.Dir,
                    Developer = dev,
                    ReleaseDate = gameInfo.ReleaseDate,
                    Price = price,
                    GameRatings = db.GameRatings.Where(g => g.Game_Id == gameInfo.Id).ToList(),
                    Genres = genres,
                    TrailerURL = gameInfo.TrailerURL
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
                AgeRestriction = gameInfo.AgeRestriction,
                User = Session["User"] as User
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

        public List<Game> RecomendedGames(List<Genre> tags, List<Game> allGames, Game currentGame)
        {
            List<Game> recomended = new List<Game>();
            foreach(var item in allGames)
            {
                if (item != currentGame)
                {
                    List<Genre> genres = item.Genres.ToList();
                    foreach (var gen in genres)
                    {
                        if (tags.Contains(gen))
                        {
                            recomended.Add(item);
                            break;
                        }
                    }
                }
            }
            
            if (recomended.Count <= 5)
            {
                foreach (var item in recomended)
                {
                    List<Discount> discounts = item.Discounts.Where(d => d.ExpireDate > DateTime.Now).ToList();
                    item.Discount = 0;
                    foreach (var disc in discounts)
                    {
                        item.Price *= disc.Modifier;
                        item.Discount = item.Discount + (disc.Modifier * 100);
                    }
                }
                return recomended;
            }
            else
            {
                Random ran = new Random();
                int n = 0;
                List<Game> pickedGames = new List<Game>();
                while (pickedGames.Count != 5)
                {
                    n = ran.Next(0, recomended.Count);
                    pickedGames.Add(recomended[n]);
                    recomended.Remove(recomended[n]);
                }

                foreach (var item in pickedGames)
                {
                    List<Discount> discounts = item.Discounts.Where(d => d.ExpireDate > DateTime.Now).ToList();
                    item.Discount = 0;
                    foreach (var disc in discounts)
                    {
                        item.Price *= disc.Modifier;
                        item.Discount += (int)disc.Modifier * 100;
                    }
                }

                return pickedGames;
            }
        }

        [HttpPost]
        public ActionResult Index(string note, int id, string coment, int? rating)
        {
            User user = Session["User"] as User;
            if (note != null)
            {
                db.Marks.Add(new Mark()
                {
                    CreateDate = DateTime.Now,
                    Description = note,
                    Game_Id = id,
                    User_Username = user.Username
                });
            }
            else
            {
                db.Comments.Add(new Comment()
                {
                    CreateDate = DateTime.Now,
                    Content = coment,
                    Game_Id = id,
                    User_Username = user.Username
                });


                if (rating != null)
                {
                    var currentGameRating = db.GameRatings.SingleOrDefault(gr => gr.User_Username.Equals(user.Username) && gr.Game_Id.Equals(id));

                    if (currentGameRating != null)
                    {
                        currentGameRating.CreateDate = DateTime.Now;
                        currentGameRating.Rating = (int)rating;
                        // update rating in db (magic)
                    }
                    else
                    {
                        db.GameRatings.Add(new GameRating()
                        {
                            CreateDate = DateTime.Now,
                            Rating = (int)rating,
                            Game_Id = id,
                            User_Username = user.Username
                        });
                    }
                }
            }

            db.SaveChanges();
            return RedirectToAction("Index", new { id = id});
        }
    }
}