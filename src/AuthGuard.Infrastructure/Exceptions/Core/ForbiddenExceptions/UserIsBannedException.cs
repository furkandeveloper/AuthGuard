namespace AuthGuard.Infrastructure.Exceptions.Core.ForbiddenExceptions
{
    public class UserIsBannedException : ForbiddenException
    {
        public UserIsBannedException()
        {
        }

        public UserIsBannedException(string message) : base(message)
        {
        }

        public UserIsBannedException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="message">Message of Exception.</param>
        /// <param name="instance">Instance of Exception.</param>
        /// <param name="innerException">Inner Exception can be attached.</param>
        public UserIsBannedException(string message, string instance, Exception innerException) : base(message, instance, innerException)
        {
        }

        public override string Key => "UserIsBanned";
        public override int Code => 1012;
    }
}
