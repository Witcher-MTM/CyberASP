using Microsoft.AspNetCore.Mvc;

namespace CyberASP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ILogger<TeamController> _logger;

        public TeamController(ILogger<TeamController> logger)
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
        public IEnumerable<Team> Get()
        {
            return teams;
        }
        [HttpPost]
        public StatusCodeResult AddTeam(string name,DateTime created)
        {
            int status = 204;
            if(name.Length>3 && created.ToString().Length > 0 )
            {
                try
                {
                    teams.Add(new Team(name, created));
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
    }
}
