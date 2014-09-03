// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextSample.cs" company="">
//   
// </copyright>
// <summary>
//   This represents a preformatted text sample on the help page. There's a display template named TextSample associated
//   with this class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Timesharp.Areas.HelpPage
{
    using System;

    /// <summary>
    ///     This represents a preformatted text sample on the help page. There's a display template named TextSample associated
    ///     with this class.
    /// </summary>
    public class TextSample
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TextSample"/> class.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public TextSample(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            this.Text = text;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the text.
        /// </summary>
        public string Text { get; private set; }

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
            var other = obj as TextSample;
            return other != null && this.Text == other.Text;
        }

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return this.Text.GetHashCode();
        }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return this.Text;
        }

        #endregion
    }
}