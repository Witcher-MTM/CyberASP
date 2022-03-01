using Microsoft.AspNetCore.Mvc;

namespace CyberASP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LastGameController : ControllerBase
    {
        private readonly ILogger<LastGameController> _logger;

        public LastGameController(ILogger<LastGameController> logger)
        {
            _logger = logger;
        }
        List<LastGame> games = new List<LastGame>() { new LastGame("Test", DateTime.Now) };
        [HttpGet]
        public IEnumerable<LastGame> Get()
        {
            if (CyberUser.IsLogin)
            {

            return games;
            }
            else
            {
                return null;
            }
        }
        [HttpPost]
        public StatusCodeResult AddLastGame(string GameName, DateTime created)
        {
            if (CyberUser.IsLogin)
            {
                int status = 204;
                if (GameName != null)
                {
                    try
                    {
                        games.Add(new LastGame(GameName, created));
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
