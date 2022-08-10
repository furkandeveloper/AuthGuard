using AuthGuard.Infrastructure.Exceptions.Core;

namespace AuthGuard.Infrastructure.Exceptions.Core.BadRequestExceptions
{
    public class NotConfiguredException : BadRequestException
    {
        public override string Key => "NotConfigured";
        public override int Code => 1008;
        public NotConfiguredException()
        {
        }

        public NotConfiguredException(string message) : base(message)
        {
        }
        public NotConfiguredException(string message, string instance) : base(message, instance)
        {
        }

        public NotConfiguredException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="message">Message of Exception.</param>
        /// <param name="instance">Instance of Exception.</param>
        /// <param name="innerException">Inner Exception can be attached.</param>
        public NotConfiguredException(string message, string instance, Exception innerException) : base(message, instance, innerException)
        {
        }
    }
}
