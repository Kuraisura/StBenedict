using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace StBenedict
{
    public partial class Doctor : Form
    {
        private const string ConnectionString =
             @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Kuraisura\Downloads\StBenedict7.0\StBenedict6.0\StBenedict4.0\StBenedict4.0\StBenedict\StBenedict\StBenedict\StBenedict.mdf;Integrated Security=True";
        private Timer btnTimerInsert, btnTimerUpdate, btnTimerDelete;
        private const int ButtonMinWidth = 40;
        private const int ButtonMaxWidth = 100;
        private const int AnimationSpeed = 10;

        public Doctor()
        {
            InitializeComponent();

            // Initialize button timers
            btnTimerInsert = new Timer { Interval = 10 };
            btnTimerUpdate = new Timer { Interval = 10 };
            btnTimerDelete = new Timer { Interval = 10 };

            btnTimerInsert.Tick += BtnInsert_Animate;
            btnTimerUpdate.Tick += BtnUpdate_Animate;
            btnTimerDelete.Tick += BtnDelete_Animate;

            // Setup buttons
            SetupButton(btnInsert, "     Insert");
            SetupButton(btnUpdate, "     Update");
            SetupButton(btnDelete, "     Delete");

            // Customize combobox to remove "x" (clear) button
            cbSuffix.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSpecialty.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Doctor_Load(object sender, EventArgs e)
        {
            dgvDoctor.AutoGenerateColumns = false;

            // Define columns if not already added
            if (dgvDoctor.Columns.Count == 0)
            {
                dgvDoctor.Columns.Add("DoctorID", "ID");
                dgvDoctor.Columns.Add("FirstName", "First Name");
                dgvDoctor.Columns.Add("MiddleName", "Middle Name");
                dgvDoctor.Columns.Add("LastName", "Last Name");
                dgvDoctor.Columns.Add("Suffix", "Suffix");
                dgvDoctor.Columns.Add("CellphoneNumber", "Cellphone Number");
                dgvDoctor.Columns.Add("Specialty", "Specialty");
                dgvDoctor.Columns.Add("Username", "Username");
                dgvDoctor.Columns.Add("Password", "Password");

                // Add select button column
                var selectColumn = new DataGridViewImageColumn
                {
                    Name = "Select",
                    HeaderText = "Select",
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                dgvDoctor.Columns.Add(selectColumn);
            }

            // Load all doctor data
            LoadDoctors();
        }

        private void LoadDoctors()
        {
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    // Remove TimeAvailable from the SELECT query
                    string query = "SELECT DoctorID, FirstName, MiddleName, LastName, Suffix, CellphoneNumber, Specialty, Username, Password FROM Doctor INNER JOIN Login ON Doctor.LoginID = Login.LoginID";
                    var adapter = new SqlDataAdapter(query, conn);
                    var dt = new DataTable();
                    adapter.Fill(dt);

                    dgvDoctor.Rows.Clear();

                    foreach (DataRow row in dt.Rows)
                    {
                        dgvDoctor.Rows.Add(
                            row["DoctorID"],
                            row["FirstName"],
                            row["MiddleName"],
                            row["LastName"],
                            row["Suffix"],
                            row["CellphoneNumber"],
                            row["Specialty"],
                            row["Username"],
                            row["Password"]
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading doctors: " + ex.Message);
            }
        }

        private void SetupButton(Guna2GradientButton button, string text)
        {
            button.Width = ButtonMinWidth;
            button.Text = "";
            button.TextAlign = HorizontalAlignment.Center;
            button.ImageAlign = HorizontalAlignment.Left;
            button.Tag = text;

            button.MouseEnter += (s, e) =>
            {
                button.Text = text;
                StartAnimation(button, true);
            };

            button.MouseLeave += (s, e) =>
            {
                button.Text = "";
                StartAnimation(button, false);
            };
        }

        private void StartAnimation(Guna2GradientButton button, bool expanding)
        {
            var timer = button == btnInsert ? btnTimerInsert
                : button == btnUpdate ? btnTimerUpdate
                : btnTimerDelete;

            timer.Tag = new { Button = button, Expanding = expanding };
            timer.Start();
        }

        private void BtnInsert_Animate(object sender, EventArgs e) => AnimateButton(btnTimerInsert);
        private void BtnUpdate_Animate(object sender, EventArgs e) => AnimateButton(btnTimerUpdate);
        private void BtnDelete_Animate(object sender, EventArgs e) => AnimateButton(btnTimerDelete);


        private void cbAvailability_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Method to populate the cbAvailability based on selected specialty
        private void cbSpecialty_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AnimateButton(Timer timer)
        {
            dynamic state = timer.Tag;
            var button = (Guna2GradientButton)state.Button;
            var expanding = state.Expanding;

            int delta = AnimationSpeed;
            if (expanding && button.Width < ButtonMaxWidth)
            {
                button.Left -= delta;
                button.Width += delta;

                if (button.Width >= ButtonMaxWidth)
                {
                    button.Width = ButtonMaxWidth;
                    timer.Stop();
                }
            }
            else if (!expanding && button.Width > ButtonMinWidth)
            {
                button.Left += delta;
                button.Width -= delta;

                if (button.Width <= ButtonMinWidth)
                {
                    button.Width = ButtonMinWidth;
                    timer.Stop();
                }
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    // Validate required fields
                    if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                        string.IsNullOrWhiteSpace(txtLastName.Text) ||
                        string.IsNullOrWhiteSpace(cbSpecialty.Text) ||
                        string.IsNullOrWhiteSpace(txtUsername.Text) ||
                        string.IsNullOrWhiteSpace(txtPassword.Text) ||
                        string.IsNullOrWhiteSpace(txtCellphone.Text))
                    {
                        MessageBox.Show("Please fill in all required fields.");
                        return;
                    }

                    // Validate Cellphone Number (Only numbers and must be 11 digits)
                    if (!long.TryParse(txtCellphone.Text.Trim(), out _) || txtCellphone.Text.Trim().Length != 11)
                    {
                        MessageBox.Show("Cellphone number must be numeric and 11 digits long.");
                        return;
                    }

                    // Check for duplicate username and password in Login table
                    string checkUsernamePasswordQuery = "SELECT COUNT(*) FROM Login WHERE Username = @Username AND Password = @Password";
                    using (var checkCmd = new SqlCommand(checkUsernamePasswordQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                        checkCmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                        int userExists = (int)checkCmd.ExecuteScalar();
                        if (userExists > 0)
                        {
                            MessageBox.Show("This username and password already exist. Please choose a different one.");
                            return;
                        }
                    }

                    // Check for duplicate cellphone number and full name (FirstName + LastName)
                    string checkPhoneNameQuery = "SELECT COUNT(*) FROM Doctor WHERE (FirstName + ' ' + LastName) = @FullName AND CellphoneNumber = @CellphoneNumber";
                    using (var checkCmd = new SqlCommand(checkPhoneNameQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@FullName", txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim());
                        checkCmd.Parameters.AddWithValue("@CellphoneNumber", txtCellphone.Text.Trim());
                        int doctorExists = (int)checkCmd.ExecuteScalar();
                        if (doctorExists > 0)
                        {
                            MessageBox.Show("A doctor with the same full name and cellphone number already exists.");
                            return;
                        }
                    }

                    // Check if the suffix is "None" and replace it with an empty string
                    string suffix = cbSuffix.Text.Trim() == "None" ? "" : cbSuffix.Text.Trim();

                    // Insert into Login table
                    string loginQuery = @"INSERT INTO Login (Username, Password) 
                          OUTPUT INSERTED.LoginID
                          VALUES (@Username, @Password)";
                    using (var loginCmd = new SqlCommand(loginQuery, conn))
                    {
                        loginCmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                        loginCmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());

                        int loginId = (int)loginCmd.ExecuteScalar(); // Get the inserted LoginID

                        // Insert into Doctor table
                        string doctorQuery = @"INSERT INTO Doctor 
                               (FirstName, MiddleName, LastName, Suffix, CellphoneNumber, Specialty, LoginID) 
                               VALUES (@FirstName, @MiddleName, @LastName, @Suffix, @CellphoneNumber, @Specialty, @LoginID)";

                        using (var doctorCmd = new SqlCommand(doctorQuery, conn))
                        {
                            doctorCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                            doctorCmd.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text.Trim());
                            doctorCmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                            doctorCmd.Parameters.AddWithValue("@Suffix", suffix);  // Use the adjusted suffix value
                            doctorCmd.Parameters.AddWithValue("@CellphoneNumber", txtCellphone.Text.Trim());
                            doctorCmd.Parameters.AddWithValue("@Specialty", cbSpecialty.Text.Trim());
                            doctorCmd.Parameters.AddWithValue("@LoginID", loginId); // Pass the newly inserted LoginID here

                            doctorCmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Doctor added successfully.");
                        LoadDoctors(); // Refresh data or UI if applicable
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting doctor: " + ex.Message);
            }
        }






        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dgvDoctor.CurrentRow == null)
                {
                    MessageBox.Show("Please select a doctor to update.");
                    return;
                }

                int doctorId = Convert.ToInt32(dgvDoctor.CurrentRow.Cells["DoctorID"].Value);

                using (var conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    // Validate required fields
                    if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                        string.IsNullOrWhiteSpace(txtLastName.Text) ||
                        string.IsNullOrWhiteSpace(cbSpecialty.Text) ||
                        string.IsNullOrWhiteSpace(txtUsername.Text) ||
                        string.IsNullOrWhiteSpace(txtPassword.Text) ||
                        string.IsNullOrWhiteSpace(txtCellphone.Text))
                    {
                        MessageBox.Show("Please fill in all required fields.");
                        return;
                    }

                    // Validate Cellphone Number (Only numbers and must be 11 digits)
                    if (!long.TryParse(txtCellphone.Text.Trim(), out _) || txtCellphone.Text.Trim().Length != 11)
                    {
                        MessageBox.Show("Cellphone number must be numeric and 11 digits long.");
                        return;
                    }

                    // Check if CellphoneNumber already exists (excluding the current doctor)
                    string checkCellphoneQuery = "SELECT COUNT(*) FROM Doctor WHERE CellphoneNumber = @CellphoneNumber AND DoctorID != @DoctorID";
                    using (var checkCellphoneCmd = new SqlCommand(checkCellphoneQuery, conn))
                    {
                        checkCellphoneCmd.Parameters.AddWithValue("@CellphoneNumber", txtCellphone.Text.Trim());
                        checkCellphoneCmd.Parameters.AddWithValue("@DoctorID", doctorId);
                        int phoneExists = (int)checkCellphoneCmd.ExecuteScalar();
                        if (phoneExists > 0)
                        {
                            MessageBox.Show("This cellphone number is already in use. Please choose a different number.");
                            return;
                        }
                    }

                    // Check for duplicate username (excluding the current doctor)
                    string checkUsernameQuery = "SELECT COUNT(*) FROM Login WHERE Username = @Username AND LoginID != @LoginID";
                    using (var checkUsernameCmd = new SqlCommand(checkUsernameQuery, conn))
                    {
                        checkUsernameCmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                        checkUsernameCmd.Parameters.AddWithValue("@LoginID", doctorId);
                        int userExists = (int)checkUsernameCmd.ExecuteScalar();
                        if (userExists > 0)
                        {
                            MessageBox.Show("This username is already taken. Please choose a different username.");
                            return;
                        }
                    }

                    // Get the LoginID associated with the selected DoctorID
                    string getLoginIdQuery = "SELECT LoginID FROM Doctor WHERE DoctorID = @DoctorID";
                    using (var getLoginIdCmd = new SqlCommand(getLoginIdQuery, conn))
                    {
                        getLoginIdCmd.Parameters.AddWithValue("@DoctorID", doctorId);
                        int loginId = (int)getLoginIdCmd.ExecuteScalar();

                        // Update the Login table with the new username and password
                        string updateLoginQuery = "UPDATE Login SET Username = @Username, Password = @Password WHERE LoginID = @LoginID";

                        using (var updateLoginCmd = new SqlCommand(updateLoginQuery, conn))
                        {
                            updateLoginCmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                            updateLoginCmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                            updateLoginCmd.Parameters.AddWithValue("@LoginID", loginId);
                            updateLoginCmd.ExecuteNonQuery();
                        }
                    }

                    // Check if the suffix is "None" and replace it with an empty string
                    string suffix = cbSuffix.Text.Trim() == "None" ? "" : cbSuffix.Text.Trim();

                    // Update the Doctor table
                    string updateDoctorQuery = @"UPDATE Doctor 
                                 SET FirstName = @FirstName, 
                                     MiddleName = @MiddleName, 
                                     LastName = @LastName, 
                                     Suffix = @Suffix, 
                                     CellphoneNumber = @CellphoneNumber, 
                                     Specialty = @Specialty 
                                 WHERE DoctorID = @DoctorID";

                    using (var updateDoctorCmd = new SqlCommand(updateDoctorQuery, conn))
                    {
                        updateDoctorCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                        updateDoctorCmd.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text.Trim());
                        updateDoctorCmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                        updateDoctorCmd.Parameters.AddWithValue("@Suffix", suffix);  // Use the adjusted suffix value
                        updateDoctorCmd.Parameters.AddWithValue("@CellphoneNumber", txtCellphone.Text.Trim());
                        updateDoctorCmd.Parameters.AddWithValue("@Specialty", cbSpecialty.Text.Trim());
                        updateDoctorCmd.Parameters.AddWithValue("@DoctorID", doctorId);

                        updateDoctorCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Doctor updated successfully.");
                    LoadDoctors(); // Refresh data or UI if applicable
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating doctor: " + ex.Message);
            }
        }




        private void txtCellphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control characters (like backspace)
            if (!char.IsControl(e.KeyChar))
            {
                // Check if the entered character is not a digit
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Prevent the character from being entered
                }
            }
        }




        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dgvDoctor.CurrentRow == null) return;

                int doctorId = Convert.ToInt32(dgvDoctor.CurrentRow.Cells["DoctorID"].Value);
                using (var conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    // Get LoginID of the doctor
                    string getLoginIdQuery = "SELECT LoginID FROM Doctor WHERE DoctorID = @DoctorID";
                    var getLoginIdCmd = new SqlCommand(getLoginIdQuery, conn);
                    getLoginIdCmd.Parameters.AddWithValue("@DoctorID", doctorId);
                    int loginId = (int)getLoginIdCmd.ExecuteScalar();

                    // Delete from Doctor table
                    string doctorQuery = "DELETE FROM Doctor WHERE DoctorID = @DoctorID";
                    var doctorCmd = new SqlCommand(doctorQuery, conn);
                    doctorCmd.Parameters.AddWithValue("@DoctorID", doctorId);
                    doctorCmd.ExecuteNonQuery();

                    // Delete from Login table
                    string loginQuery = "DELETE FROM Login WHERE LoginID = @LoginID";
                    var loginCmd = new SqlCommand(loginQuery, conn);
                    loginCmd.Parameters.AddWithValue("@LoginID", loginId);
                    loginCmd.ExecuteNonQuery();

                    MessageBox.Show("Doctor deleted successfully.");
                    LoadDoctors();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting doctor: " + ex.Message);
            }
        }
    }
}
