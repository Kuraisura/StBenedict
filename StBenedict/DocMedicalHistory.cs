using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;


namespace StBenedict
{
    public partial class DocMedicalHistory : Form
    {
        private const string ConnectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Kuraisura\Downloads\StBenedict7.0\StBenedict6.0\StBenedict4.0\StBenedict4.0\StBenedict\StBenedict\StBenedict\StBenedict.mdf;Integrated Security=True";

        public DocMedicalHistory()
        {
            InitializeComponent();
            // Disable the specified controls
            txtDiagnosis.Enabled = false;
            dtpDate.Enabled = false;
            txtTimeIn.Enabled = false;
            txtTimeOut.Enabled = false;
            txtProcedure.Enabled = false;
            txtPrescription.Enabled = false;
            txtDosage.Enabled = false;
            txtFrequency.Enabled = false;
            txtNotes.Enabled = false;
            txtDoctorFullName.Enabled = false;
            txtSpecialization.Enabled = false;
        }

        private void DocMedicalHistory_Load(object sender, EventArgs e)
        {
            LoadPatientFullNames();
        }

        private void LoadPatientFullNames()
        {
            cbPatientFullName.Items.Clear(); // Clear existing items
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT DISTINCT PatientFullName FROM MedicalHistory";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                MessageBox.Show("No patient names found in the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            while (reader.Read())
                            {
                                cbPatientFullName.Items.Add(reader["PatientFullName"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading patient names: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbPatientFullName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPatientDetails(cbPatientFullName.SelectedItem.ToString());
        }

        private void LoadPatientDetails(string patientFullName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT DoctorName, Role, Diagnosis, AppointmentDate, TimeIn, TimeOut, Surgery, Prescription, Dosage, Frequency, Notes " +
                                   "FROM MedicalHistory WHERE PatientFullName = @PatientFullName";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PatientFullName", patientFullName);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtDoctorFullName.Text = reader["DoctorName"].ToString();
                                txtSpecialization.Text = reader["Role"].ToString();
                                txtDiagnosis.Text = reader["Diagnosis"].ToString();
                                dtpDate.Value = Convert.ToDateTime(reader["AppointmentDate"]);
                                txtTimeIn.Text = reader["TimeIn"].ToString();
                                txtTimeOut.Text = reader["TimeOut"].ToString();
                                txtProcedure.Text = reader["Surgery"].ToString();
                                txtPrescription.Text = reader["Prescription"].ToString();
                                txtDosage.Text = reader["Dosage"].ToString();
                                txtFrequency.Text = reader["Frequency"].ToString();
                                txtNotes.Text = reader["Notes"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No details found for the selected patient.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading patient details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnView_Click_1(object sender, EventArgs e)
        {
            try
            {
                string patientFullName = cbPatientFullName.Text;
                string doctorFullName = txtDoctorFullName.Text;
                string specialization = txtSpecialization.Text;
                string diagnosis = txtDiagnosis.Text;
                string date = dtpDate.Value.ToString("MM/dd/yyyy");
                string timeIn = txtTimeIn.Text;
                string timeOut = txtTimeOut.Text;
                string procedure = txtProcedure.Text;
                string prescription = txtPrescription.Text;
                string dosage = txtDosage.Text;
                string frequency = txtFrequency.Text;
                string notes = txtNotes.Text;

                // Format current date to append to filename (yyyy-MM-dd)
                string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

                // Use the patient's full name and current date to create a unique filename
                string fileName = $"{patientFullName.Replace(" ", "_")}_{currentDate}_MedicalHistory.pdf";

                // Define the file path to save the PDF in 'C:\\Users\\Public\\Documents'
                string filePath = Path.Combine(@"C:\\Users\\Public\\Documents", fileName);

                // Check if the file already exists
                if (File.Exists(filePath))
                {
                    MessageBox.Show($"Medical record already exists for {patientFullName} on {date}. Redirecting to the existing record.", "Record Exists", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = filePath,
                        UseShellExecute = true
                    });
                    return;
                }

                // Generate a random 10-digit medical history number
                Random rand = new Random();
                long medicalHistoryNumber = rand.Next(1000000000, 2000000000);
                string medicalHistoryStr = medicalHistoryNumber.ToString();

                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    Document document = new Document(PageSize.A4, 50f, 50f, 50f, 50f);
                    PdfWriter writer = PdfWriter.GetInstance(document, fs);
                    document.Open();

                    // Add a placeholder for a logo or photo
                    Paragraph logoPlaceholder = new Paragraph("St.Benedict", FontFactory.GetFont(FontFactory.HELVETICA, 12));
                    logoPlaceholder.Alignment = Element.ALIGN_RIGHT;
                    logoPlaceholder.SpacingAfter = 20f;
                    document.Add(logoPlaceholder);

                    // Title with medical history number
                    Paragraph header = new Paragraph($"Confidential Medical History Form\nRecord No: {medicalHistoryStr}", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18));
                    header.Alignment = Element.ALIGN_CENTER;
                    header.SpacingAfter = 20f;
                    document.Add(header);

                    // Add fields with placeholders
                    document.Add(new Paragraph($"Patient's Full Name: {patientFullName}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                    document.Add(new Paragraph($"Doctor's Full Name: {doctorFullName}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                    document.Add(new Paragraph($"Specialization: {specialization}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                    document.Add(new Paragraph($"Diagnosis: {diagnosis}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                    document.Add(new Paragraph($"Date: {date}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                    document.Add(new Paragraph($"Time In: {timeIn}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                    document.Add(new Paragraph($"Time Out: {timeOut}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                    document.Add(new Paragraph($"Surgery Procedure: {procedure}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                    document.Add(new Paragraph($"Prescription/Medication: {prescription}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                    document.Add(new Paragraph($"Dosage: {dosage}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                    document.Add(new Paragraph($"Frequency: {frequency}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                    document.Add(new Paragraph($"Notes: {notes}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));

                    document.Close();
                    writer.Close();
                }

                MessageBox.Show($"PDF successfully saved to {filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Open the generated PDF file
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = filePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }







        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Delete button functionality not yet implemented.");
        }
    }
}
