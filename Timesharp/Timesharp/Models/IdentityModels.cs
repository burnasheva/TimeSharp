using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace Timesharp.Models
{
    // You can add profile data for the user by adding more properties to your Employee class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class Employee : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public virtual IEnumerable<EmploymentPeriod> EmploymentPeriods { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Employee> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }



    public static class Roles
    {
        // Employee can set their own hours.
        public const string Employee = "employee";

        // Manager has access to setting pay for employees. 
        // TODO: Managers can modify hours of employee with approval of employee. Maybe?
        public const string Manager = "manager";

        // Executives can set and remove managers. Executives must vote together to remove an executive. 
        public const string Executive = "executive";
    }

    public class ApplicationDbContext : IdentityDbContext<Employee>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}