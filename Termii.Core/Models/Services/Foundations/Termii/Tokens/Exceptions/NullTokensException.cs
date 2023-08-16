using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public partial class NullTokensException : Xeption
    {
        public NullTokensException()
            : base(message: "Tokens is null.")
        { }

        public NullTokensException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}
