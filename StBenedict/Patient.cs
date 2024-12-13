using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace StBenedict
{
    public partial class Patient : Form
    {
        private const string connectionString =
             @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Kuraisura\Downloads\StBenedict7.0\StBenedict6.0\StBenedict4.0\StBenedict4.0\StBenedict\StBenedict\StBenedict\StBenedict.mdf;Integrated Security=True";
        private Timer btnTimerInsert, btnTimerUpdate, btnTimerDelete;
        private const int ButtonMinWidth = 40;
        private const int ButtonMaxWidth = 100;
        private const int AnimationSpeed = 10;

        private Dictionary<string, List<string>> diagnosisMap = new Dictionary<string, List<string>>
{
    // General Medicine
    { "Hypertension", new List<string> { "General Medicine", "Cardiology" } },
    { "Diabetes Mellitus", new List<string> { "General Medicine" } },
    { "Hyperlipidemia", new List<string> { "General Medicine" } },
    { "Asthma", new List<string> { "General Medicine", "Pediatrics" } },
    { "COPD", new List<string> { "General Medicine" } },
    { "GERD", new List<string> { "General Medicine" } },
    { "Upper Respiratory Infections", new List<string> { "General Medicine" } },
    { "Anemia", new List<string> { "General Medicine" } },
    { "Thyroid disorders", new List<string> { "General Medicine" } },
    { "Kidney Disease", new List<string> { "General Medicine" } },
    { "Obesity", new List<string> { "General Medicine" } },
    { "Allergic Rhinitis", new List<string> { "General Medicine", "Pediatrics" } },
    { "Sleep Apnea", new List<string> { "General Medicine" } },
    { "Fatigue Syndromes", new List<string> { "General Medicine" } },
    { "Acid Reflux", new List<string> { "General Medicine" } },
    { "UTIs", new List<string> { "General Medicine" } },
    { "Mental Health Conditions", new List<string> { "General Medicine" } },
    { "Infections", new List<string> { "General Medicine" } },
    { "Chronic Pain Syndromes", new List<string> { "General Medicine" } },

    // Pediatrics
    { "Bronchiolitis", new List<string> { "Pediatrics" } },
    { "Pneumonia", new List<string> { "Pediatrics" } },
    { "Croup", new List<string> { "Pediatrics" } },
    { "Gastroenteritis", new List<string> { "Pediatrics" } },
    { "Ear Infections", new List<string> { "Pediatrics" } },
    { "RSV Infection", new List<string> { "Pediatrics" } },
    { "Diarrhea and Vomiting", new List<string> { "Pediatrics" } },
    { "Fever and Sepsis", new List<string> { "Pediatrics" } },
    { "ADHD", new List<string> { "Pediatrics" } },
    { "ASD", new List<string> { "Pediatrics" } },
    { "Eczema", new List<string> { "Pediatrics", "Dermatology" } },
    { "Childhood Obesity", new List<string> { "Pediatrics" } },
    { "Congenital heart defects", new List<string> { "Pediatrics" } },

    // Orthopedics
    { "Fractures", new List<string> { "Orthopedics" } },
    { "Osteoarthritis", new List<string> { "Orthopedics" } },
    { "Rheumatoid Arthritis", new List<string> { "Orthopedics" } },
    { "Spondylosis", new List<string> { "Orthopedics" } },
    { "Sciatica", new List<string> { "Orthopedics" } },
    { "Carpal Tunnel Syndrome", new List<string> { "Orthopedics" } },
    { "Sprains and Strains", new List<string> { "Orthopedics" } },
    { "Bursitis", new List<string> { "Orthopedics" } },
    { "Tendonitis", new List<string> { "Orthopedics" } },
    { "Herniated Discs", new List<string> { "Orthopedics" } },
    { "Osteoporosis", new List<string> { "Orthopedics" } },

    // Cardiology
    { "Coronary Artery Disease", new List<string> { "Cardiology" } },
    { "Heart Attack", new List<string> { "Cardiology" } },
    { "Heart Failure", new List<string> { "Cardiology" } },
    { "Arrhythmias", new List<string> { "Cardiology" } },
    { "Valvular Heart Diseases", new List<string> { "Cardiology" } },
    { "Cardiomyopathy", new List<string> { "Cardiology" } },

    // Dermatology
    { "Acne", new List<string> { "Dermatology" } },
    { "Psoriasis", new List<string> { "Dermatology" } },
    { "Rosacea", new List<string> { "Dermatology" } },
    { "Melanoma", new List<string> { "Dermatology" } },
    { "BCC", new List<string> { "Dermatology" } },
    { "SCC", new List<string> { "Dermatology" } },
    { "Hives", new List<string> { "Dermatology" } },
    { "Contact Dermatitis", new List<string> { "Dermatology" } },

    // Ophthalmology
    { "Cataracts", new List<string> { "Ophthalmology" } },
    { "Glaucoma", new List<string> { "Ophthalmology" } },
    { "Macular Degeneration", new List<string> { "Ophthalmology" } },
    { "Diabetic Retinopathy", new List<string> { "Ophthalmology" } },
    { "Retinal Detachment", new List<string> { "Ophthalmology" } },
    { "Conjunctivitis", new List<string> { "Ophthalmology" } },
    { "Dry Eye Syndrome", new List<string> { "Ophthalmology" } },
    { "Astigmatism", new List<string> { "Ophthalmology" } },
    { "Myopia", new List<string> { "Ophthalmology" } },
    { "Hyperopia", new List<string> { "Ophthalmology" } },
    { "Presbyopia", new List<string> { "Ophthalmology" } },
    { "Strabismus", new List<string> { "Ophthalmology" } },
    { "Amblyopia", new List<string> { "Ophthalmology" } },
    { "Eye Injuries", new List<string> { "Ophthalmology" } },
    { "Keratoconus", new List<string> { "Ophthalmology" } },
    { "Uveitis", new List<string> { "Ophthalmology" } },
    { "Pterygium", new List<string> { "Ophthalmology" } },
    { "Blepharitis", new List<string> { "Ophthalmology" } },
    { "Eye Infections", new List<string> { "Ophthalmology" } },
    { "Retinal Vascular Occlusion", new List<string> { "Ophthalmology" } },
    { "Color Blindness", new List<string> { "Ophthalmology" } },
    { "Corneal Ulcers", new List<string> { "Ophthalmology" } },
    { "Optic Neuritis", new List<string> { "Ophthalmology" } },
    { "Eye Tumors", new List<string> { "Ophthalmology" } }
};




        public Patient()
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

            // Setup autocomplete for txtDiagnosis
            txtDiagnosis.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtDiagnosis.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection autoCompleteSource = new AutoCompleteStringCollection();
            autoCompleteSource.AddRange(diagnosisMap.Keys.ToArray());
            txtDiagnosis.AutoCompleteCustomSource = autoCompleteSource;

            // Add event for when the diagnosis text changes
            txtDiagnosis.TextChanged += TxtDiagnosis_TextChanged;
            LoadPatients();
        }

        private void Patient_Load(object sender, EventArgs e)
        {
            dgvPatient.AutoGenerateColumns = false;

            // Define columns if not already added
            if (dgvPatient.Columns.Count == 0)
            {
                dgvPatient.Columns.Add("PatientID", "ID");
                dgvPatient.Columns.Add("FirstName", "First Name");
                dgvPatient.Columns.Add("MiddleName", "Middle Name");
                dgvPatient.Columns.Add("LastName", "Last Name");
                dgvPatient.Columns.Add("Suffix", "Suffix");
                dgvPatient.Columns.Add("Age", "Age");
                dgvPatient.Columns.Add("Gender", "Gender");
                dgvPatient.Columns.Add("Address", "Address");
                dgvPatient.Columns.Add("DateOfBirth", "Date of Birth");

                // Add Diagnosis column
                dgvPatient.Columns.Add("Diagnosis", "Diagnosis");

                // Add RecommendedDoctor column
                dgvPatient.Columns.Add("RecommendedDoctor", "Recommended Doctor");

                // Add select button column
                var selectColumn = new DataGridViewImageColumn
                {
                    Name = "Select",
                    HeaderText = "Select",
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                dgvPatient.Columns.Add(selectColumn);
            }

            // Automatically load patient data into the DataGridView
            LoadPatients();
        }





        private void TxtDiagnosis_TextChanged(object sender, EventArgs e)
        {
            string input = txtDiagnosis.Text;

            if (diagnosisMap.ContainsKey(input))
            {
                List<string> specialties = diagnosisMap[input];  // Now specialties is a List<string>

                // Show the specialties in the label
                lblSpecialty.Text = "" + string.Join(", ", specialties);

                // Retrieve doctors for all specialties
                cbRecommendedDoctor.Items.Clear();  // Clear previous items

                // Loop through each specialty and retrieve doctors
                foreach (var specialty in specialties)
                {
                    GetDoctorsForSpecialty(specialty);  // Assuming this method handles retrieving doctors for a single specialty
                }
            }
            else
            {
                lblSpecialty.Text = "Specialty: Not Found";
                cbRecommendedDoctor.Items.Clear();
                cbRecommendedDoctor.Text = "Select Doctor";  // Reset ComboBox text
            }
        }


        private void GetDoctorsForSpecialty(string specialty)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT FirstName, MiddleName, LastName, Suffix FROM Doctor WHERE Specialty = @Specialty";
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Specialty", specialty);

                    conn.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string fullName = $"{reader["FirstName"]} {reader["MiddleName"]} {reader["LastName"]} {reader["Suffix"]}".Trim();
                        cbRecommendedDoctor.Items.Add(fullName);
                    }

                    if (cbRecommendedDoctor.Items.Count > 0)
                        cbRecommendedDoctor.SelectedIndex = 0;  // Select the first doctor

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching doctors: " + ex.Message);
            }
        }



        private void LoadPatients()
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    string query = @"
            SELECT 
                p.PatientID, 
                p.FirstName, 
                p.MiddleName, 
                p.LastName, 
                p.Suffix, 
                p.Age, 
                p.Gender, 
                p.Address, 
                p.DateOfBirth,
                d.Diagnosis,
                p.RecommendedDoctor,  -- Fetch RecommendedDoctor from Patient table
                doc.FirstName AS DoctorFirstName, 
                doc.MiddleName AS DoctorMiddleName, 
                doc.LastName AS DoctorLastName, 
                doc.Suffix AS DoctorSuffix
            FROM Patient p
            LEFT JOIN PatientDiagnosis d ON p.PatientID = d.PatientID
            LEFT JOIN Doctor doc ON doc.Specialty = d.Diagnosis"; // Assuming a mapping between diagnosis and doctor specialty

                    var adapter = new SqlDataAdapter(query, conn);
                    var dt = new DataTable();
                    adapter.Fill(dt);

                    dgvPatient.Rows.Clear();

                    // Loop through each row in the DataTable and add it to the DataGridView
                    foreach (DataRow row in dt.Rows)
                    {
                        // Concatenate the doctor's full name
                        string doctorFullName = $"{row["DoctorFirstName"]} {row["DoctorMiddleName"]} {row["DoctorLastName"]} {row["DoctorSuffix"]}".Trim();

                        // Fetch the RecommendedDoctor field from the Patient table
                        string recommendedDoctor = row["RecommendedDoctor"].ToString().Trim();

                        // Add the row to the DataGridView
                        // Ensure we add an image or a default image for the "Select" column
                        dgvPatient.Rows.Add(
                            row["PatientID"],
                            row["FirstName"],
                            row["MiddleName"],
                            row["LastName"],
                            row["Suffix"],
                            row["Age"],
                            row["Gender"],
                            row["Address"],
                            Convert.ToDateTime(row["DateOfBirth"]).ToString("yyyy-MM-dd"),
                            row["Diagnosis"], // Diagnosis column
                            row["recommendedDoctor"] // Add the RecommendedDoctor column (from Patient table)
                                                     // Add a default image (or null) for the Select column

                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading patients: " + ex.Message);
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
                    // Ensure that essential fields are not empty
                    if (string.IsNullOrEmpty(txtFirstName.Text) || string.IsNullOrEmpty(txtLastName.Text))
                    {
                        MessageBox.Show("First Name and Last Name are required.");
                        return;
                    }

                    // Check if age is a valid number
                    if (!int.TryParse(txtAge.Text, out int age))
                    {
                        MessageBox.Show("Please enter a valid age.");
                        return;
                    }

                    // Ensure that gender is selected
                    if (string.IsNullOrEmpty(cbGender.Text))
                    {
                        MessageBox.Show("Please select a gender.");
                        return;
                    }

                    // Ensure that Recommended Doctor is selected
                    if (string.IsNullOrEmpty(cbRecommendedDoctor.Text))
                    {
                        MessageBox.Show("Please select a recommended doctor.");
                        return;
                    }

                    // Ensure that Specialty is not empty
                    if (string.IsNullOrEmpty(lblSpecialty.Text))
                    {
                        MessageBox.Show("Specialty is required.");
                        return;
                    }

                    // Check if the suffix is "None" and set it to an empty string
                    string suffix = cbSuffix.Text == "None" ? "" : cbSuffix.Text;

                    using (var conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        // Insert the Specialty if it doesn't exist and retrieve its ID
                        int specialtyId = GetOrInsertSpecialty(lblSpecialty.Text);

                        // Insert the Patient
                        string query = @"
        INSERT INTO Patient 
            (FirstName, MiddleName, LastName, Suffix, Age, Gender, Address, DateOfBirth, RecommendedDoctor, SpecialtyID) 
        VALUES 
            (@FirstName, @MiddleName, @LastName, @Suffix, @Age, @Gender, @Address, @DateOfBirth, @RecommendedDoctor, @SpecialtyID);

        SELECT SCOPE_IDENTITY();";

                        var cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        cmd.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                        cmd.Parameters.AddWithValue("@Suffix", suffix); // Use the adjusted suffix value
                        cmd.Parameters.AddWithValue("@Age", age);
                        cmd.Parameters.AddWithValue("@Gender", cbGender.Text);
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@DateOfBirth", dtpBirthDate.Value);
                        cmd.Parameters.AddWithValue("@RecommendedDoctor", string.IsNullOrEmpty(cbRecommendedDoctor.Text) ? (object)DBNull.Value : cbRecommendedDoctor.Text);
                        cmd.Parameters.AddWithValue("@SpecialtyID", specialtyId);

                        int patientId = Convert.ToInt32(cmd.ExecuteScalar()); // Get the inserted PatientID

                        // Insert diagnosis if provided
                        if (!string.IsNullOrEmpty(txtDiagnosis.Text))
                        {
                            string diagnosisQuery = "INSERT INTO PatientDiagnosis (PatientID, Diagnosis) VALUES (@PatientID, @Diagnosis)";
                            SqlCommand diagnosisCmd = new SqlCommand(diagnosisQuery, conn);
                            diagnosisCmd.Parameters.AddWithValue("@PatientID", patientId);
                            diagnosisCmd.Parameters.AddWithValue("@Diagnosis", txtDiagnosis.Text);
                            diagnosisCmd.ExecuteNonQuery(); // Insert the diagnosis into PatientDiagnosis table
                        }

                        MessageBox.Show("Patient and Specialty added successfully.");
                        LoadPatients(); // Refresh the DataGridView
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting patient: " + ex.Message);
                }
            }


        private int GetOrInsertSpecialty(string specialtyName)
        {
            if (string.IsNullOrWhiteSpace(specialtyName))
                throw new ArgumentException("Specialty name cannot be null or empty.");

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Check if the specialty already exists
                string checkQuery = "SELECT SpecialtyID FROM Specialty WHERE SpecialtyName = @SpecialtyName";
                var checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@SpecialtyName", specialtyName);
                var result = checkCmd.ExecuteScalar();

                if (result != null)
                {
                    return Convert.ToInt32(result); // Specialty exists, return its ID
                }

                // Insert new specialty if it doesn't exist
                string insertQuery = "INSERT INTO Specialty (SpecialtyName) VALUES (@SpecialtyName); SELECT SCOPE_IDENTITY();";
                var insertCmd = new SqlCommand(insertQuery, conn);
                insertCmd.Parameters.AddWithValue("@SpecialtyName", specialtyName);

                return Convert.ToInt32(insertCmd.ExecuteScalar()); // Return the new SpecialtyID
            }
        }






        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure that a patient is selected
                if (dgvPatient.CurrentRow == null)
                {
                    MessageBox.Show("Please select a patient to delete.");
                    return;
                }

                int patientId = Convert.ToInt32(dgvPatient.CurrentRow.Cells["PatientID"].Value);

                // Confirm the deletion
                var result = MessageBox.Show("Are you sure you want to delete this patient?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes) return;

                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // First, delete related diagnosis records
                    string deleteDiagnosisQuery = "DELETE FROM PatientDiagnosis WHERE PatientID = @PatientID";
                    var deleteDiagnosisCmd = new SqlCommand(deleteDiagnosisQuery, conn);
                    deleteDiagnosisCmd.Parameters.AddWithValue("@PatientID", patientId);
                    deleteDiagnosisCmd.ExecuteNonQuery();

                    // Then, delete the patient record
                    string deletePatientQuery = "DELETE FROM Patient WHERE PatientID = @PatientID";
                    var deletePatientCmd = new SqlCommand(deletePatientQuery, conn);
                    deletePatientCmd.Parameters.AddWithValue("@PatientID", patientId);
                    deletePatientCmd.ExecuteNonQuery();

                    MessageBox.Show("Patient deleted successfully.");
                    LoadPatients(); // Refresh the DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting patient: " + ex.Message);
            }
        }




        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure that a patient is selected
                if (dgvPatient.CurrentRow == null)
                {
                    MessageBox.Show("Please select a patient to update.");
                    return;
                }

                // Ensure that essential fields are not empty
                if (string.IsNullOrEmpty(txtFirstName.Text) || string.IsNullOrEmpty(txtLastName.Text))
                {
                    MessageBox.Show("First Name and Last Name are required.");
                    return;
                }

                // Check if age is a valid number
                if (!int.TryParse(txtAge.Text, out int age))
                {
                    MessageBox.Show("Please enter a valid age.");
                    return;
                }

                // Ensure that the gender is selected
                if (string.IsNullOrEmpty(cbGender.Text))
                {
                    MessageBox.Show("Please select a gender.");
                    return;
                }

                // Ensure that the Recommended Doctor is selected
                if (string.IsNullOrEmpty(cbRecommendedDoctor.Text))
                {
                    MessageBox.Show("Please select a recommended doctor.");
                    return;
                }

                int patientId = Convert.ToInt32(dgvPatient.CurrentRow.Cells["PatientID"].Value);

                // Check if the suffix is "None" and set it to an empty string
                string suffix = cbSuffix.Text == "None" ? "" : cbSuffix.Text;

                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Insert the Specialty if it doesn't exist and retrieve its ID
                    int specialtyId = GetOrInsertSpecialty(lblSpecialty.Text);

                    string query = @"
UPDATE Patient 
SET FirstName = @FirstName, 
    MiddleName = @MiddleName, 
    LastName = @LastName, 
    Suffix = @Suffix, 
    Age = @Age, 
    Gender = @Gender, 
    Address = @Address, 
    DateOfBirth = @DateOfBirth, 
    RecommendedDoctor = @RecommendedDoctor, 
    SpecialtyID = @SpecialtyID
WHERE PatientID = @PatientID";

                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@PatientID", patientId);
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@Suffix", suffix); // Use the adjusted suffix value
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@Gender", cbGender.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@DateOfBirth", dtpBirthDate.Value);
                    cmd.Parameters.AddWithValue("@RecommendedDoctor", string.IsNullOrEmpty(cbRecommendedDoctor.Text) ? (object)DBNull.Value : cbRecommendedDoctor.Text);
                    cmd.Parameters.AddWithValue("@SpecialtyID", specialtyId);

                    cmd.ExecuteNonQuery();

                    // Update the diagnosis if provided
                    if (!string.IsNullOrEmpty(txtDiagnosis.Text))
                    {
                        string updateDiagnosisQuery = "UPDATE PatientDiagnosis SET Diagnosis = @Diagnosis WHERE PatientID = @PatientID";
                        SqlCommand updateDiagnosisCmd = new SqlCommand(updateDiagnosisQuery, conn);
                        updateDiagnosisCmd.Parameters.AddWithValue("@PatientID", patientId);
                        updateDiagnosisCmd.Parameters.AddWithValue("@Diagnosis", txtDiagnosis.Text);
                        updateDiagnosisCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Patient updated successfully.");
                    LoadPatients(); // Refresh the DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating patient: " + ex.Message);
            }
        }





    }
}
