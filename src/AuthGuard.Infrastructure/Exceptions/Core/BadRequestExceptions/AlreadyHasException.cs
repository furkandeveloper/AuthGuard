using AuthGuard.Infrastructure.Exceptions.Core;

namespace AuthGuard.Infrastructure.Exceptions.Core.BadRequestExceptions
{
    public class AlreadyHasException : BadRequestException
    {
        public override string Key => "AlreadyHas";
        public override int Code => 1002;
        public AlreadyHasException()
        {
        }

        public AlreadyHasException(string entity, string value) : base("The " + entity + " already has " + value)
        {
        }

        public AlreadyHasException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="message">Message of Exception.</param>
        /// <param name="instance">Instance of Exception.</param>
        /// <param name="innerException">Inner Exception can be attached.</param>
        public AlreadyHasException(string message, string instance, Exception innerException) : base(message, instance, innerException)
        {
        }
    }
}
