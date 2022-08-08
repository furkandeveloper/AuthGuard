namespace AuthGuard.Infrastructure.Exceptions.Core.BadRequestExceptions
{
    public class AlreadyExistException : BadRequestException
    {
        public AlreadyExistException()
        {
        }

        /// <summary>
        /// Generates keys as
        /// </summary>
        public AlreadyExistException(string existingEntity)
        {
            Key = existingEntity.Replace(" ", string.Empty) + Key;
        }
        /// <summary>
        /// Generates keys as {existingEntity}AlreadyExist.
        /// </summary>
        /// <param name="existingEntity"></param>
        /// <param name="args">Argument list of entities.</param>
        public AlreadyExistException(string existingEntity, params object[] args) : this(existingEntity)
        {
            Params = args;
        }

        public AlreadyExistException(string message, Exception inner) : base(message, inner)
        {
        }

        public AlreadyExistException(string message, string instance) : base(message, instance)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="message">Message of Exception.</param>
        /// <param name="instance">Instance of Exception.</param>
        /// <param name="innerException">Inner Exception can be attached.</param>
        public AlreadyExistException(string message, string instance, Exception innerException) : base(message, instance, innerException)
        {
        }


        /// <summary>
        /// Override as 'AlreadyExist'.
        /// </summary>
        public sealed override string Key { get; set; } = "AlreadyExist";

        public override int Code => 1003;
    }
}
