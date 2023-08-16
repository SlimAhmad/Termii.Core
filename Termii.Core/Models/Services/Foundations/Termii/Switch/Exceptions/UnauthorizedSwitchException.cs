using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public class UnauthorizedSwitchException : Xeption
    {
        public UnauthorizedSwitchException(Exception innerException)
            : base(message: "Unauthorized switch request, fix errors and try again.",
                  innerException)
        { }

        public UnauthorizedSwitchException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}