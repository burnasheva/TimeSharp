// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageSample.cs" company="">
//   
// </copyright>
// <summary>
//   This represents an image sample on the help page. There's a display template named ImageSample associated with this
//   class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Timesharp.Areas.HelpPage
{
    using System;

    /// <summary>
    ///     This represents an image sample on the help page. There's a display template named ImageSample associated with this
    ///     class.
    /// </summary>
    public class ImageSample
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageSample"/> class.
        /// </summary>
        /// <param name="src">
        /// The URL of an image.
        /// </param>
        public ImageSample(string src)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }

            this.Src = src;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the src.
        /// </summary>
        public string Src { get; private set; }

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
            var other = obj as ImageSample;
            return other != null && this.Src == other.Src;
        }

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return this.Src.GetHashCode();
        }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return this.Src;
        }

        #endregion
    }
}