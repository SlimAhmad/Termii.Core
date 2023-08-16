using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public class UnauthorizedTokensException : Xeption
    {
        public UnauthorizedTokensException(Exception innerException)
            : base(message: "Unauthorized tokens request, fix errors and try again.",
                  innerException)
        { }

        public UnauthorizedTokensException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}