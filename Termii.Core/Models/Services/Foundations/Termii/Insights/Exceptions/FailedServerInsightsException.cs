using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public class FailedServerInsightsException : Xeption
    {
        public FailedServerInsightsException(Exception innerException)
            : base(message: "Failed Insights server error occurred, contact support.",
                  innerException)
        { }

        public FailedServerInsightsException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}