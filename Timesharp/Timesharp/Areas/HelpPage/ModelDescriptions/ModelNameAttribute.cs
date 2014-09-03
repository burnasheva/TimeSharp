// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModelNameAttribute.cs" company="">
//   
// </copyright>
// <summary>
//   Use this attribute to change the name of the <see cref="ModelDescription" /> generated for a type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Timesharp.Areas.HelpPage.ModelDescriptions
{
    using System;

    /// <summary>
    ///     Use this attribute to change the name of the <see cref="ModelDescription" /> generated for a type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum, AllowMultiple = false, 
        Inherited = false)]
    public sealed class ModelNameAttribute : Attribute
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelNameAttribute"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        public ModelNameAttribute(string name)
        {
            this.Name = name;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }

        #endregion
    }
}