using System;
using System.Windows.Forms;

namespace StBenedict
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Start the application by showing the SplashScreen
            Application.Run(new SplashScreen());
        }
    }
}
