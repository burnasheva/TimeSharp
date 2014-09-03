// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IModelDocumentationProvider.cs" company="">
//   
// </copyright>
// <summary>
//   The ModelDocumentationProvider interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Timesharp.Areas.HelpPage.ModelDescriptions
{
    using System;
    using System.Reflection;

    /// <summary>
    /// The ModelDocumentationProvider interface.
    /// </summary>
    public interface IModelDocumentationProvider
    {
        #region Public Methods and Operators

        /// <summary>
        /// The get documentation.
        /// </summary>
        /// <param name="member">
        /// The member.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string GetDocumentation(MemberInfo member);

        /// <summary>
        /// The get documentation.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string GetDocumentation(Type type);

        #endregion
    }
}