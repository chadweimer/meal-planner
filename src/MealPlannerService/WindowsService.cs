using System.ServiceProcess;

namespace MealPlannerService
{
    /// <summary>
    /// The Meal Planner windows service which hosts the API.
    /// </summary>
    public partial class WindowsService : ServiceBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowsService"/> class.
        /// </summary>
        public WindowsService()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Executes the logic to start the service.
        /// </summary>
        /// <param name="args">The command-line arguments to the service.</param>
        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
        }

        /// <summary>
        /// Executes the logic to stop the service.
        /// </summary>
        protected override void OnStop()
        {
        }
    }
}
