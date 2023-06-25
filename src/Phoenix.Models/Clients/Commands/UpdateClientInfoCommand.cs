using Phoenix.Models.Base.Commands;

namespace Phoenix.Models.Clients.Commands
{
   public sealed class UpdateClientInfoCommand : CommandBase
   {
      public int Id { get; private set; }
      public string Hostname { get; init; }
      public string ClientVersion { get; init; }

      public UpdateClientInfoCommand()
      {
         Hostname = string.Empty;
         ClientVersion = string.Empty;
      }

      public override void SetId(int id)
      {
         Id = id;
      }
   }
}
