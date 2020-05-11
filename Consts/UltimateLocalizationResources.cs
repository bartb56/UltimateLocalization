namespace Ultimate.Localization
{
    /// <summary>
    /// This class will feature all the ultiamte localization resources.
    /// The reason I define my resources in this class is to avoid type errors, and give people an easy way to translate this plugin.
    /// </summary>
    public static class UltimateLocalizationResources
    {
        //The reason this is public is so I can use it when uninstalling the plugin.
        public const string Base = "Ultimate.Localization.";

        public const string IsEnabled = Base + "Is.Enabled";
        public const string ConfigureTitle = Base + "Configure.Title";
        public const string SavedPluginSetings = Base + "Saved.Plugin.Settings";
    }
}
