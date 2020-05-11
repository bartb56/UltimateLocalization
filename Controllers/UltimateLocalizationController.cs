using Microsoft.AspNetCore.Mvc;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Ultimate.Localization.Infrastructure;
using Ultimate.Localization.Models;

namespace Ultimate.Localization.Controllers
{
    [Area(AreaNames.Admin)]
    [AutoValidateAntiforgeryToken]
    public class UltimateLocalizationController : BasePluginController
    {

        #region Fields

        private readonly ISettingService _settingService;
        private readonly INotificationService _notificationService;
        private readonly ILocalizationService _localizationService;

        #endregion

        #region Ctor

        public UltimateLocalizationController(ISettingService settingService,
            INotificationService notificationService,
            ILocalizationService localizationService)
        {
            _settingService = settingService;
            _notificationService = notificationService;
            _localizationService = localizationService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Load the ultimate localization configure page
        /// </summary>
        /// <returns></returns>
        public IActionResult Configure()
        {
            var settings = _settingService.LoadSetting<UltimateLocalizationSettings>();
            var model = new UltimateLocalizationConfigurationViewModel(settings.IsEnabled);

            return View("~/Plugins/Ultimate.Localization/Views/Configure.cshtml", model);
        }


        /// <summary>
        /// This method is used to update the ultimate localization settings.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Configure(UltimateLocalizationConfigurationViewModel model)
        {
            var settings = _settingService.LoadSetting<UltimateLocalizationSettings>();
            settings.IsEnabled = model.IsEnabled;
            _settingService.SaveSetting(settings);

            var text = _localizationService.GetLocaleStringResourceByName(UltimateLocalizationResources.SavedPluginSetings);

            if (text != null)
                _notificationService.SuccessNotification(text.ResourceValue);
            else
                _notificationService.SuccessNotification("Updated the plugin");

            return View("~/Plugins/Ultimate.Localization/Views/Configure.cshtml", model);
        }

        #endregion
    }
}
