namespace AuthGuard.Infrastructure.Exceptions.Core.ForbiddenExceptions
{
    public sealed class PermissionRequiredException : ForbiddenException
    {
        public override int Code => 1011;
        public PermissionRequiredException()
        {
        }

        public PermissionRequiredException(string permission, string user) : base($"'{permission}' permission is required to execute this action for {user} user.")
        {
            Data.Add("Permission", permission);
            Data.Add("User", user);

            Params = new object[]
            {
                new KeyValuePair<string, string>("Permission", permission),
                new KeyValuePair<string, string>("User", user ),
            };
        }

        public PermissionRequiredException(string message) : base(message)
        {
        }

        public PermissionRequiredException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="message">Message of Exception.</param>
        /// <param name="instance">Instance of Exception.</param>
        /// <param name="innerException">Inner Exception can be attached.</param>
        public PermissionRequiredException(string message, string instance, Exception innerException) : base(message, instance, innerException)
        {
        }
    }
}
