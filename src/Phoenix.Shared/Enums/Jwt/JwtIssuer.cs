using System.ComponentModel;

namespace Phoenix.Shared.Enums.Jwt
{
   public enum JwtIssuer : byte
   {
      [Description("Client")]
      Client = 1,

      [Description("Web")]
      Web = 2
   }
}
