using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public class FailedServerSwitchException : Xeption
    {
        public FailedServerSwitchException(Exception innerException)
            : base(message: "Failed switch server error occurred, contact support.",
                  innerException)
        { }

        public FailedServerSwitchException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}