using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Phoenix.Shared.Results;
using RestSharp;
using RestSharp.Authenticators;

namespace Phoenix.Client.Extensions
{
   internal static class ApiClientExtensions
   {
      public const string EmptyTokenValue = "EMPTY_TOKEN";

      public static async Task<T?> GetAsync<T>(this IRestClient client, string url, IRequest<T> query, CancellationToken cancellationToken) where T : class
      {
         RestRequest request = new(url);

         IReadOnlyCollection<PropertyInfo> properties = query
            .GetType()
            .GetProperties();

         foreach (PropertyInfo property in properties)
         {
            request.AddQueryParameter(property.Name, property.GetValue(query)?.ToString());
         }

         RestResponse<T> response = await client.ExecuteGetAsync<T>(request, cancellationToken);

         return response.IsSuccessful
            ? response.Data
            : null;
      }

      public static async Task<Result> PostAsync(this IRestClient client, string url, IRequest<Result> command, CancellationToken cancellationToken)
      {
         RestResponse<Result> response = await client.GetPostResponseAsync(url, command, cancellationToken);

         return response.IsSuccessful
            ? response.Data
            : Result.Error(response.ErrorMessage ?? string.Empty);
      }

      public static async Task<bool> PostAsync(this IRestClient client, string url, IRequest<TokenResult> command, CancellationToken cancellationToken)
      {
         if (client.Options.Authenticator is not JwtAuthenticator authenticator)
         {
            return false;
         }

         RestResponse<TokenResult> response = await client.GetPostResponseAsync(url, command, cancellationToken);
         if (response.IsSuccessful && !string.IsNullOrWhiteSpace(response.Data.Value))
         {
            authenticator.SetBearerToken(response.Data.Value);
            return true;
         }

         authenticator.SetBearerToken(EmptyTokenValue);
         return false;
      }

      private static Task<RestResponse<T>> GetPostResponseAsync<T>(this IRestClient client, string url, IRequest<T> command, CancellationToken cancellationToken) where T : struct
      {
         RestRequest request = new(url);
         request.AddJsonBody(command);

         return client.ExecutePostAsync<T>(request, cancellationToken);
      }
   }
}
