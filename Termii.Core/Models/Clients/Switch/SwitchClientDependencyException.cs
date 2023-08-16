using Xeptions;

namespace FlutterWave.Core.Models.Clients.Switch.Exceptions
{
    /// <summary>
    /// This exception is thrown when a dependency error occurs while using the Switch client. 
    /// For example, if a required dependency is unavailable or incompatible.
    /// </summary>
    public class SwitchClientDependencyException : Xeption
    {
        public SwitchClientDependencyException(Xeption innerException)
            : base(message: "Switch dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
