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
    using System;
    using System.Data.Entity;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Timesharp.Models.EmployeeContext;

    /// <summary>
    /// The TimesharpDbContext interface.
    /// </summary>
    public interface ITimesharpDbContext
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the employment periods.
        /// </summary>
        DbSet<EmploymentPeriod> EmploymentPeriods { get; set; }

        /// <summary>
        ///     Gets or sets the positions.
        /// </summary>
        DbSet<Position> Positions { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The mark as modified.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        void MarkAsModified(object item);

        /// <summary>
        /// The save changes async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<int> SaveChangesAsync();

        void Dispose();

        #endregion
    }

    /// <summary>
    ///     The timesharp db context.
    /// </summary>
    public class TimesharpDbContext : IdentityDbContext<User>, ITimesharpDbContext
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
        ///     Gets or sets the positions.
        /// </summary>
        public DbSet<Position> Positions { get; set; }

        #endregion

        #region Public Methods and Operators

        public static TimesharpDbContext Create()
        {
            return new TimesharpDbContext();
        }

        /// <summary>
        /// The mark as modified.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public void MarkAsModified(object item)
        {
            // TODO should this be object?
            this.Entry(item).State = EntityState.Modified;
        }

        #endregion
    }
}