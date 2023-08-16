using Xeptions;

namespace FlutterWave.Core.Models.Clients.Tokenss.Exceptions
{
    /// <summary>
    /// This exception is thrown when a service error occurs while using the Tokens client. 
    /// For example, if there is a problem with the server or any other service failure.
    /// </summary>
    public class TokensClientServiceException : Xeption
    {
        public TokensClientServiceException(Xeption innerException)
            : base(message: "Tokens client service error occurred, contact support.",
                  innerException)
        { }
    }
}
