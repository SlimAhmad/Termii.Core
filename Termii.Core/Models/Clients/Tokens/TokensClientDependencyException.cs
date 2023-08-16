using Xeptions;

namespace FlutterWave.Core.Models.Clients.Tokens.Exceptions
{
    /// <summary>
    /// This exception is thrown when a dependency error occurs while using the Tokens client. 
    /// For example, if a required dependency is unavailable or incompatible.
    /// </summary>
    public class TokensClientDependencyException : Xeption
    {
        public TokensClientDependencyException(Xeption innerException)
            : base(message: "Tokens dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
