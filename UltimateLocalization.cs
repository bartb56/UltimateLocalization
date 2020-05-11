using Nop.Core;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using System.Collections.Generic;
using Ultimate.Localization.Infrastructure;

namespace Ultimate.Localization
{
    public class UltimateLocalization : BasePlugin
    {
        #region Fields

        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;
        private readonly ILocalizationService _localizationService;

        #endregion

        #region Ctor

        public UltimateLocalization(ISettingService settingService,
            IWebHelper webHelper,
            ILocalizationService localizationService)
        {
            _settingService = settingService;
            _webHelper = webHelper;
            _localizationService = localizationService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Install the ultimate localization plugin.
        /// In the installation process the plugin will setup the default settings and localization.
        /// </summary>
        public override void Install()
        {
            //Add default localization
            InstallLocalization();

            //Add default settings
            InstallSettings();

            base.Install();
        }

        /// <summary>
        /// Installs the ultimate localization resources.
        /// </summary>
        private void InstallLocalization()
        {
            _localizationService.AddPluginLocaleResource(new Dictionary<string, string>
            {
                [UltimateLocalizationResources.ConfigureTitle] = "Ultimate Localization",
                [UltimateLocalizationResources.IsEnabled] = "Is enabled",
                [UltimateLocalizationResources.SavedPluginSetings] = "Ultimate Localization settings have successfully been saved.",
            });
        }

        /// <summary>
        /// Installs the default ultimate localization settings.
        /// </summary>
        private void InstallSettings()
        {
            var settings = new UltimateLocalizationSettings()
            {
                IsEnabled = true
            };

            _settingService.SaveSetting(settings);
        }


        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return _webHelper.GetStoreLocation() + "Admin/UltimateLocalization/Configure";
        }

        /// <summary>
        /// Uninstall the ultimate localization plugin.
        /// When the plugin is uninstalled I remove the settings and localization.
        /// </summary>
        public override void Uninstall()
        {
            //Remove default localization
            UninstallLocalization();

            //Remove settings
            UninstallSettings();
            base.Uninstall();
        }

        /// <summary>
        /// Remove the ultimate localization resources.
        /// </summary>
        private void UninstallLocalization()
        {
            _localizationService.DeletePluginLocaleResources(UltimateLocalizationResources.Base);
        }

        /// <summary>
        /// Uninstall the ultimate localization settings.
        /// </summary>
        private void UninstallSettings()
        {
            _settingService.DeleteSetting<UltimateLocalizationSettings>();
        }

        #endregion
    }
}
