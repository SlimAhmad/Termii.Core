using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public class InvalidSwitchException : Xeption
    {
        public InvalidSwitchException()
            : base(message: "Invalid switch error occurred, fix errors and try again.")
        { }

        public InvalidSwitchException(Exception innerException)
            : base(message: "Invalid switch error occurred, fix errors and try again.",
                  innerException)
        { }

        public InvalidSwitchException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}