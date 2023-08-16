using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public class NotFoundSwitchException : Xeption
    {
        public NotFoundSwitchException(Exception innerException)
            : base(message: "Not found switch error occurred, fix errors and try again.",
                  innerException)
        { }

        public NotFoundSwitchException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}