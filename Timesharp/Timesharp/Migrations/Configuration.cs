namespace Timesharp.Migrations
{
    using System.Data.Entity.Migrations;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.TimesharpDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Models.TimesharpDbContext context)
        {
            CreateRoleIfNotExists(context, Models.Roles.Employee);
            CreateRoleIfNotExists(context, Models.Roles.Manager);
            CreateRoleIfNotExists(context, Models.Roles.Executive);

            // TODO create executive user.


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }

        private void CreateRoleIfNotExists(Models.TimesharpDbContext context, string role)
        {
            // See https://stackoverflow.com/questions/21170525/cant-connect-to-database-to-execute-identity-functions
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists(role))
            {
                roleManager.Create(new IdentityRole(role));
            }
        }
    }
}
