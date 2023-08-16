using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public class InsightsServiceException : Xeption
    {
        public InsightsServiceException(Xeption innerException)
            : base(message: "Insights service error occurred, contact support.",
                  innerException)
        { }

        public InsightsServiceException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}