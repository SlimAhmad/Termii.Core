using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public class ExcessiveCallTokensException : Xeption
    {
        public ExcessiveCallTokensException(Exception innerException)
            : base(message: "Excessive call error occurred, limit your calls.",
                  innerException)
        { }

        public ExcessiveCallTokensException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}