namespace AuthGuard.Infrastructure.Exceptions.Core.UnAuthorizedExceptions
{
    public class InvalidCredentialsException : UnauthorizedException
    {
        public override string Key => "InvalidAuthorizationCredentials";
        public override int Code => 1014;
        public InvalidCredentialsException()
        {
        }

        public InvalidCredentialsException(string message) : base(message)
        {
        }

        public InvalidCredentialsException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="message">Message of Exception.</param>
        /// <param name="instance">Instance of Exception.</param>
        /// <param name="innerException">Inner Exception can be attached.</param>
        public InvalidCredentialsException(string message, string instance, Exception innerException) : base(message, instance, innerException)
        {
        }
    }
}
