using System.Globalization;

namespace AuthGuard.Infrastructure.Exceptions.Core.BadRequestExceptions
{
    public class EntityNotFoundException : BadRequestException
    {
        public override string Key => $"{EntityType ?? "Entity"}NotFound";

        public override int Code => 1000;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class.
        /// </summary>
        public EntityNotFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class.
        /// </summary>
        /// <param name="entityName">Type of Entity.</param>
        /// <param name="parameters"></param>
        public EntityNotFoundException(string entityName, params object[] parameters)
            : base($"{entityName ?? "Entity"}NotFound")
        {
            if (entityName != null) EntityType = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(entityName);
            Params = parameters;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class.
        /// </summary>
        /// <param name="message">Message about exception.</param>
        /// <param name="inner">inner exception to attach main exception.</param>
        public EntityNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="message">Message of Exception.</param>
        /// <param name="instance">Instance of Exception.</param>
        /// <param name="innerException">Inner Exception can be attached.</param>
        public EntityNotFoundException(string message, string instance, Exception innerException) : base(message, instance, innerException)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="message">Message of Exception.</param>
        /// <param name="instance">Instance of Exception.</param>
        public EntityNotFoundException(string message, string instance) : base(message, instance)
        {
        }

        /// <summary>
        /// Gets entity Type which is not found.
        /// </summary>
        private string EntityType { get; }
    }
}
