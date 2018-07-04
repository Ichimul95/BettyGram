using System;
using System.Collections.Generic;
using System.Text;
using BettyGram.TL;
using BettyGram.DL;

namespace BettyGram.BL
{
   public class SalesManager : ISalesManager
   {
      #region MEMBER VARIABLES

      private ISalesRepository _salesRepository;

      #endregion

      #region CONSTRUCTORS

      public SalesManager() : this(new SalesRepository()) { }

      public SalesManager(ISalesRepository repository)
      {
         _salesRepository = repository;
      }

      #endregion

      IList<SalesDto> ISalesManager.GetAll()
      {
         return _salesRepository.GetAll();
      }

      private void ValidateDto(SalesDto dto)
      {
         if (dto == null)
         {
            throw new Exception("The sales model is null.");
         }
      }
   }
}
