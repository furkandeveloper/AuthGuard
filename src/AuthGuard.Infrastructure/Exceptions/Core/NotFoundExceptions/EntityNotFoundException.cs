using AuthGuard.Infrastructure.Exceptions.Core;
using System.Globalization;

namespace AuthGuard.Infrastructure.Exceptions.Core.NotFoundExceptions
{
    public class EntityNotFoundException : NotFoundException
    {
        public override string Key => $"{EntityType ?? "Entity"}NotFound";
        public override int Code => 1013;

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
        /// <param name="parameters">
        /// Exception parameters
        /// </param>
        public EntityNotFoundException(string entityName, params object[] parameters)
            : base(entityName + " not found!")
        {
            EntityType = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(entityName);
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
        /// Gets entity Type which is not found.
        /// </summary>
        private string EntityType { get; }
    }
}
