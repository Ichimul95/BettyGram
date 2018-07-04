using BettyGram.TL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BettyGram.DL
{
   public interface ISalesRepository
   {
      IList<SalesDto> GetAll();
   }
}