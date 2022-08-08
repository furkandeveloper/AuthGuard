using Microsoft.Extensions.Logging;
using System.Net;

namespace AuthGuard.Infrastructure.Exceptions.Core
{
    /// <summary>
    /// Basicly returns a forbidden - 403 response when throwed.
    /// </summary>
    public class ForbiddenException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenException"/> class.
        /// </summary>
        protected ForbiddenException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenException"/> class.
        /// </summary>
        /// <param name="message">
        /// Exception Message
        /// </param>
        protected ForbiddenException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenException"/> class.
        /// </summary>
        /// <param name="message">Passes message parameter to base constructor.</param>
        /// <param name="inner">Passes inner Exception parameter to base constructor.</param>
        protected ForbiddenException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="message">Message of Exception.</param>
        /// <param name="instance">Instance of Exception.</param>
        /// <param name="innerException">Inner Exception can be attached.</param>
        protected ForbiddenException(string message, string instance, Exception innerException) : base(message, instance, innerException)
        {
        }

        public override HttpStatusCode StatusCode => HttpStatusCode.Forbidden;

        public override LogLevel Level => LogLevel.Warning;
    }
}
