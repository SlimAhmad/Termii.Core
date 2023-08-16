using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public class NotFoundTokensException : Xeption
    {
        public NotFoundTokensException(Exception innerException)
            : base(message: "Not found tokens error occurred, fix errors and try again.",
                  innerException)
        { }

        public NotFoundTokensException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}