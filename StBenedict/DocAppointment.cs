using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StBenedict
{
    public partial class DocAppointment : Form
    {
        private const string ConnectionString =
             @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Kuraisura\Downloads\StBenedict7.0\StBenedict6.0\StBenedict4.0\StBenedict4.0\StBenedict\StBenedict\StBenedict\StBenedict.mdf;Integrated Security=True";
        // Animation timers
        private Timer btnTimerUpdate, btnTimerDelete;
        private const int ButtonMinWidth = 40; // Width when collapsed (icon only)
        private const int ButtonMaxWidth = 100; // Width when expanded (full text)
        private const int AnimationSpeed = 10; // Speed of the animation

        public DocAppointment()
        {
            InitializeComponent();
            InitializeAnimations();
            LoadAppointments();
            DisableEditing(); // Disable interactions for specific controls
            dgvDocAppointment.CellClick += dgvDocAppointment_CellClick; // Attach CellClick event
        }

        private void InitializeAnimations()
        {
            // Initialize button timers
            btnTimerUpdate = new Timer { Interval = 10 };
            btnTimerDelete = new Timer { Interval = 10 };

            btnTimerUpdate.Tick += BtnUpdate_Animate;
            btnTimerDelete.Tick += BtnDelete_Animate;

            // Setup buttons
            SetupButton(btnUpdate, "     Update");
            SetupButton(btnDelete, "     Delete");
        }

        private void DisableEditing()
        {
            // Disable interaction for controls except for dtpDate, txtTimeIn, and txtTimeOut
            txtPatFullName.Enabled = false;
            cbAppointmentStatus.Enabled = false;
            txtFloor.Enabled = false;
            txtTimeAvailability.Enabled = false;
            txtTimeOut.Enabled = false;
            txtTimeIn.Enabled = false;
            txtDiagnosis.Enabled = false;
        }

        private void SetupButton(Guna2GradientButton button, string text)
        {
            button.Width = ButtonMinWidth;
            button.Text = ""; // Initially hide the text
            button.TextAlign = HorizontalAlignment.Center; // Align text to the center of the button
            button.ImageAlign = HorizontalAlignment.Left; // Align icon to the left
            button.Tag = text; // Store the full text in the Tag property

            button.MouseEnter += (s, e) =>
            {
                button.Text = text; // Show text on hover
                StartAnimation(button, true);
            };

            button.MouseLeave += (s, e) =>
            {
                button.Text = ""; // Hide text when not hovering
                StartAnimation(button, false);
            };
        }

        private void StartAnimation(Guna2GradientButton button, bool expanding)
        {
            Timer timer = button == btnUpdate
                ? btnTimerUpdate
                : btnTimerDelete;

            timer.Tag = new { Button = button, Expanding = expanding };
            timer.Start();
        }

        private void BtnUpdate_Animate(object sender, EventArgs e)
        {
            AnimateButton(btnTimerUpdate);
        }

        private void BtnDelete_Animate(object sender, EventArgs e)
        {
            AnimateButton(btnTimerDelete);
        }

        private void AnimateButton(Timer timer)
        {
            dynamic state = timer.Tag;
            Guna2GradientButton button = state.Button;
            bool expanding = state.Expanding;

            if (expanding && button.Width < ButtonMaxWidth)
            {
                int delta = AnimationSpeed;
                button.Left -= delta; // Move the button to the left
                button.Width += delta; // Increase width

                if (button.Width >= ButtonMaxWidth)
                {
                    button.Width = ButtonMaxWidth;
                    button.Left += button.Width - ButtonMaxWidth; // Ensure alignment
                    timer.Stop();
                }
            }
            else if (!expanding && button.Width > ButtonMinWidth)
            {
                int delta = AnimationSpeed;
                button.Left += delta; // Move the button to the right
                button.Width -= delta; // Decrease width

                if (button.Width <= ButtonMinWidth)
                {
                    button.Width = ButtonMinWidth;
                    timer.Stop();
                }
            }
        }

        private void DocAppointment_Load(object sender, EventArgs e)
        {
            // Initialize columns for dgvDocAppointment
            dgvDocAppointment.AutoGenerateColumns = false;

            if (dgvDocAppointment.Columns.Count == 0)
            {
                dgvDocAppointment.Columns.Add("AppointmentID", "Appointment ID");
                dgvDocAppointment.Columns.Add("PatientName", "Patient Name");
                dgvDocAppointment.Columns.Add("Diagnosis", "Diagnosis"); // New Diagnosis column
                dgvDocAppointment.Columns.Add("AppointmentDate", "Appointment Date");
                dgvDocAppointment.Columns.Add("AppointmentStatus", "Status");
                dgvDocAppointment.Columns.Add("AppointmentFloor", "Floor");
                dgvDocAppointment.Columns.Add("TimeAvailability", "Availability");
                dgvDocAppointment.Columns.Add("TimeIn", "Time In");
                dgvDocAppointment.Columns.Add("TimeOut", "Time Out");
                dgvDocAppointment.Columns.Add("AppointmentTime", "Appointment Time");

                // Add select button column
                var selectColumn = new DataGridViewButtonColumn
                {
                    Name = "Select",
                    HeaderText = "Select",
                    Text = "Select",
                    UseColumnTextForButtonValue = true // Display "Select" as button text
                };
                dgvDocAppointment.Columns.Add(selectColumn);
            }

            // Load all appointment data
            LoadAppointments();
        }


        private void LoadAppointments()
        {
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    // SQL query to fetch appointment details along with Diagnosis from PatientDiagnosis
                    string query = @"
            SELECT 
                a.AppointmentID,
                p.FullName AS PatientName,
                pd.Diagnosis,
                pd.DateDiagnosed,
                a.AppointmentDate,
                a.AppointmentStatus,
                a.AppointmentFloor,
                a.TimeAvailability,
                a.TimeIn,
                a.TimeOut,
                a.AppointmentTime
            FROM 
                Appointment a
            INNER JOIN 
                Patient p ON a.PatientID = p.PatientID
            LEFT JOIN 
                PatientDiagnosis pd ON p.PatientID = pd.PatientID
            ORDER BY 
                a.AppointmentDate";

                    var adapter = new SqlDataAdapter(query, conn);
                    var dt = new DataTable();
                    adapter.Fill(dt);

                    dgvDocAppointment.Rows.Clear(); // Clear previous rows

                    foreach (DataRow row in dt.Rows)
                    {
                        // Add data to DataGridView, including Diagnosis
                        dgvDocAppointment.Rows.Add(
                            row["AppointmentID"],
                            row["PatientName"],
                            row["Diagnosis"],  // Diagnosis data from PatientDiagnosis table
                            row["AppointmentDate"],
                            row["AppointmentStatus"],
                            row["AppointmentFloor"],
                            row["TimeAvailability"],
                            row["TimeIn"],
                            row["TimeOut"],
                            row["AppointmentTime"]
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading appointments: {ex.Message}");
            }
        }



        private void dgvDocAppointment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the Select button column was clicked
            if (e.ColumnIndex == dgvDocAppointment.Columns["Select"].Index && e.RowIndex >= 0)
            {
                var row = dgvDocAppointment.Rows[e.RowIndex];
                txtPatFullName.Text = row.Cells["PatientFullName"].Value.ToString();
                txtDiagnosis.Text = row.Cells["Diagnosis"].Value.ToString(); // Populate Diagnosis
                dtpDate.Value = Convert.ToDateTime(row.Cells["AppointmentDate"].Value);
                cbAppointmentStatus.Text = row.Cells["AppointmentStatus"].Value.ToString();
                txtFloor.Text = row.Cells["Floor"].Value.ToString();
                txtTimeAvailability.Text = row.Cells["TimeAvailability"].Value.ToString();
                txtTimeIn.Text = row.Cells["TimeIn"].Value.ToString();
                txtTimeOut.Text = row.Cells["TimeOut"].Value.ToString();
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                try
                {
                    int patientId = GetPatientIdFromName(txtPatFullName.ToString());

                    if (patientId == -1)
                    {
                        MessageBox.Show("Invalid Patient. Please select a valid entry.");
                        return;
                    }

                    DateTime appointmentDate = dtpDate.Value;
                    string appointmentStatus = cbAppointmentStatus.SelectedItem.ToString();
                    string appointmentFloor = txtFloor.ToString();
                    string timeAvailability = txtTimeAvailability.ToString();
                    DateTime timeIn = DateTime.Parse(txtTimeIn.Text);
                    DateTime timeOut = DateTime.Parse(txtTimeOut.Text);
                    int appointmentId = GetSelectedAppointmentId();

                    using (SqlConnection conn = new SqlConnection(ConnectionString))
                    {
                        conn.Open();
                        string query = @"
UPDATE Appointment 
SET PatientID = @PatientID, AppointmentDate = @AppointmentDate, 
    AppointmentStatus = @AppointmentStatus, AppointmentFloor = @AppointmentFloor, 
    TimeAvailability = @TimeAvailability, TimeIn = @TimeIn, TimeOut = @TimeOut
WHERE AppointmentID = @AppointmentID";

                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@PatientID", patientId);
                        cmd.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
                        cmd.Parameters.AddWithValue("@AppointmentStatus", appointmentStatus);
                        cmd.Parameters.AddWithValue("@AppointmentFloor", appointmentFloor);
                        cmd.Parameters.AddWithValue("@TimeAvailability", timeAvailability);
                        cmd.Parameters.AddWithValue("@TimeIn", timeIn);
                        cmd.Parameters.AddWithValue("@TimeOut", timeOut);
                        cmd.Parameters.AddWithValue("@AppointmentID", appointmentId);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Appointment successfully updated!");

                        // Refresh the appointments grid after update
                        LoadAppointments();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating appointment: {ex.Message}");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int appointmentId = GetSelectedAppointmentId();

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM Appointment WHERE AppointmentID = @AppointmentID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@AppointmentID", appointmentId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Appointment successfully deleted!");

                    // Refresh the appointments grid after delete
                    LoadAppointments();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting appointment: {ex.Message}");
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(txtPatFullName.Text) || string.IsNullOrEmpty(cbAppointmentStatus.Text) ||
                string.IsNullOrEmpty(txtFloor.Text) || string.IsNullOrEmpty(txtTimeAvailability.Text) ||
                string.IsNullOrEmpty(txtTimeIn.Text) || string.IsNullOrEmpty(txtTimeOut.Text))
            {
                MessageBox.Show("All fields must be filled out.");
                return false;
            }

            return true;
        }

        private int GetSelectedAppointmentId()
        {
            if (dgvDocAppointment.SelectedRows.Count > 0)
            {
                return Convert.ToInt32(dgvDocAppointment.SelectedRows[0].Cells["AppointmentID"].Value);
            }

            MessageBox.Show("Please select an appointment.");
            return -1;
        }

        private int GetPatientIdFromName(string fullName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT PatientID FROM Patient WHERE FullName = @FullName";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FullName", fullName);

                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
            catch
            {
                return -1;
            }
        }


    }
}
