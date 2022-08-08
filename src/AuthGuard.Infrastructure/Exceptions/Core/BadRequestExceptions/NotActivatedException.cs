using AuthGuard.Infrastructure.Exceptions.Core;

namespace AuthGuard.Infrastructure.Exceptions.Core.BadRequestExceptions
{
    public class NotActivatedException : BadRequestException
    {
        public NotActivatedException()
        {
        }

        public NotActivatedException(string property) : base(property + " is not activated.")
        {
            Property = property;
        }

        public NotActivatedException(string property, Exception inner) : base(property + " is not acivated.", inner)
        {
            Property = property;
        }

        public NotActivatedException(string message, string instance) : base(message, instance)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="message">Message of Exception.</param>
        /// <param name="instance">Instance of Exception.</param>
        /// <param name="innerException">Inner Exception can be attached.</param>
        public NotActivatedException(string message, string instance, Exception innerException) : base(message, instance, innerException)
        {
        }

        public string Property { get; }

        public override string Key => "NotActivated" + Property;

        public override int Code => 1007;
    }
}
