using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public class SwitchDependencyException : Xeption
    {
        public SwitchDependencyException(Xeption innerException)
            : base(message: "Switch dependency error occurred, contact support.",
                  innerException)
        { }

        public SwitchDependencyException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}