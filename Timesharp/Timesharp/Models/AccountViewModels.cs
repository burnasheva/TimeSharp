// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountViewModels.cs" company="">
//   
// </copyright>
// <summary>
//   The external login view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Timesharp.Models
{
    using System.Collections.Generic;

    // Models returned by AccountController actions.

    /// <summary>
    /// The external login view model.
    /// </summary>
    public class ExternalLoginViewModel
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        public string Url { get; set; }

        #endregion
    }

    /// <summary>
    /// The manage info view model.
    /// </summary>
    public class ManageInfoViewModel
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the external login providers.
        /// </summary>
        public IEnumerable<ExternalLoginViewModel> ExternalLoginProviders { get; set; }

        /// <summary>
        /// Gets or sets the local login provider.
        /// </summary>
        public string LocalLoginProvider { get; set; }

        /// <summary>
        /// Gets or sets the logins.
        /// </summary>
        public IEnumerable<UserLoginInfoViewModel> Logins { get; set; }

        #endregion
    }

    /// <summary>
    /// The user info view model.
    /// </summary>
    public class UserInfoViewModel
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether has registered.
        /// </summary>
        public bool HasRegistered { get; set; }

        /// <summary>
        /// Gets or sets the login provider.
        /// </summary>
        public string LoginProvider { get; set; }

        #endregion
    }

    /// <summary>
    /// The user login info view model.
    /// </summary>
    public class UserLoginInfoViewModel
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the login provider.
        /// </summary>
        public string LoginProvider { get; set; }

        /// <summary>
        /// Gets or sets the provider key.
        /// </summary>
        public string ProviderKey { get; set; }

        #endregion
    }
}