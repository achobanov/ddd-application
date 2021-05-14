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
            public static class CommonStrings
            {
                public const string SaveButtonText = "Save";
                public const string UpdateButtonText = "Update";
            }

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

                public static class EventPage
                {
                    public static class NavigationStripStrings
                    {
                        public const string Events = "Events";
                    }

                    public static class EnduranceEventStrings
                    {
                        public const string NameLabel = "Name";
                        public const string PopulatedPlaceLabel = "Populated Place";
                        public const string CountryLabel = "Country";
                        public const string PresidentGroundJuryLabel = "President Ground Jury";
                        public const string PresidentVetCommissionLabel = "President Vet Commission";
                        public const string ForeignJudgeLabel = "Foreign Judge";
                        public const string FeiVetDelegateLabel = "Fei Vet Delegate";
                        public const string FeiTechDelegateLabel = "Fei Tech Delegate";
                        public const string ActiveVetLabel = "Active Vet";
                        public const string MembersOfJudgeCommitteeLabel = "Members of Judge Committee";
                        public const string MembersOfVetCommitteeLabel = "Members of Vet Committee";
                        public const string StewardsLabel = "Stewards";
                    }
                }
            }
        }
    }
}
