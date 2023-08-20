using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public class InsightsDependencyException : Xeption
    {
        public InsightsDependencyException(Xeption innerException)
            : base(message: "Insights dependency error occurred, contact support.",
                  innerException)
        { }
  
        public InsightsDependencyException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}