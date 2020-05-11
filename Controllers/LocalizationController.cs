using Microsoft.AspNetCore.Mvc;
using Nop.Services.Localization;
using Nop.Services.Logging;

namespace Ultimate.Localization.Controllers
{
    /// <summary>
    /// The localization controller is an api controller used in the ajax call to get the localization for the requested name.
    /// </summary>
    public class LocalizationController : BaseApiController
    {
        #region Fields

        private readonly ILocalizationService _localizationService;

        #endregion

        #region Constructor

        public LocalizationController(ILogger logger,
            ILocalizationService localizationService)
           : base(logger)
        {
            _localizationService = localizationService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get localization value by name.
        /// This controller will be called by the javascript when we need to get
        /// the localization.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{Name}")]
        public IActionResult GetLocalizationValueByName(string name)
        {
            var localization = _localizationService.GetLocaleStringResourceByName(name);
            if (localization == null)
                return Ok(name); //No resource found returning the name parameter

            return Ok(localization.ResourceValue);

        }

        #endregion
    }
}
