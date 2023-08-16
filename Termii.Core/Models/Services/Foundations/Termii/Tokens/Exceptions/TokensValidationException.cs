using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public class TokensValidationException : Xeption
    {
        public TokensValidationException(Xeption innerException)
            : base(message: "Tokens validation error occurred, fix errors and try again.",
                  innerException)
        { }

        public TokensValidationException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}