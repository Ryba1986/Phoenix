namespace Phoenix.Shared.Results
{
   public readonly struct TokenResult
   {
      public string Value { get; init; }

      public TokenResult()
      {
         Value = string.Empty;
      }
   }
}
