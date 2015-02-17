using System.Collections.Generic;
using System.Web.Mvc;
using MyFirstAngularApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyFirstAngularApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public string GetEmails()
        {
            dynamic jsonEmails = JsonConvert.DeserializeObject(System.IO.File.ReadAllText(HttpContext.Server.MapPath(@"/App_Data/emails.txt")));

            return jsonEmails.ToString();
        }

        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public bool SendEmail(Email newEmail)
        {
            try
            {
                var listEmails = JsonConvert.DeserializeObject<List<Email>>(GetEmails());

                // var newEmail = JsonConvert.DeserializeObject<Email>(jsonEmail);

                listEmails.Add(newEmail);

                var newJson = JsonConvert.SerializeObject(listEmails.ToArray(), Formatting.Indented);
                System.IO.File.WriteAllText(HttpContext.Server.MapPath(@"/App_Data/emails.txt"), newJson);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}