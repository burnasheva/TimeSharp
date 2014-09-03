// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="">
//   
// </copyright>
// <summary>
//   The User interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Timesharp.Models.EmployeeContext
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    /// <summary>
    /// The User interface.
    /// </summary>
    public interface IUser
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the current position.
        /// </summary>
        Position CurrentPosition { get; set; }

        /// <summary>
        /// Gets or sets the employment periods.
        /// </summary>
        IEnumerable<EmploymentPeriod> EmploymentPeriods { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        string LastName { get; set; }

        /// <summary>
        /// Gets or sets the middle name.
        /// </summary>
        string MiddleName { get; set; }

        #endregion
    }

    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    /// <summary>
    /// The user.
    /// </summary>
    public class User : IdentityUser, IUser
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the current position.
        /// </summary>
        public Position CurrentPosition { get; set; }

        /// <summary>
        /// Gets or sets the employment periods.
        /// </summary>
        public virtual IEnumerable<EmploymentPeriod> EmploymentPeriods { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the middle name.
        /// </summary>
        public string MiddleName { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The generate user identity async.
        /// </summary>
        /// <param name="manager">
        /// The manager.
        /// </param>
        /// <param name="authenticationType">
        /// The authentication type.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(
            UserManager<User> manager, 
            string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            ClaimsIdentity userIdentity = await manager.CreateIdentityAsync(this, authenticationType);

            // Add custom user claims here
            return userIdentity;
        }

        #endregion
    }
}