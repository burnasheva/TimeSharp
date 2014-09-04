// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.Auth.cs" company="">
//   
// </copyright>
// <summary>
//   The startup.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Timesharp
{
    using System;

    using Microsoft.AspNet.Identity;
    using Microsoft.Owin;
    using Microsoft.Owin.Security.Cookies;
    using Microsoft.Owin.Security.OAuth;

    using Owin;

    using Timesharp.Models;
    using Timesharp.Providers;

    /// <summary>
    ///     The startup.
    /// </summary>
    public partial class Startup
    {
        #region Public Properties

        /// <summary>
        ///     Gets the o auth options.
        /// </summary>
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        /// <summary>
        ///     Gets the public client id.
        /// </summary>
        public static string PublicClientId { get; private set; }

        #endregion

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        #region Public Methods and Operators

        /// <summary>
        /// The configure auth.
        /// </summary>
        /// <param name="app">
        /// The app.
        /// </param>
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(TimesharpDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Configure the application for OAuth based flow
            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
                               {
                                   TokenEndpointPath = new PathString("/Token"), 
                                   Provider = new ApplicationOAuthProvider(PublicClientId), 
                                   AuthorizeEndpointPath =
                                       new PathString("/api/Account/ExternalLogin"), 
                                   AccessTokenExpireTimeSpan = TimeSpan.FromDays(14), 
                                   AllowInsecureHttp = true
                               };

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);

            // Uncomment the following lines to enable logging in with third party login providers
            // app.UseMicrosoftAccountAuthentication(
            // clientId: "",
            // clientSecret: "");

            // app.UseTwitterAuthentication(
            // consumerKey: "",
            // consumerSecret: "");

            // app.UseFacebookAuthentication(
            // appId: "",
            // appSecret: "");

            // app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            // {
            // ClientId = "",
            // ClientSecret = ""
            // });
        }

        #endregion
    }
}