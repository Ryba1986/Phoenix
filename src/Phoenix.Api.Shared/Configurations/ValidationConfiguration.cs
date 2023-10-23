using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Phoenix.Validators.Roles;

namespace Phoenix.Api.Shared.Configurations
{
   public static class ValidationConfiguration
   {
      public static IServiceCollection ConfigureValidation(this IServiceCollection services)
      {
         return services
            .AddFluentValidationAutoValidation(x =>
            {
               ValidatorOptions.Global.DefaultClassLevelCascadeMode = CascadeMode.Stop;
               ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;

               x.DisableDataAnnotationsValidation = true;
            })
            .AddValidatorsFromAssemblyContaining<CreateRoleValidator>();
      }
   }
}
