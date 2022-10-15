using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using MimeKit;
using MimeKit.Text;
using QuickMailer;

namespace Pratical.Controllers
{
    public class sendMailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult sendMail(string title,string message)
        {
            TempData["mesg"] = "";
            try {
                //var email = new MailMessage();
                //email.To.Add("mohammedhassan4230@gmail.com");
                //email.From=new MailAddress("mohmedhassan159357@gmail.com");
                //email.Subject = title;
                //email.Body = message;
               
                //SmtpClient smtp = new SmtpClient();
                //smtp.Host = "smtp.gmail.com";
                //smtp.Port = 587;
                //smtp.UseDefaultCredentials = false;
                //smtp.Credentials = new System.Net.NetworkCredential("mohammedhassan4230@gmail.com", "Mum42005"); // Enter seders User name and password  
                //smtp.EnableSsl = true;
                //smtp.Send(email);
               
                var email = new Email();
                email.SendEmail("as8338873@gmail.com", "mohmedhassan159357@gmail.com", "A@123321A@", title, message);
                TempData["mesg"] = "Email sent succefuly";


            }
            catch (Exception ex)
            {
                TempData["mesg"] = ex.Message;
            }
            return RedirectToAction("Index");

        }
    }
}
