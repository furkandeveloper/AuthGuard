using AuthGuard.Infrastructure.Exceptions.Core;

namespace AuthGuard.Infrastructure.Exceptions.Core.BadRequestExceptions
{
    /// <summary>
    /// Represents <see cref="BadRequestException"/> with "InvalidRefreshToken" key.
    /// </summary>
    public class InvalidRefreshToken : BadRequestException
    {
        public InvalidRefreshToken()
        {

        }

        public InvalidRefreshToken(string tokenName) : base($"The {tokenName} is invalid!")
        {
        }

        public InvalidRefreshToken(string tokenName, Exception inner) : base($"The {tokenName} is invalid!", inner)
        {
        }

        public InvalidRefreshToken(string tokenName, string value) : base($"The {tokenName} is invalid. Value is {value}")
        {
            SetParams(tokenName, value);
        }

        public InvalidRefreshToken(string tokenName, string value, Exception inner) : base($"The {tokenName} is invalid. Value is {value}", inner)
        {
            SetParams(tokenName, value);
        }

        /// <inheritdoc/>
        public override string Key => "InvalidRefreshToken";
        public sealed override int Code => 1005;

        private void SetParams(string tokenName, string value)
        {
            Params = new object[] { new KeyValuePair<string, string>(tokenName, value) };
        }
    }
}
