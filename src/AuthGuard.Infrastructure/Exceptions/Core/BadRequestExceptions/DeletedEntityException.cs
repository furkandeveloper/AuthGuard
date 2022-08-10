using System.Globalization;

namespace AuthGuard.Infrastructure.Exceptions.Core.BadRequestExceptions
{
    public class DeletedEntityException : BadRequestException
    {
        public override int Code => 1001;
        public DeletedEntityException()
        {
        }

        public DeletedEntityException(string entityType)
        {
            EntityType = CultureInfo.InstalledUICulture.TextInfo.ToTitleCase(entityType);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="message">Message of Exception.</param>
        /// <param name="instance">Instance of Exception.</param>
        /// <param name="innerException">Inner Exception can be attached.</param>
        public DeletedEntityException(string message, string instance, Exception innerException) : base(message, instance, innerException)
        {
        }

        private string EntityType { get; }

        public override string Key => $"Deleted{EntityType}";
    }
}
