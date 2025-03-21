using Api.enums;

namespace Api.utils
{
    public static class ErrorMessage
    {
        private static readonly Dictionary<ErrorType, string> _errors = new Dictionary<ErrorType, string>
        {
            { ErrorType.InvalidToken, "The provided token is invalid." },
            { ErrorType.NotFound, "The requested resource was not found on the server." },
        };

        public static object GetMessageObject(ErrorType errorType)
        {
            return new
            {
                message = _errors.GetValueOrDefault(errorType, "Unknown error.")
            };
        }
    }
}
