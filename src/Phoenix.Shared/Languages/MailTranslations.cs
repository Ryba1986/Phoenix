namespace Phoenix.Shared.Languages
{
   public static partial class Translations
   {
      public static string Mail_CreateAccount_Subject => Get(eng: "The account has been created", pol: "Konto zostało utworzone");
      public static string Mail_CreateAccount_Body => Get(eng: "Email: {0}<br />Password: {1}", pol: "Email: {0}<br />Hasło: {1}");
   }
}
