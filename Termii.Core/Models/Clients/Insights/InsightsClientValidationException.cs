using Xeptions;

namespace FlutterWave.Core.Models.Clients.Insights.Exceptions
{
    /// <summary>
    /// This exception is thrown when a validation error occurs while using the completion client.
    /// For example, if required data is missing or invalid.
    /// </summary>
    public class InsightsClientValidationException : Xeption
    {
        public InsightsClientValidationException(Xeption innerException)
            : base(message: "Insights client validation error occurred, fix errors and try again.",
                   innerException)
        { }
    }
}
