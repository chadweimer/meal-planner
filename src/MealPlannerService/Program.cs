using System.ServiceProcess;

namespace MealPlannerService
{
    /// <summary>
    /// The main program entry point.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new WindowsService() 
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
