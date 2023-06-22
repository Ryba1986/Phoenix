using Phoenix.Services.Repositories;

namespace Phoenix.Services.Handlers.Base
{
   internal abstract class HandlerBase
   {
      protected readonly UnitOfWork _uow;

      public HandlerBase(UnitOfWork uow)
      {
         _uow = uow;
      }
   }
}
