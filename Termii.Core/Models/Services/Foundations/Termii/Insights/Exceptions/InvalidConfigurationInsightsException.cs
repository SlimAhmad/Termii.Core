using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public class InvalidConfigurationInsightsException : Xeption
    {
        public InvalidConfigurationInsightsException(Exception innerException)
            : base(message: "Invalid insights configuration error occurred, contact support.",
                  innerException)
        { }
    

        public InvalidConfigurationInsightsException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}