using System;
using System.Drawing;
using System.Windows.Forms;

namespace StBenedict
{
    public partial class DoctorDashboard : Form
    {
        private Form currentChildForm;

        public DoctorDashboard()
        {
            InitializeComponent();

            // Set the default active button and load the default form
            SetActiveButton(btnPatientManagement); // Default button
            LoadFormIntoPanel(new DocPatientManagement()); // Load DocPatientManagement.cs by default
        }

        private void SetActiveButton(Button activeButton)
        {
            // Define colors
            Color activeColor = Color.FromArgb(122, 178, 211); // Active color
            Color inactiveColor = Color.FromArgb(66, 125, 157); // Inactive color

            // Reset all buttons to inactive color
            btnPatientManagement.BackColor = inactiveColor;
            btnAppointment.BackColor = inactiveColor;
            btnMedicalHistory.BackColor = inactiveColor;
            btnLogout.BackColor = inactiveColor;

            // Set active button color
            activeButton.BackColor = activeColor;
        }

        private void LoadFormIntoPanel(Form childForm)
        {
            // Close the current child form if it exists
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            currentChildForm = childForm;

            // Configure the child form
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Clear the panel and add the new child form
            panelChild.Controls.Clear();
            panelChild.Controls.Add(childForm);
            childForm.Show();
        }

        private void btnPatientManagement_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnPatientManagement);
            if (!(currentChildForm is DocPatientManagement))
            {
                LoadFormIntoPanel(new DocPatientManagement());
            }
        }

        private void btnAppointment_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnAppointment);
            if (!(currentChildForm is DocAppointment))
            {
                LoadFormIntoPanel(new DocAppointment());
            }
        }

        private void btnMedicalHistory_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnMedicalHistory);
            if (!(currentChildForm is DocMedicalHistory))
            {
                LoadFormIntoPanel(new DocMedicalHistory());
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnLogout);

            // Redirect to Login form
            Login loginForm = new Login();
            loginForm.Show();

            // Close the current dashboard
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
