namespace EnduranceContestManager.Gateways.Web.Infrastructure
{
    public static class WebConstants
    {
        public const string RootPath = "/";

        public static class ViewConstants
        {
            public static class Labels
            {
                public const string Username = "Потребителско име";
                public const string Password = "Парола";
                public const string ConfirmPassword = "Повтори паролата";
                public const string RememberMe = "Запомни ме";
            }

            public static class ValidationMessages
            {
                public const string PasswordsDoNotMatch = "Паролите не съвпадат";
            }
        }
    }
}
