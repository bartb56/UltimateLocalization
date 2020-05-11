using Nop.Services.Configuration;
using Nop.Services.Events;
using Nop.Web.Framework.Events;
using Nop.Web.Framework.UI;
using Ultimate.Localization.Infrastructure;

namespace Ultimate.Localization.EventConsumers
{
    /// <summary>
    /// This class is used to handle nopcommerce events.
    /// </summary>
    public class PageRenderEventConsumer : IConsumer<PageRenderingEvent>
    {
        #region Fields

        private readonly ISettingService _settingService;

        #endregion

        #region Constructor
        public PageRenderEventConsumer(ISettingService settingService)
        {
            _settingService = settingService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The page render event is used to directly add the localization js to every page.
        /// </summary>
        /// <param name="eventMessage"></param>
        public void HandleEvent(PageRenderingEvent eventMessage)
        {
            if (!ShouldRender())
                return;

            eventMessage.Helper.AddScriptParts(ResourceLocation.Footer, $"~/Plugins/Ultimate.Localization/Content/js/localization.js", "", true, false);
        }

        /// <summary>
        /// Check if we actualy want to render the javascript.
        /// </summary>
        /// <returns></returns>
        private bool ShouldRender()
        {
            var settings = _settingService.LoadSetting<UltimateLocalizationSettings>();

            //Plugin is turned of.
            if (!settings.IsEnabled)
                return false;

            return true;
        }

        #endregion

    }
}
