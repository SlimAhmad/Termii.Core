using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public class InsightsDependencyValidationException : Xeption
    {
        public InsightsDependencyValidationException(Xeption innerException)
            : base(message: "Insights dependency validation error occurred, contact support.",
                  innerException)
        { }

        public InsightsDependencyValidationException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}