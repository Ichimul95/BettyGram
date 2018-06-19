// --------------------------------------------------------------------------------------------
// <Copyright>
//     Copyright © 2017 Marian Stefan. All rights reserved.
// </Copyright>
// --------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Mvc;

using BettyGram.Models;

using Newtonsoft.Json;


namespace BettyGram.Controllers
{
   public class HomeController : Controller
   {
      public ActionResult Index(string display = "text")
      {
         return View("Video2");
      }   

      [HttpGet]
      // GET: OpenWeatherMapMvc
      public ActionResult Weather()
      {
         WheaterViewModel.OpenWeatherMap model = new WheaterViewModel.OpenWeatherMap();
         WheaterViewModel.OpenWeatherMap openWeatherMap = FillCity();
         model.Citites = openWeatherMap.Citites;
         /*Calling API http://openweathermap.org/api */
         string apiKey = "de6d52c2ebb7b1398526329875a49c57";
         HttpWebRequest apiRequest =
            WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?id=" + 683844 + "&appid=" + apiKey + "&units=metric") as HttpWebRequest;

         string apiResponse = "";
         if (apiRequest != null)
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
               if (response != null)
               {
                  // ReSharper disable once AssignNullToNotNullAttribute
                  StreamReader reader = new StreamReader(response.GetResponseStream());
                  apiResponse = reader.ReadToEnd();
               }
            }
         /*End*/

         /*http://json2csharp.com*/
         HelperModel.ResponseWeather rootObject = JsonConvert.DeserializeObject<HelperModel.ResponseWeather>(apiResponse);

         return Json(new { values = rootObject }, JsonRequestBehavior.AllowGet);
      }

      public WheaterViewModel.OpenWeatherMap FillCity()
      {
         WheaterViewModel.OpenWeatherMap openWeatherMap = new WheaterViewModel.OpenWeatherMap
         {
            Citites = new Dictionary<string, string>
            {
               {"Brasov", "683844"}
            }
         };
         return openWeatherMap;
      }
   }
}