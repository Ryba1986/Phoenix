using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;

namespace Phoenix.Services.Configuration.Modules
{
   internal sealed class MediatorModule : Module
   {
      protected override void Load(ContainerBuilder builder)
      {
         MediatRConfiguration configuration = MediatRConfigurationBuilder
            .Create(ThisAssembly)
            .WithAllOpenGenericHandlerTypesRegistered()
            .Build();

         builder.RegisterMediatR(configuration);
      }
   }
}
