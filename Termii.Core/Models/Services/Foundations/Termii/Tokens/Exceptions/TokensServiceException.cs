using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public class TokensServiceException : Xeption
    {
        public TokensServiceException(Xeption innerException)
            : base(message: "Tokens service error occurred, contact support.",
                  innerException)
        { }

        public TokensServiceException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}