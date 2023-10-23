using System;
using System.Reflection;

namespace Phoenix.Shared.Extensions
{
   public static class ReflectionExtensions
   {
      public static string GetVersion(this Type type)
      {
         return type.Assembly
            .GetCustomAttribute<AssemblyFileVersionAttribute>()?
            .Version ?? string.Empty;
      }

      public static string GetPropertyValue(this Type type, string name)
      {
         PropertyInfo? propertyInfo = type.GetProperty(name, BindingFlags.Static | BindingFlags.Public);

         return propertyInfo?
            .GetValue(propertyInfo)?
            .ToString() ?? string.Empty;
      }
   }
}
