using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public class ExcessiveCallInsightsException : Xeption
    {
        public ExcessiveCallInsightsException(Exception innerException)
            : base(message: "Excessive call error occurred, limit your calls.",
                  innerException)
        { }

        public ExcessiveCallInsightsException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}