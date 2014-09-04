// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimeEntry.cs" company="">
//   
// </copyright>
// <summary>
//   The TimeEntry interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Timesharp.Models
{
    using System;

    using Timesharp.Models.EmployeeContext;

    /// <summary>
    ///     The TimeEntry interface.
    /// </summary>
    public interface ITimeEntry
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the end.
        /// </summary>
        DateTime End { get; set; }

        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        int ID { get; set; }

        /// <summary>
        ///     Gets or sets the position.
        /// </summary>
        Position Position { get; set; }

        /// <summary>
        ///     Gets or sets the start.
        /// </summary>
        DateTime Start { get; set; }

        /// <summary>
        ///     Gets or sets the user.
        /// </summary>
        User User { get; set; }

        #endregion
    }

    /// <summary>
    ///     The time entry.
    /// </summary>
    public class TimeEntry
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the end.
        /// </summary>
        public DateTime End { get; set; }

        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        ///     Gets or sets the position.
        /// </summary>
        public virtual Position Position { get; set; }

        /// <summary>
        ///     Gets or sets the start.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        ///     Gets or sets the user.
        /// </summary>
        public virtual User User { get; set; }

        #endregion
    }
}