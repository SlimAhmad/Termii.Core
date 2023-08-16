using System;
using Xeptions;

namespace Termii.Core.Models.Services.Foundations.Termii.Exceptions
{
    public partial class NullSwitchException : Xeption
    {
        public NullSwitchException()
            : base(message: "Switch is null.")
        { }

        public NullSwitchException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}
