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
    /// The roles.
    /// </summary>
    public static class RoleNames
    {
        // User can set their own hours.
        #region Constants

        /// <summary>
        /// The employee.
        /// </summary>
        public const string Employee = "employee";

        // Manager has access to setting pay for employees. 
        // TODO: Managers can modify hours of employee with approval of employee. Maybe?

        // Executives can set and remove managers. Executives must vote together to remove an executive. 
        /// <summary>
        /// The executive.
        /// </summary>
        public const string Executive = "executive";

        /// <summary>
        /// The manager.
        /// </summary>
        public const string Manager = "manager";

        #endregion
    }

    /// <summary>
    /// The timesharp db context.
    /// </summary>
    public class TimesharpDbContext : IdentityDbContext<User>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TimesharpDbContext"/> class.
        /// </summary>
        public TimesharpDbContext()
            : base("DefaultConnection", false)
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the employment periods.
        /// </summary>
        public DbSet<EmploymentPeriod> EmploymentPeriods { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The create.
        /// </summary>
        /// <returns>
        /// The <see cref="TimesharpDbContext"/>.
        /// </returns>
        public static TimesharpDbContext Create()
        {
            return new TimesharpDbContext();
        }

        #endregion
    }
}