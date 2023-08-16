using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public class InsightsValidationException : Xeption
    {
        public InsightsValidationException(Xeption innerException)
            : base(message: "Insights validation error occurred, fix errors and try again.",
                  innerException)
        { }

        public InsightsValidationException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}