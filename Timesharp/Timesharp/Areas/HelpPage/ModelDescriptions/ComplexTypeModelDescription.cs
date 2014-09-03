// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ComplexTypeModelDescription.cs" company="">
//   
// </copyright>
// <summary>
//   The complex type model description.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Timesharp.Areas.HelpPage.ModelDescriptions
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// The complex type model description.
    /// </summary>
    public class ComplexTypeModelDescription : ModelDescription
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ComplexTypeModelDescription"/> class.
        /// </summary>
        public ComplexTypeModelDescription()
        {
            this.Properties = new Collection<ParameterDescription>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the properties.
        /// </summary>
        public Collection<ParameterDescription> Properties { get; private set; }

        #endregion
    }
}