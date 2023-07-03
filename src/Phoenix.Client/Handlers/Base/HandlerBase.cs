using RestSharp;

namespace Phoenix.Client.Handlers.Base
{
   internal abstract class HandlerBase
   {
      protected readonly IRestClient _client;

      public HandlerBase(IRestClient client)
      {
         _client = client;
      }
   }
}
