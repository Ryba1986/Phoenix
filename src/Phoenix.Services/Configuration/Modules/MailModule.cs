using System.Net;
using System.Net.Mail;
using Autofac;
using Phoenix.Services.Settings;

namespace Phoenix.Services.Configuration.Modules
{
   internal sealed class MailModule : Module
   {
      protected override void Load(ContainerBuilder builder)
      {
         builder
            .Register((SmtpSettings settings) =>
            {
               return new SmtpClient()
               {
                  Host = settings.Server,
                  Port = settings.Port,
                  Credentials = new NetworkCredential(settings.Username, settings.Password),
                  EnableSsl = settings.EnableSsl,
               };
            })
            .AsSelf()
            .InstancePerDependency();
      }
   }
}
