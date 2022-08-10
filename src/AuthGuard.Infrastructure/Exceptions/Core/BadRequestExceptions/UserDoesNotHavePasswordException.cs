namespace AuthGuard.Infrastructure.Exceptions.Core.BadRequestExceptions
{
    public class UserDoesNotHavePasswordException : BadRequestException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="message">Message of Exception.</param>
        /// <param name="instance">Instance of Exception.</param>
        /// <param name="innerException">Inner Exception can be attached.</param>
        public UserDoesNotHavePasswordException(string message, string instance, Exception innerException) : base(message, instance, innerException)
        {
        }

        public override string Key => "NoPassword";

        public override int Code => 1009;
    }
}
