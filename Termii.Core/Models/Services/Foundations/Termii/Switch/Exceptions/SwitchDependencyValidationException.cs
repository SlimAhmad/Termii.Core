using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public class SwitchDependencyValidationException : Xeption
    {
        public SwitchDependencyValidationException(Xeption innerException)
            : base(message: "Switch dependency validation error occurred, contact support.",
                  innerException)
        { }

        public SwitchDependencyValidationException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}