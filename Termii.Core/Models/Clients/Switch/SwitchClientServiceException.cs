using Xeptions;

namespace FlutterWave.Core.Models.Clients.Switch.Exceptions
{
    /// <summary>
    /// This exception is thrown when a service error occurs while using the Switch client. 
    /// For example, if there is a problem with the server or any other service failure.
    /// </summary>
    public class SwitchClientServiceException : Xeption
    {
        public SwitchClientServiceException(Xeption innerException)
            : base(message: "Switch client service error occurred, contact support.",
                  innerException)
        { }
    }
}
