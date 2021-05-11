namespace EnduranceJudge.Localization
{
    public class Strings
    {
        public static class DomainStrings
        {
            public const string IsRequiredTemplate = "property '{0}' is required.";
            public const string CannotRemoveNullItemTemplate = "cannot remove '{0}' - it is null.";
            public const string CannotRemoveItemIsNotFoundTemplate = "cannot remove '{0}' - it is not found.";
            public const string CannotAddNullItemTemplate = "cannot add '{0}' because it is null.";
            public const string CannotAddItemExistsTemplate = "cannot add '{0}' because entity with Id '{1}' already exists.";
        }

        public static class Application
        {
            public const string UnsupportedImportFileTemplate =  "Unsupported file. Please use '{0}' or '{1}'.";
        }

        public static class Desktop
        {
            public static class NavigationStrings
            {
                public const string ImportPageButtonText = "Import";
                public const string EventPageButtonText = "Event";
                public const string ManagerPageButtonText = "Manager";
                public const string RankingPageButtonText = "Ranking";
            }

            public static class Content
            {
                public static class ImportPageStrings
                {
                    public const string SelectWorkDirectoryButtonText = "Select Work Directory";
                    public const string SelectImportFileButtonText = "Select Import File";
                }
            }
        }
    }
}
