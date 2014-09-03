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
    using Timesharp.Models.EmployeeContext;

    /// <summary>
    /// The position.
    /// </summary>
    public class Position
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the hourly rate.
        /// </summary>
        public decimal HourlyRate { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        //TODO: should I have a connection to user from position

        #endregion

        // TODO: is hourly rate the best way to represent this?
    }
}