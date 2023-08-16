using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public class SwitchServiceException : Xeption
    {
        public SwitchServiceException(Xeption innerException)
            : base(message: "Switch service error occurred, contact support.",
                  innerException)
        { }

        public SwitchServiceException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}