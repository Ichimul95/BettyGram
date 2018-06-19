using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BettyGram.Models
{
   public class WheaterViewModel
   {
      public class OpenWeatherMap
      {
         public string ApiResponse { get; set; }

         public Dictionary<string, string> Citites
         {
            get; set;
         }
      }

   }
}
