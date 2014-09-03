using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Timesharp.Models.EmployeeContext;

namespace Timesharp.Models
{
    public static class Roles
    {
        // User can set their own hours.
        public const string Employee = "employee";

        // Manager has access to setting pay for employees. 
        // TODO: Managers can modify hours of employee with approval of employee. Maybe?
        public const string Manager = "manager";

        // Executives can set and remove managers. Executives must vote together to remove an executive. 
        public const string Executive = "executive";
    }

    public class TimesharpDbContext : IdentityDbContext<User>
    {
        public DbSet<EmploymentPeriod> EmploymentPeriods { get; set; }

        public TimesharpDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static TimesharpDbContext Create()
        {
            return new TimesharpDbContext();
        }
    }
}