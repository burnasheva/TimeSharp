// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IdentityConfig.cs" company="">
//   
// </copyright>
// <summary>
//   The application user manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Timesharp
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;
    using Microsoft.Owin.Security.DataProtection;

    using Timesharp.Models;
    using Timesharp.Models.EmployeeContext;

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    /// <summary>
    /// The application user manager.
    /// </summary>
    public class ApplicationUserManager : UserManager<User>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUserManager"/> class.
        /// </summary>
        /// <param name="store">
        /// The store.
        /// </param>
        public ApplicationUserManager(IUserStore<User> store)
            : base(store)
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="options">
        /// The options.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="ApplicationUserManager"/>.
        /// </returns>
        public static ApplicationUserManager Create(
            IdentityFactoryOptions<ApplicationUserManager> options, 
            IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<User>(context.Get<TimesharpDbContext>()));

            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<User>(manager)
                                        {
                                            AllowOnlyAlphanumericUserNames = false, 
                                            RequireUniqueEmail = true
                                        };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
                                            {
                                                RequiredLength = 6, 
                                                RequireNonLetterOrDigit = true, 
                                                RequireDigit = true, 
                                                RequireLowercase = true, 
                                                RequireUppercase = true, 
                                            };
            IDataProtectionProvider dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<User>(dataProtectionProvider.Create("ASP.NET Identity"));
            }

            return manager;
        }

        #endregion
    }
}