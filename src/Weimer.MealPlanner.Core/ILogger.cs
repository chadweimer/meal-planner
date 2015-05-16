namespace Weimer.MealPlanner.Core
{

    /// <summary>
    /// Represents the logging interface used throughout the application.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Log(string message);
    }
}
