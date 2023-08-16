using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public class TokensDependencyException : Xeption
    {
        public TokensDependencyException(Xeption innerException)
            : base(message: "Tokens dependency error occurred, contact support.",
                  innerException)
        { }

        public TokensDependencyException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}