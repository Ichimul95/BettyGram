using System.Web.Mvc;

using BettyGram.Models;


namespace BettyGram.Controllers
{
   public class Speech2TextController:Controller
   {
      public ActionResult Speech2Text( Speech2TextViewModel model)
      {
         return View();
      }
      [HttpPost]
      public ActionResult Speech(string inputText = "")
      {
         Speech2TextViewModel model = new Speech2TextViewModel { SpeechText = inputText };

         return View("/Views/Speech2Text/Speech2Text.cshtml", model);
      }
   }
}