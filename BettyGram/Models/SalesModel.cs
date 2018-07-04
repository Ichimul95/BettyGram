using BettyGram.TL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BettyGram.Models
{
   public class SalesModel
   {
      public int Sales { get; set; }

      public static SalesModel ToViewModel(List<SalesDto> salesDto)
      {
         SalesModel salesModel = new SalesModel()
         {
           // Sales = salesDto.FirstOrDefault()
         };
         return salesModel;
      }
   }
}