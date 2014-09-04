// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Position.cs" company="">
//   
// </copyright>
// <summary>
//   The position.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Timesharp.Models
{
    /// <summary>
    ///     The position.
    /// </summary>
    public class Position
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the hourly rate. TODO confirm hourly rate is the best way to represent this
        /// </summary>
        public decimal HourlyRate { get; set; }

        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        #endregion

        // TODO: should I have a connection to user from position
    }
}