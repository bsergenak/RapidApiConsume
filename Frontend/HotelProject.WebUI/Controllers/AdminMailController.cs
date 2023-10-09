using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminMailViewModel model)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddress = new MailboxAddress("HotelierAdmin", "berkaysergen.ak@gmail.com");
            mimeMessage.From.Add(mailboxAddress);

            MailboxAddress mailboxAdressTo = new MailboxAddress("User", model.ReceiverMail);
            mimeMessage.To.Add(mailboxAdressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = model.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = model.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smpt.gmail.com", 587, false);
            client.Authenticate("berkaysergen.ak@gmail.com", "syhl xwsp dlln ioja");
            client.Send(mimeMessage);
            client.Disconnect(true);

            return View();
        }
    }
}
