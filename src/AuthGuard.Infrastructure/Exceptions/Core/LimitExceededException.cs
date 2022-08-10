using Microsoft.Extensions.Logging;
using System.Net;

namespace AuthGuard.Infrastructure.Exceptions.Core
{
    public class LimitExceededException : BaseException
    {
        public LimitExceededException(string message) : base(message)
        {
        }

        public LimitExceededException(string message, string instance) : base(message, instance)
        {
        }

        public override int Code => 9000;

        public override LogLevel Level => LogLevel.Error;

        public override HttpStatusCode StatusCode => HttpStatusCode.PaymentRequired;
    }
}
