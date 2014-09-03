// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HelpController.cs" company="">
//   
// </copyright>
// <summary>
//   The controller that will handle requests for the help page.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Timesharp.Areas.HelpPage.Controllers
{
    using System;
    using System.Web.Http;
    using System.Web.Mvc;

    using Timesharp.Areas.HelpPage.ModelDescriptions;
    using Timesharp.Areas.HelpPage.Models;

    /// <summary>
    ///     The controller that will handle requests for the help page.
    /// </summary>
    public class HelpController : Controller
    {
        #region Constants

        /// <summary>
        /// The error view name.
        /// </summary>
        private const string ErrorViewName = "Error";

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HelpController"/> class.
        /// </summary>
        public HelpController()
            : this(GlobalConfiguration.Configuration)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HelpController"/> class.
        /// </summary>
        /// <param name="config">
        /// The config.
        /// </param>
        public HelpController(HttpConfiguration config)
        {
            this.Configuration = config;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        public HttpConfiguration Configuration { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The api.
        /// </summary>
        /// <param name="apiId">
        /// The api id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Api(string apiId)
        {
            if (!string.IsNullOrEmpty(apiId))
            {
                HelpPageApiModel apiModel = this.Configuration.GetHelpPageApiModel(apiId);
                if (apiModel != null)
                {
                    return View(apiModel);
                }
            }

            return this.View(ErrorViewName);
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index()
        {
            this.ViewBag.DocumentationProvider = this.Configuration.Services.GetDocumentationProvider();
            return this.View(this.Configuration.Services.GetApiExplorer().ApiDescriptions);
        }

        /// <summary>
        /// The resource model.
        /// </summary>
        /// <param name="modelName">
        /// The model name.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult ResourceModel(string modelName)
        {
            if (!string.IsNullOrEmpty(modelName))
            {
                ModelDescriptionGenerator modelDescriptionGenerator = this.Configuration.GetModelDescriptionGenerator();
                ModelDescription modelDescription;
                if (modelDescriptionGenerator.GeneratedModels.TryGetValue(modelName, out modelDescription))
                {
                    return View(modelDescription);
                }
            }

            return this.View(ErrorViewName);
        }

        #endregion
    }
}