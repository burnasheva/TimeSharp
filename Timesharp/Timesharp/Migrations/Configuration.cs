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

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Timesharp.Models;

    /// <summary>
    /// The configuration.
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<TimesharpDbContext>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
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
            this.CreateRoleIfNotExists(context, Roles.Employee);
            this.CreateRoleIfNotExists(context, Roles.Manager);
            this.CreateRoleIfNotExists(context, Roles.Executive);

            // TODO create executive user.

            // This method will be called after migrating to the latest version.

            // You can use the DbSet<T>.AddOrUpdate() helper extension method 
            // to avoid creating duplicate seed data. E.g.
            // context.People.AddOrUpdate(
            // p => p.FullName,
            // new Person { FullName = "Andrew Peters" },
            // new Person { FullName = "Brice Lambson" },
            // new Person { FullName = "Rowan Miller" }
            // );
        }

        /// <summary>
        /// The create role if not exists.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="role">
        /// The role.
        /// </param>
        private void CreateRoleIfNotExists(TimesharpDbContext context, string role)
        {
            // See https://stackoverflow.com/questions/21170525/cant-connect-to-database-to-execute-identity-functions
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists(role))
            {
                roleManager.Create(new IdentityRole(role));
            }
        }

        #endregion
    }
}