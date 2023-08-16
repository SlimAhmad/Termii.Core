using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public class UnauthorizedInsightsException : Xeption
    {
        public UnauthorizedInsightsException(Exception innerException)
            : base(message: "Unauthorized insights request, fix errors and try again.",
                  innerException)
        { }

        public UnauthorizedInsightsException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}