using Xeptions;

namespace FlutterWave.Core.Models.Clients.Tokenss.Exceptions
{
    /// <summary>
    /// This exception is thrown when a validation error occurs while using the completion client.
    /// For example, if required data is missing or invalid.
    /// </summary>
    public class TokensClientValidationException : Xeption
    {
        public TokensClientValidationException(Xeption innerException)
            : base(message: "Tokenss client validation error occurred, fix errors and try again.",
                   innerException)
        { }
    }
}
