
        /// <summary>
        /// The add external login.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [Route("AddExternalLogin")]
        public async Task<IHttpActionResult> AddExternalLogin(AddExternalLoginBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);

            AuthenticationTicket ticket = this.AccessTokenFormat.Unprotect(model.ExternalAccessToken);

            if (ticket == null || ticket.Identity == null
                || (ticket.Properties != null && ticket.Properties.ExpiresUtc.HasValue
                    && ticket.Properties.ExpiresUtc.Value < DateTimeOffset.UtcNow))
            {
                return this.BadRequest("External login failure.");
            }

            ExternalLoginData externalData = ExternalLoginData.FromIdentity(ticket.Identity);

            if (externalData == null)
            {
                return this.BadRequest("The external login is already associated with an account.");
            }

            IdentityResult result =
                await
                this.UserManager.AddLoginAsync(
                    this.User.Identity.GetUserId(),
                    new UserLoginInfo(externalData.LoginProvider, externalData.ProviderKey));

            if (!result.Succeeded)
            {
                return this.GetErrorResult(result);
            }

            return this.Ok();
        }


        /// <summary>
        /// The get external login.
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <param name="error">
        /// The error.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [OverrideAuthentication]
        [HostAuthentication(DefaultAuthenticationTypes.ExternalCookie)]
        [AllowAnonymous]
        [Route("ExternalLogin", Name = "ExternalLogin")]
        public async Task<IHttpActionResult> GetExternalLogin(string provider, string error = null)
        {
            if (error != null)
            {
                return this.Redirect(this.Url.Content("~/") + "#error=" + Uri.EscapeDataString(error));
            }

            if (!this.User.Identity.IsAuthenticated)
            {
                return new ChallengeResult(provider, this);
            }

            ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(this.User.Identity as ClaimsIdentity);

            if (externalLogin == null)
            {
                return this.InternalServerError();
            }

            if (externalLogin.LoginProvider != provider)
            {
                this.Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                return new ChallengeResult(provider, this);
            }

            User user =
                await
                this.UserManager.FindAsync(new UserLoginInfo(externalLogin.LoginProvider, externalLogin.ProviderKey));

            bool hasRegistered = user != null;

            if (hasRegistered)
            {
                this.Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);

                ClaimsIdentity oAuthIdentity =
                    await user.GenerateUserIdentityAsync(this.UserManager, OAuthDefaults.AuthenticationType);
                ClaimsIdentity cookieIdentity =
                    await
                    user.GenerateUserIdentityAsync(this.UserManager, CookieAuthenticationDefaults.AuthenticationType);

                AuthenticationProperties properties = ApplicationOAuthProvider.CreateProperties(user.UserName);
                this.Authentication.SignIn(properties, oAuthIdentity, cookieIdentity);
            }
            else
            {
                IEnumerable<Claim> claims = externalLogin.GetClaims();
                var identity = new ClaimsIdentity(claims, OAuthDefaults.AuthenticationType);
                this.Authentication.SignIn(identity);
            }

            return this.Ok();
        }

        // GET api/Account/ExternalLogins?returnUrl=%2F&generateState=true
        /// <summary>
        /// The get external logins.
        /// </summary>
        /// <param name="returnUrl">
        /// The return url.
        /// </param>
        /// <param name="generateState">
        /// The generate state.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        [AllowAnonymous]
        [Route("ExternalLogins")]
        public IEnumerable<ExternalLoginViewModel> GetExternalLogins(string returnUrl, bool generateState = false)
        {
            IEnumerable<AuthenticationDescription> descriptions = this.Authentication.GetExternalAuthenticationTypes();
            var logins = new List<ExternalLoginViewModel>();

            string state;

            if (generateState)
            {
                const int strengthInBits = 256;
                state = RandomOAuthStateGenerator.Generate(strengthInBits);
            }
            else
            {
                state = null;
            }

            foreach (AuthenticationDescription description in descriptions)
            {
                var login = new ExternalLoginViewModel
                                {
                                    Name = description.Caption,
                                    Url =
                                        this.Url.Route(
                                            "ExternalLogin",
                                            new
                                                {
                                                    provider = description.AuthenticationType,
                                                    response_type = "token",
                                                    client_id = Startup.PublicClientId,
                                                    redirect_uri =
                                        new Uri(this.Request.RequestUri, returnUrl).AbsoluteUri,
                                                    state
                                                }),
                                    State = state
                                };
                logins.Add(login);
            }

            return logins;
        }



        /// <summary>
        /// The get manage info.
        /// </summary>
        /// <param name="returnUrl">
        /// The return url.
        /// </param>
        /// <param name="generateState">
        /// The generate state.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [Route("ManageInfo")]
        public async Task<ManageInfoViewModel> GetManageInfo(string returnUrl, bool generateState = false)
        {
            IdentityUser user = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());

            if (user == null)
            {
                return null;
            }

            var logins = new List<UserLoginInfoViewModel>();

            foreach (IdentityUserLogin linkedAccount in user.Logins)
            {
                logins.Add(
                    new UserLoginInfoViewModel
                        {
                            LoginProvider = linkedAccount.LoginProvider,
                            ProviderKey = linkedAccount.ProviderKey
                        });
            }

            if (user.PasswordHash != null)
            {
                logins.Add(
                    new UserLoginInfoViewModel { LoginProvider = LocalLoginProvider, ProviderKey = user.UserName, });
            }

            return new ManageInfoViewModel
                       {
                           LocalLoginProvider = LocalLoginProvider,
                           Email = user.UserName,
                           Logins = logins,
                           ExternalLoginProviders = this.GetExternalLogins(returnUrl, generateState)
                       };
        }

        // POST api/Account/RegisterExternal
        /// <summary>
        /// The register external.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [OverrideAuthentication]
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("RegisterExternal")]
        public async Task<IHttpActionResult> RegisterExternal(RegisterExternalBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            ExternalLoginInfo info = await this.Authentication.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return this.InternalServerError();
            }

            var user = new User { UserName = model.Email, Email = model.Email };

            IdentityResult result = await this.UserManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                return this.GetErrorResult(result);
            }

            result = await this.UserManager.AddLoginAsync(user.Id, info.Login);
            if (!result.Succeeded)
            {
                return this.GetErrorResult(result);
            }

            return this.Ok();
        }


                /// <summary>
        ///     The random o auth state generator.
        /// </summary>
        private static class RandomOAuthStateGenerator
        {
            #region Static Fields

            /// <summary>
            ///     The _random.
            /// </summary>
            private static readonly RandomNumberGenerator _random = new RNGCryptoServiceProvider();

            #endregion

            #region Public Methods and Operators

            /// <summary>
            /// The generate.
            /// </summary>
            /// <param name="strengthInBits">
            /// The strength in bits.
            /// </param>
            /// <returns>
            /// The <see cref="string"/>.
            /// </returns>
            /// <exception cref="ArgumentException">
            /// </exception>
            public static string Generate(int strengthInBits)
            {
                const int bitsPerByte = 8;

                if (strengthInBits % bitsPerByte != 0)
                {
                    throw new ArgumentException("strengthInBits must be evenly divisible by 8.", "strengthInBits");
                }

                int strengthInBytes = strengthInBits / bitsPerByte;

                var data = new byte[strengthInBytes];
                _random.GetBytes(data);
                return HttpServerUtility.UrlTokenEncode(data);
            }

            #endregion
        }


                /// <summary>
        ///     The get user info.
        /// </summary>
        /// <returns>
        ///     The <see cref="UserInfoViewModel" />.
        /// </returns>
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("UserInfo")]
        public UserInfoViewModel GetUserInfo()
        {
            ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(this.User.Identity as ClaimsIdentity);

            return new UserInfoViewModel
                       {
                           Email = this.User.Identity.GetUserName(),
                           HasRegistered = externalLogin == null,
                           LoginProvider = externalLogin != null ? externalLogin.LoginProvider : null
                       };
        }

                /// <summary>
        ///     The external login data.
        /// </summary>
        private class ExternalLoginData
        {
            #region Public Properties

            /// <summary>
            ///     Gets or sets the login provider.
            /// </summary>
            public string LoginProvider { get; set; }

            /// <summary>
            ///     Gets or sets the provider key.
            /// </summary>
            public string ProviderKey { get; set; }

            /// <summary>
            ///     Gets or sets the user name.
            /// </summary>
            public string UserName { get; set; }

            #endregion

            #region Public Methods and Operators

            /// <summary>
            /// The from identity.
            /// </summary>
            /// <param name="identity">
            /// The identity.
            /// </param>
            /// <returns>
            /// The <see cref="ExternalLoginData"/>.
            /// </returns>
            public static ExternalLoginData FromIdentity(ClaimsIdentity identity)
            {
                if (identity == null)
                {
                    return null;
                }

                Claim providerKeyClaim = identity.FindFirst(ClaimTypes.NameIdentifier);

                if (providerKeyClaim == null || string.IsNullOrEmpty(providerKeyClaim.Issuer)
                    || string.IsNullOrEmpty(providerKeyClaim.Value))
                {
                    return null;
                }

                if (providerKeyClaim.Issuer == ClaimsIdentity.DefaultIssuer)
                {
                    return null;
                }

                return new ExternalLoginData
                           {
                               LoginProvider = providerKeyClaim.Issuer,
                               ProviderKey = providerKeyClaim.Value,
                               UserName = identity.FindFirstValue(ClaimTypes.Name)
                           };
            }

            /// <summary>
            ///     The get claims.
            /// </summary>
            /// <returns>
            ///     The <see cref="IList" />.
            /// </returns>
            public IList<Claim> GetClaims()
            {
                IList<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, this.ProviderKey, null, this.LoginProvider));

                if (this.UserName != null)
                {
                    claims.Add(new Claim(ClaimTypes.Name, this.UserName, null, this.LoginProvider));
                }

                return claims;
            }

            #endregion
        }
