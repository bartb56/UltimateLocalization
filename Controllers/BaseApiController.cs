using Microsoft.AspNetCore.Mvc;
using Nop.Services.Logging;
using System.Net;
using Nop.Core.Domain.Logging;

namespace Ultimate.Localization.Controllers
{
    /// <summary>
    /// This is the base api controller we use for all the other controllers.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class BaseApiController : Controller
    {

        #region Fields

        private readonly ILogger _logger;

        #endregion

        #region Constructor

        public BaseApiController(ILogger logger)
        {
            _logger = logger;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Error handling
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="propertyKey"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        protected IActionResult Error(HttpStatusCode statusCode = (HttpStatusCode)422, string propertyKey = "", string errorMessage = "")
        {
            _logger.InsertLog(LogLevel.Error, errorMessage);

            //Return the view.
            return View();
        }

        #endregion

    }
}
