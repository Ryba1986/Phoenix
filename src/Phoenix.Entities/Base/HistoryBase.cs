using System;
using Phoenix.Entities.Users;

namespace Phoenix.Entities.Base
{
   public abstract class HistoryBase : EntityBase
   {
      public int CreatedById { get; set; }
      public User CreatedBy { get; set; }

      public bool IsActive { get; set; }
      public DateTime CreateDate { get; set; }

      public HistoryBase()
      {
         CreatedBy = null!;
      }
   }
}
