using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public partial class NullInsightsException : Xeption
    {
        public NullInsightsException()
            : base(message: "Insights is null.")
        { }

        public NullInsightsException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}
