using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public class SwitchValidationException : Xeption
    {
        public SwitchValidationException(Xeption innerException)
            : base(message: "Switch validation error occurred, fix errors and try again.",
                  innerException)
        { }

        public SwitchValidationException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}