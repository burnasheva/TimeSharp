// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IdentityModels.cs" company="">
//   
// </copyright>
// <summary>
//   The roles.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Timesharp.Models
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Timesharp.Models.EmployeeContext;

    /// <summary>
    ///     The timesharp db context.
    /// </summary>
    public class TimesharpDbContext : IdentityDbContext<User>
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="TimesharpDbContext" /> class.
        /// </summary>
        public TimesharpDbContext()
            : base("DefaultConnection", false)
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the employment periods.
        /// </summary>
        public DbSet<EmploymentPeriod> EmploymentPeriods { get; set; }

        /// <summary>
        /// Gets or sets the positions.
        /// </summary>
        public DbSet<Position> Positions { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The create.
        /// </summary>
        /// <returns>
        ///     The <see cref="TimesharpDbContext" />.
        /// </returns>
        public static TimesharpDbContext Create()
        {
            return new TimesharpDbContext();
        }

        #endregion
    }
}