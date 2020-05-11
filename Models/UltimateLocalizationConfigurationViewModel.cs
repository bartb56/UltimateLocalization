using Nop.Web.Framework.Mvc.ModelBinding;

namespace Ultimate.Localization.Models
{
    /// <summary>
    /// Ultimate localization configuration view model.
    /// </summary>
    public class UltimateLocalizationConfigurationViewModel
    {
        #region Constructors

        public UltimateLocalizationConfigurationViewModel()
        {

        }

        public UltimateLocalizationConfigurationViewModel(bool isEnabled)
        {
            IsEnabled = isEnabled;
        }

        #endregion

        #region Field

        /// <summary>
        /// Determines if the plugin is enabled and should load the javascript.
        /// </summary>
        [NopResourceDisplayName(UltimateLocalizationResources.IsEnabled)]
        public bool IsEnabled { get; set; }

        #endregion
    }
}
