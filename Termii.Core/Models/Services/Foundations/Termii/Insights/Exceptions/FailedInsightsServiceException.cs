using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public class FailedInsightsServiceException : Xeption
    {
        public FailedInsightsServiceException(Exception innerException)
            : base(message: "Failed Insights service error occurred, contact support.",
                  innerException)
        { }

        public FailedInsightsServiceException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}