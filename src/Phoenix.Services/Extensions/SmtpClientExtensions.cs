using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace Phoenix.Services.Extensions
{
   internal static class SmtpClientExtensions
   {
      public static async Task SendAsync(this SmtpClient smtpClient, string emailTo, string subject, string body, CancellationToken cancellationToken)
      {
         using MailMessage mailMessage = new(smtpClient.GetUserName(), emailTo, subject, body)
         {
            IsBodyHtml = true,
         };

         await smtpClient.SendMailAsync(mailMessage, cancellationToken);
      }

      private static string GetUserName(this SmtpClient smtpClient)
      {
         if (smtpClient.Credentials is not NetworkCredential credentials)
         {
            return string.Empty;
         }

         return credentials.UserName;
      }
   }
}
