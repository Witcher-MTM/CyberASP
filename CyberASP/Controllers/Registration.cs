using Microsoft.AspNetCore.Mvc;

namespace CyberASP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Registration : ControllerBase
    {
        private readonly ILogger<Registration> _logger;
        public User user { get; set; }
        public SqlOperations sql_operat { get; set; }
        public Registration(ILogger<Registration> logger)
        {
            _logger = logger;
            user = new User();
            sql_operat = new SqlOperations();
        }
        [HttpPost]
        public ActionResult Registr(string login , string email)
        {
            if (user.validDates(login, email))
            {
                user = new User(login, email);
                ConnectDataBase.Connect();
                sql_operat.AddUser(user.Login, user.Email, user.date_registr, user.Token);
                user.SendEmailAsync().GetAwaiter();
                return StatusCode(200);
            }
            else
            {
                return StatusCode(400, "Bad dates");
            }
        }
    }
}
