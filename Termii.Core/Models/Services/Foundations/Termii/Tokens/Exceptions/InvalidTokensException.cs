using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public class InvalidTokensException : Xeption
    {
        public InvalidTokensException()
            : base(message: "Invalid tokens error occurred, fix errors and try again.")
        { }

        public InvalidTokensException(Exception innerException)
            : base(message: "Invalid tokens error occurred, fix errors and try again.",
                  innerException)
        { }

        public InvalidTokensException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}