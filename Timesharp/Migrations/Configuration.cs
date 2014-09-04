// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Configuration.cs" company="">
//   
// </copyright>
// <summary>
//   The configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Timesharp.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Timesharp.Models;
    using Timesharp.Models.EmployeeContext;

    /// <summary>
    ///     The configuration. See
    ///     http://www.asp.net/web-api/overview/creating-web-apis/using-web-api-with-entity-framework/part-3
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<TimesharpDbContext>
    {
        // TODO document this admin account somewhere?
        #region Constants

        /// <summary>
        ///     The admin password.
        /// </summary>
        private const string AdminPassword = "1337pa$$word";

        /// <summary>
        ///     The admin user name.
        /// </summary>
        private const string AdminUserName = "admin";

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Configuration" /> class.
        /// </summary>
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The seed.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        protected override void Seed(TimesharpDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            this.CreateRoleIfNotExists(roleManager, RoleHelper.Employee);
            this.CreateRoleIfNotExists(roleManager, RoleHelper.Manager);
            context.SaveChanges();

            if (!context.Users.Any(u => u.UserName == AdminUserName))
            {
                var userManager = new UserManager<User>(new UserStore<User>(context));
                var user = new User { UserName = AdminUserName };

                userManager.Create(user, AdminPassword);
                userManager.AddToRole(user.Id, RoleHelper.Manager);
            }

            context.SaveChanges();
        }

        /// <summary>
        /// The create role if not exists.
        /// </summary>
        /// <param name="roleManager">
        /// The role Manager.
        /// </param>
        /// <param name="roleName">
        /// The role Name.
        /// </param>
        private void CreateRoleIfNotExists(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (!roleManager.RoleExists(roleName))
            {
                var role = new IdentityRole { Name = roleName };
                roleManager.Create(role);
            }
        }

        #endregion
    }
}