using AuthGuard.Infrastructure.Exceptions.Core;

namespace AuthGuard.Infrastructure.Exceptions.Core.BadRequestExceptions
{
    public class NotDeletedEntityException : BadRequestException
    {
        public NotDeletedEntityException(string message, string instance) : base(message, instance)
        {
        }

        public override int Code => 1200;
    }
}
