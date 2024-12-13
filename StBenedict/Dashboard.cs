using System;
using System.Drawing;
using System.Windows.Forms;

namespace StBenedict
{
    public partial class Dashboard : Form
    {
        private Form currentChildForm;

        public Dashboard()
        {
            InitializeComponent();
            
            // Set the default active button and load the default form
            SetActiveButton(btnDoctor);
            LoadFormIntoPanel(new Doctor()); 
        }

        private void SetActiveButton(Button activeButton)
        {
            // Define colors
            Color activeColor = Color.FromArgb(122, 178, 211); // Active color
            Color inactiveColor = Color.FromArgb(66, 125, 157); // Inactive color

            // Reset all buttons to inactive color
            btnDoctor.BackColor = inactiveColor;
            btnAppointment.BackColor = inactiveColor;
            btnPatient.BackColor = inactiveColor;
            btnMedicalHistory.BackColor = inactiveColor;
            btnMedicalBills.BackColor = inactiveColor;
            btnLogout.BackColor = inactiveColor;

            // Set active button color
            activeButton.BackColor = activeColor;
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnDoctor);
            if (!(currentChildForm is Doctor))
            {
                LoadFormIntoPanel(new Doctor());
            }
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnPatient);
            if (!(currentChildForm is Patient))
            {
                LoadFormIntoPanel(new Patient());
            }
        }

        private void btnAppointment_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnAppointment);
            if (!(currentChildForm is Appointment))
            {
                LoadFormIntoPanel(new Appointment());
            }


        }

        private void btnMedicalBills_Click(object sender, EventArgs e)
        {
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnLogout);

            // Redirect back to Login
            Login loginForm = new Login();
            loginForm.Show();

            // Close the current Dashboard form
            this.Close();
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMedicalHistory_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnMedicalHistory);
            if (!(currentChildForm is MedicalHistory))
            {
                LoadFormIntoPanel(new MedicalHistory());
            }
        }

        private void btnMedicalBills_Click_1(object sender, EventArgs e)
        {
            SetActiveButton(btnMedicalBills);
            if (!(currentChildForm is Billing))
            {
                LoadFormIntoPanel(new Billing());
            }
        }
    }
}
