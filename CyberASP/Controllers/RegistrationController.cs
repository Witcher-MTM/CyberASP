using Microsoft.AspNetCore.Mvc;

namespace CyberASP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly ILogger<RegistrationController> _logger;
        public CyberUser user { get; set; }
        public SqlOperations sql_operat { get; set; }
        public RegistrationController(ILogger<RegistrationController> logger)
        {
            _logger = logger;
            user = new CyberUser();
            sql_operat = new SqlOperations();
        }
        [HttpPost]
        public ActionResult Registr(string login , string email)
        {
            if (user.validDates(login, email))
            {
                user = new CyberUser(login, email);
                ConnectDataBase.Connect();
                sql_operat.AddUser(user.Login, user.Email, user.date_registr, user.Token);
                user.SendEmailAsync();
                return StatusCode(200);
            }
            else
            {
                return StatusCode(400, "Bad dates");
            }
        }
    }
}
