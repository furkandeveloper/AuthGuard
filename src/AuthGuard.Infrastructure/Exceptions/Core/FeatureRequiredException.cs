using Microsoft.Extensions.Logging;
using System.Net;

namespace AuthGuard.Infrastructure.Exceptions.Core
{
    public class FeatureRequiredException : BaseException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.PaymentRequired;
        public override LogLevel Level => LogLevel.Error;
        public override int Code => 7000;
        public FeatureRequiredException()
        {
        }

        public FeatureRequiredException(string message) : base(message)
        {
        }

        public FeatureRequiredException(HttpStatusCode statusCode) : base(statusCode)
        {
        }

        public FeatureRequiredException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public FeatureRequiredException(HttpStatusCode statusCode, string message) : base(statusCode, message)
        {
        }

        public FeatureRequiredException(string message, string instance) : base(message, instance)
        {
        }

        public FeatureRequiredException(HttpStatusCode statusCode, string message, Exception innerException) : base(statusCode, message, innerException)
        {
        }

        public FeatureRequiredException(string message, string instance, Exception innerException) : base(message, instance, innerException)
        {
        }
    }
}
