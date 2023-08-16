using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public class InvalidConfigurationTokensException : Xeption
    {
        public InvalidConfigurationTokensException(Exception innerException)
            : base(message: "Invalid tokens configuration error occurred, contact support.",
                  innerException)
        { }

        public InvalidConfigurationTokensException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}