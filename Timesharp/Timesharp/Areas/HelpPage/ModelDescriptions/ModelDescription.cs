// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModelDescription.cs" company="">
//   
// </copyright>
// <summary>
//   Describes a type model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Timesharp.Areas.HelpPage.ModelDescriptions
{
    using System;

    /// <summary>
    ///     Describes a type model.
    /// </summary>
    public abstract class ModelDescription
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the documentation.
        /// </summary>
        public string Documentation { get; set; }

        /// <summary>
        /// Gets or sets the model type.
        /// </summary>
        public Type ModelType { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        #endregion
    }
}