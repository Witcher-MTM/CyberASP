using Microsoft.AspNetCore.Mvc;

namespace CyberASP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;

        public PlayerController(ILogger<PlayerController> logger)
        {
            _logger = logger;
        }
        static List<Team> teams = new List<Team>() { new Team("Natus Vincere", new DateTime(2009, 2, 24)) };
        List<Player> players = new List<Player>() { new Player("Александр", "Костылев", string.Empty, "S1mple", teams.Where(x => x.Name == "Natus Vincere").First()),
                                                    new Player("Денис","Шарипов",String.Empty,"Electronic",teams.Where(x => x.Name == "Natus Vincere").First()),
                                                    new Player("Кирилл","Михайлов",String.Empty,"Boombl4",teams.Where(x => x.Name == "Natus Vincere").First()),
                                                    new Player("Илья","Залуцкий",String.Empty,"Perfecto",teams.Where(x => x.Name == "Natus Vincere").First()),
                                                     new Player("Валерий","Ваховский",String.Empty,"B1t",teams.Where(x => x.Name == "Natus Vincere").First())    };
        [HttpGet]
        public IEnumerable<Player> GetPlayers()
        {
            if (CyberUser.IsLogin)
            {
                try
                {
                    return players;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return null;
            }
        }
        [HttpPost]
        public StatusCodeResult AddPlayer(string name,string secondname,string lastname, string nickname, string teamName)
        {
            if (CyberUser.IsLogin)
            {
                int status = 204;
                if (name.Length > 3 && secondname.Length > 3 && nickname.Length > 3 && teamName != null)
                {
                    try
                    {
                        players.Add(new Player(name, secondname, lastname, nickname, teams.Where(x => x.Name.ToLower() == teamName.ToLower()).First()));
                        status = 200;
                    }
                    catch (Exception)
                    {
                        status = 204;

                    }
                }
                else
                {
                    status = 204;
                }
                return StatusCode(status);
            }
            else
            {
                return StatusCode(401);
            }
           
        }
    }
}
