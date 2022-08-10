using AuthGuard.Infrastructure.Exceptions.Core;

namespace AuthGuard.Infrastructure.Exceptions.Core.UnAuthorizedExceptions
{
    public class InvalidTenantException : UnauthorizedException
    {
        public InvalidTenantException()
        {
        }

        public InvalidTenantException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="message">Message of Exception.</param>
        /// <param name="instance">Instance of Exception.</param>
        /// <param name="innerException">Inner Exception can be attached.</param>
        public InvalidTenantException(string message, string instance, Exception innerException) : base(message, instance, innerException)
        {
        }

        public override string Key => "InvalidTenant";
        public override int Code => 1015;
    }
}
