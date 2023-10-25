namespace Phoenix.Services.Settings
{
   internal sealed class SmtpSettings
   {
      public string Server { get; init; }
      public ushort Port { get; init; }
      public string Username { get; init; }
      public string Password { get; init; }
      public bool EnableSsl { get; init; }

      public SmtpSettings()
      {
         Server = string.Empty;
         Username = string.Empty;
         Password = string.Empty;
      }
   }
}
