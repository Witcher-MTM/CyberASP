using Microsoft.AspNetCore.Mvc;

namespace CyberASP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        public SqlOperations sql_operat { get; set; }
        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
            sql_operat = new SqlOperations();
            ConnectDataBase.Connect();
        }
        [HttpPost]
        public ActionResult Login(string login , string token)
        {
            if(sql_operat.LoginByDB(login, token))
            {
                CyberUser.IsLogin = true;
                return StatusCode(200);
            }
            else
            {
                return StatusCode(400);
            }
        }
    }
}
