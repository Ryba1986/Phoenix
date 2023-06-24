using System;

namespace Phoenix.Models.Base.Dto
{
   public abstract class HistoryDtoBase : DtoBase
   {
      public bool IsActive { get; init; }
      public string CreatedByName { get; init; }
      public DateTime CreateDate { get; init; }

      public HistoryDtoBase()
      {
         CreatedByName = string.Empty;
      }
   }
}
