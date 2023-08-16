using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public class InvalidConfigurationSwitchException : Xeption
    {
        public InvalidConfigurationSwitchException(Exception innerException)
            : base(message: "Invalid switch configuration error occurred, contact support.",
                  innerException)
        { }

        public InvalidConfigurationSwitchException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}