using Autofac;
using Phoenix.Client.Extensions;
using Phoenix.Client.Settings;
using RestSharp;
using RestSharp.Authenticators;

namespace Phoenix.Client.Configuration.Modules
{
   internal sealed class ApiClientModule : Module
   {
      protected override void Load(ContainerBuilder builder)
      {
         builder
            .Register((PhoenixSettings settings) =>
            {
               return new RestClient(new RestClientOptions()
               {
                  Authenticator = new JwtAuthenticator(ApiClientExtensions.EmptyTokenValue),
                  BaseUrl = new(settings.ApiUrlBase),
                  ThrowOnAnyError = false,
               });
            })
            .As<IRestClient>()
            .SingleInstance();
      }
   }
}
