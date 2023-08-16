using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public class TokensDependencyValidationException : Xeption
    {
        public TokensDependencyValidationException(Xeption innerException)
            : base(message: "Tokens dependency validation error occurred, contact support.",
                  innerException)
        { }

        public TokensDependencyValidationException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}