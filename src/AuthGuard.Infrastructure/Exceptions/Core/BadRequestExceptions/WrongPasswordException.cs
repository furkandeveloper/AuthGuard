using AuthGuard.Infrastructure.Exceptions.Core;

namespace AuthGuard.Infrastructure.Exceptions.Core.BadRequestExceptions
{
    public class WrongPasswordException : BadRequestException
    {
        public WrongPasswordException() : base()
        {
        }

        public WrongPasswordException(string message) : base(message)
        {
        }

        public WrongPasswordException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="message">Message of Exception.</param>
        /// <param name="instance">Instance of Exception.</param>
        /// <param name="innerException">Inner Exception can be attached.</param>
        public WrongPasswordException(string message, string instance, Exception innerException) : base(message, instance, innerException)
        {
        }

        public override string Key => "WrongPassword";
        public override int Code => 1010;
    }
}
