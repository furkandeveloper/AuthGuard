namespace AuthGuard.Infrastructure.Exceptions.Core.BadRequestExceptions
{
    public class InvalidTokenException : BadRequestException
    {
        public InvalidTokenException()
        {
        }

        public InvalidTokenException(string tokenName) : base($"The {tokenName} is invalid!")
        {
        }

        public InvalidTokenException(string tokenName, Exception inner) : base($"The {tokenName} is invalid!", inner)
        {
        }

        public InvalidTokenException(string tokenName, string value, Exception inner) : base($"The {tokenName} is invalid. Value is {value}", inner)
        {
        }

        public override string Key => "InvalidToken";

        public override int Code => 1006;
    }
}
