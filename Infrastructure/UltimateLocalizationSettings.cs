using Nop.Core.Configuration;

namespace Ultimate.Localization.Infrastructure
{
    /// <summary>
    /// This class stores all the settings for the ultimate localization plugin.
    /// </summary>
    public class UltimateLocalizationSettings : ISettings
    {
        #region Constructor
        public UltimateLocalizationSettings()
        {
        }

        #endregion

        #region Fields

        /// <summary>
        /// Used to enable or disable the plugin.
        /// </summary>
        public bool IsEnabled { get; set; }

        #endregion
    }
}
