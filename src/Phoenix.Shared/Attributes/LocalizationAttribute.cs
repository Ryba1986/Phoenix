using System.ComponentModel;
using Phoenix.Shared.Extensions;
using Phoenix.Shared.Languages;

namespace Phoenix.Shared.Attributes
{
   public sealed class LocalizationAttribute : DescriptionAttribute
   {
      public LocalizationAttribute(string description) : base(description)
      {
      }

      public override string Description => typeof(Translations).GetPropertyValue(base.Description);
   }
}
