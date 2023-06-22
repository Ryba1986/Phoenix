namespace Phoenix.Shared.Results
{
   public readonly struct Result
   {
      public bool IsSuccess { get; init; }
      public string Message { get; init; }

      public Result(bool isSuccess, string message)
      {
         IsSuccess = isSuccess;
         Message = message;
      }

      public static Result Success()
      {
         return new Result(true, string.Empty);
      }

      public static Result Error(string message)
      {
         return new Result(false, message);
      }
   }
}
