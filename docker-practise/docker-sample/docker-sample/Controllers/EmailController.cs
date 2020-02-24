using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace docker_sample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController:ControllerBase
    {
        private readonly IConfiguration _configuration;
        private  string MAIL_HOST;
        private  string MAIL_PORT;
        public EmailController(IConfiguration configuration)
        {
            _configuration = configuration;
           
        }

        [HttpPost("[action]")]      
        public async Task EmailRandomNames()
        {
            string email = "test@fake.com";
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Generator", "generator@generate.com"));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = "Here are your random names!";

            message.Body = new TextPart("plain")
            {
                Text = string.Join(Environment.NewLine, "kapil,mala,juhi, himanshu,kiran")
            };
            using (var mailClient = new SmtpClient())
            {
                MAIL_HOST = _configuration["Mail:MAIL_HOST"].ToString();
                MAIL_PORT = _configuration["Mail:MAIL_PORT"].ToString();
                await mailClient.ConnectAsync(MAIL_HOST, Convert.ToInt32(MAIL_PORT), SecureSocketOptions.None);
                await mailClient.SendAsync(message);
                await mailClient.DisconnectAsync(true);
            }
        }

       
    }
}
