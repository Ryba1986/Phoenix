namespace Phoenix.Shared.Validators
{
   public static class RegexPatterns
   {
      public const string Email = @"^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";
      public const string MacAddress = "^[0-9A-F]{12}$";
   }
}
