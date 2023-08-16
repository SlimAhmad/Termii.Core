using Xeptions;

namespace Termii.Core.Models.Clients.Insights.Exceptions
{
    /// <summary>
    /// This exception is thrown when a dependency error occurs while using the Insights client. 
    /// For example, if a required dependency is unavailable or incompatible.
    /// </summary>
    public class InsightsClientDependencyException : Xeption
    {
        public InsightsClientDependencyException(Xeption innerException)
            : base(message: "Insights dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
