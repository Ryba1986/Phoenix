namespace Phoenix.Shared.Results
{
   public readonly struct FileResult
   {
      public string Name { get; init; }
      public string Type { get; init; }
      public byte[] Data { get; init; }

      public FileResult()
      {
         Name = string.Empty;
         Type = string.Empty;
         Data = [];
      }
   }
}
