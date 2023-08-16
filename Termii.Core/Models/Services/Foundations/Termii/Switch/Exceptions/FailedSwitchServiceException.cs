using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public class FailedSwitchServiceException : Xeption
    {
        public FailedSwitchServiceException(Exception innerException)
            : base(message: "Failed switch service error occurred, contact support.",
                  innerException)
        { }

        public FailedSwitchServiceException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}