// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmploymentPeriod.cs" company="">
//   
// </copyright>
// <summary>
//   The employment period.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Timesharp.Models
{
    using System;

    using Timesharp.Models.EmployeeContext;

    /// <summary>
    ///     The employment period.
    /// </summary>
    public class EmploymentPeriod
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