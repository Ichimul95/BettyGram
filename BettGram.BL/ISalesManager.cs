using BettyGram.TL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BettyGram.BL
{
   public interface ISalesManager
   {
      IList<SalesDto> GetAll();
   }
}
