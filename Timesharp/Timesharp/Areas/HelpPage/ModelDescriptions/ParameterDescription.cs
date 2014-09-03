// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterDescription.cs" company="">
//   
// </copyright>
// <summary>
//   The parameter description.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Timesharp.Areas.HelpPage.ModelDescriptions
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// The parameter description.
    /// </summary>
    public class ParameterDescription
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterDescription"/> class.
        /// </summary>
        public ParameterDescription()
        {
            this.Annotations = new Collection<ParameterAnnotation>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the annotations.
        /// </summary>
        public Collection<ParameterAnnotation> Annotations { get; private set; }

        /// <summary>
        /// Gets or sets the documentation.
        /// </summary>
        public string Documentation { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type description.
        /// </summary>
        public ModelDescription TypeDescription { get; set; }

        #endregion
    }
}