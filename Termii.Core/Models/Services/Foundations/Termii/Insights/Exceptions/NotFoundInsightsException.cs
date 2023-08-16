using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public class NotFoundInsightsException : Xeption
    {
        public NotFoundInsightsException(Exception innerException)
            : base(message: "Not found insights error occurred, fix errors and try again.",
                  innerException)
        { }

        public NotFoundInsightsException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}