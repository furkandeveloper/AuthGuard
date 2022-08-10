namespace AuthGuard.Infrastructure.Exceptions.Core.UnAuthorizedExceptions
{
    public class MissingCredentialsException : UnauthorizedException
    {
        public override string Key => "MissingCredentials";
        public override int Code => 1016;
        public MissingCredentialsException()
        {
        }

        public MissingCredentialsException(string message) : base(message)
        {
        }

        public MissingCredentialsException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="message">Message of Exception.</param>
        /// <param name="instance">Instance of Exception.</param>
        /// <param name="innerException">Inner Exception can be attached.</param>
        public MissingCredentialsException(string message, string instance, Exception innerException) : base(message, instance, innerException)
        {
        }
    }
}
