// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoleHelper.cs" company="">
//   
// </copyright>
// <summary>
//   The roles.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Timesharp.Models
{
    /// <summary>
    ///     The roles.
    /// </summary>
    public static class RoleHelper
    {
        // User can set their own hours.
        #region Constants

        /// <summary>
        ///     The employee.
        /// </summary>
        public const string Employee = "employee";

        /// <summary>
        ///     Manager has access to setting positions for employees, and creating new employees.
        /// </summary>
        public const string Manager = "manager";

        #endregion
    }
}