using Microsoft.Extensions.Logging;
using System.Net;

namespace AuthGuard.Infrastructure.Exceptions.Core
{
    /// <summary>
    /// Basicly returns a notfound - 404 response when throwed.
    /// </summary>
    public class NotFoundException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class.
        /// </summary>
        protected NotFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class.
        /// </summary>
        protected NotFoundException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class.
        /// </summary>
        /// <param name="message">Passes message parameter to base constructor.</param>
        /// <param name="innerException">Passes innerException parameter to base constructor.</param>
        protected NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="message">Message of Exception.</param>
        /// <param name="instance">Instance of Exception.</param>
        /// <param name="innerException">Inner Exception can be attached.</param>
        protected NotFoundException(string message, string instance, Exception innerException) : base(message, instance, innerException)
        {
        }

        public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        public override string Key => "NotFound";

        public override LogLevel Level => LogLevel.Information;
    }
}
