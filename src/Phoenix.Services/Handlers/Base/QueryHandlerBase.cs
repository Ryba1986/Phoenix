using AutoMapper;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Handlers.Base
{
   internal abstract class QueryHandlerBase : HandlerBase
   {
      protected readonly IMapper _mapper;

      public QueryHandlerBase(UnitOfWork uow, IMapper mapper) : base(uow)
      {
         _mapper = mapper;
      }
   }
}
