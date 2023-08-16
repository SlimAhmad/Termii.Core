using Xeptions;

namespace FlutterWave.Core.Models.Clients.Insights.Exceptions
{
    /// <summary>
    /// This exception is thrown when a service error occurs while using the Insights client. 
    /// For example, if there is a problem with the server or any other service failure.
    /// </summary>
    public class InsightsClientServiceException : Xeption
    {
        public InsightsClientServiceException(Xeption innerException)
            : base(message: "Insights client service error occurred, contact support.",
                  innerException)
        { }
    }
}
