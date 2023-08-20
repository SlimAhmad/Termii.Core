using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public class InvalidInsightsException : Xeption
    {
        public InvalidInsightsException()
            : base(message: "Invalid insights error occurred, fix errors and try again.")
        { }

        public InvalidInsightsException(Exception innerException)
            : base(message: "Invalid insights error occurred, fix errors and try again.",
                  innerException)
        { }

        public InvalidInsightsException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}