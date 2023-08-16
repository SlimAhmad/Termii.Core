using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public class FailedServerTokensException : Xeption
    {
        public FailedServerTokensException(Exception innerException)
            : base(message: "Failed tokens server error occurred, contact support.",
                  innerException)
        { }

        public FailedServerTokensException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}