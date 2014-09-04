// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountBindingModels.cs" company="">
//   
// </copyright>
// <summary>
//   The add external login binding model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Timesharp.Models
{
    using System.ComponentModel.DataAnnotations;

    // Models used as parameters to AccountController actions.

    /// <summary>
    ///     The add external login binding model.
    /// </summary>
    public class AddExternalLoginBindingModel
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the external access token.
        /// </summary>
        [Required]
        [Display(Name = "External access token")]
        public string ExternalAccessToken { get; set; }

        #endregion
    }

    /// <summary>
    ///     The change password binding model.
    /// </summary>
    public class ChangePasswordBindingModel
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the confirm password.
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        ///     Gets or sets the new password.
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        /// <summary>
        ///     Gets or sets the old password.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        #endregion
    }

    /// <summary>
    ///     The register binding model.
    /// </summary>
    public class RegisterBindingModel
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the confirm password.
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        ///     Gets or sets the password.
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        #endregion
    }

    /// <summary>
    ///     The register external binding model.
    /// </summary>
    public class RegisterExternalBindingModel
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        #endregion
    }

    /// <summary>
    ///     The remove login binding model.
    /// </summary>
    public class RemoveLoginBindingModel
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the login provider.
        /// </summary>
        [Required]
        [Display(Name = "Login provider")]
        public string LoginProvider { get; set; }

        /// <summary>
        ///     Gets or sets the provider key.
        /// </summary>
        [Required]
        [Display(Name = "Provider key")]
        public string ProviderKey { get; set; }

        #endregion
    }

    /// <summary>
    ///     The set password binding model.
    /// </summary>
    public class SetPasswordBindingModel
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the confirm password.
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        ///     Gets or sets the new password.
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        #endregion
    }
}