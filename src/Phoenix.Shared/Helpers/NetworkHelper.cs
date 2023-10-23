using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;

namespace Phoenix.Shared.Helpers
{
   public static class NetworkHelper
   {
      public static string GetMacAddress()
      {
         return NetworkInterface
            .GetAllNetworkInterfaces()
            .FirstOrDefault(x =>
               x.OperationalStatus == OperationalStatus.Up &&
               x.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
               x.Speed > 1024
            )?
            .GetPhysicalAddress()
            .ToString()
            .ToUpper() ?? string.Empty;
      }

      public async static Task<string> GetTorHostAsync(string filePath, CancellationToken cancellationToken)
      {
         if (!File.Exists(filePath))
         {
            return string.Empty;
         }

         string fileContent = await File.ReadAllTextAsync(filePath, cancellationToken);
         return new(fileContent.TakeWhile(char.IsLetterOrDigit).ToArray());
      }
   }
}
