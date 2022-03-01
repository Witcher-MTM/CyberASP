using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
namespace CyberASP
{
    public class CyberUser
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime date_registr { get; set; }
        public static bool IsLogin;
        public CyberUser()
        {
            IsLogin = false;
        }
       
        public CyberUser(string login , string email)
        {
            this.Login = login;
            this.Email = email;
            this.date_registr = DateTime.Now;
            GenToken();
            IsLogin = false;
        }
        private void GenToken()
        {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            this.Token = Convert.ToBase64String(time.Concat(key).ToArray());
        }
        public bool validDates(string login , string email)
        {
            if (ValidLogin(login) && ValidEmail(email))
            {
               
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool ValidLogin(string login)
        {
            if(login.Length>4 && login.Length < 12)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool ValidEmail(string email)
        {
            var checkEmail = new EmailAddressAttribute();
            if (checkEmail.IsValid(email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async void SendEmailAsync()
        {
            MailAddress from = new MailAddress("rubicktanks@gmail.com", "CyberUser");
            MailAddress to = new MailAddress(Email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Token";
            m.Body = Token;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("rubicktanks@gmail.com", "rubicktanks228");
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(m);
        }
        
    }
}
