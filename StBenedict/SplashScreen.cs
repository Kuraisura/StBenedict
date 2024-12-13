using System;
using System.Windows.Forms;

namespace StBenedict
{
    public partial class SplashScreen : Form
    {
        // Timer for controlling the progress bar
        private Timer progressBarTimer;
        private Timer loadingTextTimer;
        private int dotCount = 0;

        public SplashScreen()
        {
            InitializeComponent();
            InitializeSplashScreen();
        }

        // Initialize the splash screen with a progress bar, timer, and animated loading text
        private void InitializeSplashScreen()
        {
            // Set up the progress bar
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 0;

            // Initialize and start the progress bar timer
            progressBarTimer = new Timer();
            progressBarTimer.Interval = 50; // Update the progress bar every 50 ms
            progressBarTimer.Tick += ProgressBarTimer_Tick;
            progressBarTimer.Start();

            // Initialize and start the loading text timer
            loadingTextTimer = new Timer();
            loadingTextTimer.Interval = 500; // Update the loading text every 500 ms
            loadingTextTimer.Tick += LoadingTextTimer_Tick;
            loadingTextTimer.Start();
        }

        // Timer tick event to update the progress bar
        private void ProgressBarTimer_Tick(object sender, EventArgs e)
        {
            // Increment the progress bar value by 2 each tick (5 seconds for a full progress bar)
            if (progressBar.Value < progressBar.Maximum)
            {
                progressBar.Value += 2;
            }
            else
            {
                // Stop the timer when the progress bar reaches 100
                progressBarTimer.Stop();
                progressBarTimer.Dispose();

                // Close the splash screen and open the login form
                OpenLoginForm();
            }
        }

        // Timer tick event to animate the loading text
        private void LoadingTextTimer_Tick(object sender, EventArgs e)
        {
            // Update the loading text with dots (Loading . -> Loading .. -> Loading ...)
            if (dotCount == 0)
            {
                guna2HtmlLabel4.Text = "Loading.";
                dotCount++;
            }
            else if (dotCount == 1)
            {
                guna2HtmlLabel4.Text = "Loading..";
                dotCount++;
            }
            else
            {
                guna2HtmlLabel4.Text = "Loading...";
                dotCount = 0; // Reset to 0 to start again
            }
        }

        // Method to open the Login form
        private void OpenLoginForm()
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }
    }
}
