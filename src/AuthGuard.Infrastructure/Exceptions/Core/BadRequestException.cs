using System.Net;
using Microsoft.Extensions.Logging;

namespace AuthGuard.Infrastructure.Exceptions.Core
{
    /// <summary>
    /// Basicly returns a badrequest - 400 response when throwed.
    /// </summary>
    public class BadRequestException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestException"/> class.
        /// </summary>
        public BadRequestException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestException"/> class.
        /// </summary>
        /// <param name="key">Resources key for localization.</param>
        public BadRequestException(string key)
        {
            Key = key;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestException"/> class.
        /// </summary>
        /// <param name="message">Passes message parameter to base constructor.</param>
        /// <param name="innerException">Passes innerException parameter to base constructor.</param>
        public BadRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestException"/> class.
        /// </summary>
        /// <param name="key">Resources key for localization</param>
        /// <param name="level">Criticality level of exception.</param>
        public BadRequestException(string key, LogLevel level) : this(key)
        {
            Level = level;
        }

        public BadRequestException(string message, string instance) : base(message, instance)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="message">Message of Exception.</param>
        /// <param name="instance">Instance of Exception.</param>
        /// <param name="innerException">Inner Exception can be attached.</param>
        public BadRequestException(string message, string instance, Exception innerException) : base(message, instance, innerException)
        {
        }

        /// <inheritdoc/>
        public override LogLevel Level => LogLevel.Error;

        /// <inheritdoc/>
        public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    }
}
