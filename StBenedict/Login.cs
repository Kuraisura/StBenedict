using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StBenedict
{
    public partial class Login : Form
    {
        // Connection string to your database
        private const string ConnectionString =
              @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Kuraisura\Downloads\StBenedict7.0\StBenedict6.0\StBenedict4.0\StBenedict4.0\StBenedict\StBenedict\StBenedict\StBenedict.mdf;Integrated Security=True";

        public Login()
        {
            InitializeComponent();

            // Attach events for Username TextBox
            txtUsername.Enter += TxtUsername_Enter;
            txtUsername.Leave += TxtUsername_Leave;

            // Attach events for Password TextBox
            txtPassword.Enter += TxtPassword_Enter;
            txtPassword.Leave += TxtPassword_Leave;
        }

        // Username TextBox Events
        private void TxtUsername_Enter(object sender, EventArgs e)
        {
            txtUsername.IconLeft = Properties.Resources.parauser; // Focus icon
        }

        private void TxtUsername_Leave(object sender, EventArgs e)
        {
            txtUsername.IconLeft = Properties.Resources.user__2_; // Default icon
        }

        // Password TextBox Events
        private void TxtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.IconLeft = Properties.Resources.paralock; // Focus icon
        }

        private void TxtPassword_Leave(object sender, EventArgs e)
        {
            txtPassword.IconLeft = Properties.Resources.unlock3; // Default icon
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Get user input
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Perform validations
            if (!ValidateInputs(username, password))
                return;

            // Authenticate user
            AuthenticateUser(username, password);
        }

        private bool ValidateInputs(string username, string password)
        {
            // Check for empty fields
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Username is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            return true;
        }

        private void AuthenticateUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    // Check in Login table (for Doctors)
                    string doctorQuery = @"SELECT * FROM Login WHERE Username = @Username AND Password = @Password";
                    SqlCommand doctorCommand = new SqlCommand(doctorQuery, connection);
                    doctorCommand.Parameters.AddWithValue("@Username", username);
                    doctorCommand.Parameters.AddWithValue("@Password", password);

                    SqlDataAdapter doctorAdapter = new SqlDataAdapter(doctorCommand);
                    DataTable doctorTable = new DataTable();
                    doctorAdapter.Fill(doctorTable);

                    if (doctorTable.Rows.Count == 1)
                    {
                        DoctorDashboard doctorDashboard = new DoctorDashboard();
                        doctorDashboard.Show();
                        this.Hide(); // Hide the login form
                        return;
                    }

                    // Check in FrontDesk table (for Front Desk Users)
                    string frontDeskQuery = @"SELECT * FROM FrontDesk WHERE Username = @Username AND Password = @Password";
                    SqlCommand frontDeskCommand = new SqlCommand(frontDeskQuery, connection);
                    frontDeskCommand.Parameters.AddWithValue("@Username", username);
                    frontDeskCommand.Parameters.AddWithValue("@Password", password);

                    SqlDataAdapter frontDeskAdapter = new SqlDataAdapter(frontDeskCommand);
                    DataTable frontDeskTable = new DataTable();
                    frontDeskAdapter.Fill(frontDeskTable);

                    if (frontDeskTable.Rows.Count == 1)
                    {
                        Dashboard dashboard = new Dashboard();
                        dashboard.Show();
                        this.Hide(); // Hide the login form
                        return;
                    }

                    // If no match is found
                    MessageBox.Show("Invalid username or password. Please try again.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Focus();
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show($"Database connection error: {sqlEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
