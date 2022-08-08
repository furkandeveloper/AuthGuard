using Microsoft.Extensions.Logging;
using System.Net;

namespace AuthGuard.Infrastructure.Exceptions.Core
{
    public class UnauthorizedException : BaseException
    {
        protected UnauthorizedException() { }

        protected UnauthorizedException(string message) : base(message) { }

        protected UnauthorizedException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="message">Message of Exception.</param>
        /// <param name="instance">Instance of Exception.</param>
        /// <param name="innerException">Inner Exception can be attached.</param>
        protected UnauthorizedException(string message, string instance, Exception innerException) : base(message, instance, innerException)
        {
        }

        public override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;

        public override LogLevel Level => LogLevel.Information;
    }
}
