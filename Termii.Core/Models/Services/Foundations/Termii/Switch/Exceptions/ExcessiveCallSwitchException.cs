using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public class ExcessiveCallSwitchException : Xeption
    {
        public ExcessiveCallSwitchException(Exception innerException)
            : base(message: "Excessive call error occurred, limit your calls.",
                  innerException)
        { }

        public ExcessiveCallSwitchException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}