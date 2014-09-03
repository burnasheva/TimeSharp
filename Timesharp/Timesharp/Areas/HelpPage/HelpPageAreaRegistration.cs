// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HelpPageAreaRegistration.cs" company="">
//   
// </copyright>
// <summary>
//   The help page area registration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Timesharp.Areas.HelpPage
{
    using System.Web.Http;
    using System.Web.Mvc;

    /// <summary>
    /// The help page area registration.
    /// </summary>
    public class HelpPageAreaRegistration : AreaRegistration
    {
        #region Public Properties

        /// <summary>
        /// Gets the area name.
        /// </summary>
        public override string AreaName
        {
            get
            {
                return "HelpPage";
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The register area.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "HelpPage_Default", 
                "Help/{action}/{apiId}", 
                new { controller = "Help", action = "Index", apiId = UrlParameter.Optional });

            HelpPageConfig.Register(GlobalConfiguration.Configuration);
        }

        #endregion
    }
}