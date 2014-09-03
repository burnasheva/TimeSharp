// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidSample.cs" company="">
//   
// </copyright>
// <summary>
//   This represents an invalid sample on the help page. There's a display template named InvalidSample associated with
//   this class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Timesharp.Areas.HelpPage
{
    using System;

    /// <summary>
    ///     This represents an invalid sample on the help page. There's a display template named InvalidSample associated with
    ///     this class.
    /// </summary>
    public class InvalidSample
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidSample"/> class.
        /// </summary>
        /// <param name="errorMessage">
        /// The error message.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public InvalidSample(string errorMessage)
        {
            if (errorMessage == null)
            {
                throw new ArgumentNullException("errorMessage");
            }

            this.ErrorMessage = errorMessage;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the error message.
        /// </summary>
        public string ErrorMessage { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            var other = obj as InvalidSample;
            return other != null && this.ErrorMessage == other.ErrorMessage;
        }

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return this.ErrorMessage.GetHashCode();
        }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return this.ErrorMessage;
        }

        #endregion
    }
}