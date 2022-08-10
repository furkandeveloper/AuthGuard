using AuthGuard.Infrastructure.Exceptions.Core;
using System.Globalization;

namespace AuthGuard.Infrastructure.Exceptions.Core.BadRequestExceptions
{
    public class AlreadyDeletedException : BadRequestException
    {
        public AlreadyDeletedException()
        {

        }

        public AlreadyDeletedException(string entityName)
        {
            EntityType = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(entityName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="message">Message of Exception.</param>
        /// <param name="instance">Instance of Exception.</param>
        /// <param name="innerException">Inner Exception can be attached.</param>
        public AlreadyDeletedException(string message, string instance, Exception innerException) : base(message, instance, innerException)
        {
        }

        public override int Code => 1004;
        private string EntityType { get; }
        public override string Key => $"{EntityType}AlreadyDeleted";
    }
}
