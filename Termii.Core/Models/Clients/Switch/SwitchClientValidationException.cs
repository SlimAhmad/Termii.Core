using Xeptions;

namespace FlutterWave.Core.Models.Clients.Switch.Exceptions
{
    /// <summary>
    /// This exception is thrown when a validation error occurs while using the completion client.
    /// For example, if required data is missing or invalid.
    /// </summary>
    public class SwitchClientValidationException : Xeption
    {
        public SwitchClientValidationException(Xeption innerException)
            : base(message: "Switchs client validation error occurred, fix errors and try again.",
                   innerException)
        { }
    }
}
