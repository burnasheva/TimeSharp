// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChallengeResult.cs" company="">
//   
// </copyright>
// <summary>
//   The challenge result.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Timesharp.Results
{
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;

    /// <summary>
    ///     The challenge result.
    /// </summary>
    public class ChallengeResult : IHttpActionResult
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ChallengeResult"/> class.
        /// </summary>
        /// <param name="loginProvider">
        /// The login provider.
        /// </param>
        /// <param name="controller">
        /// The controller.
        /// </param>
        public ChallengeResult(string loginProvider, ApiController controller)
        {
            this.LoginProvider = loginProvider;
            this.Request = controller.Request;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the login provider.
        /// </summary>
        public string LoginProvider { get; set; }

        /// <summary>
        ///     Gets or sets the request.
        /// </summary>
        public HttpRequestMessage Request { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The execute async.
        /// </summary>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            this.Request.GetOwinContext().Authentication.Challenge(this.LoginProvider);

            var response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            response.RequestMessage = this.Request;
            return Task.FromResult(response);
        }

        #endregion
    }
}