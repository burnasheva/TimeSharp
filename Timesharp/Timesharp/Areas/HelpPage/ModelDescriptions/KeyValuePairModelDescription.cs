// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KeyValuePairModelDescription.cs" company="">
//   
// </copyright>
// <summary>
//   The key value pair model description.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Timesharp.Areas.HelpPage.ModelDescriptions
{
    /// <summary>
    /// The key value pair model description.
    /// </summary>
    public class KeyValuePairModelDescription : ModelDescription
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the key model description.
        /// </summary>
        public ModelDescription KeyModelDescription { get; set; }

        /// <summary>
        /// Gets or sets the value model description.
        /// </summary>
        public ModelDescription ValueModelDescription { get; set; }

        #endregion
    }
}