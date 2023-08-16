using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public class FailedTokensServiceException : Xeption
    {
        public FailedTokensServiceException(Exception innerException)
            : base(message: "Failed tokens service error occurred, contact support.",
                  innerException)
        { }

        public FailedTokensServiceException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}