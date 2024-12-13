using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using iTextSharp.text.pdf.qrcode;
using System.Drawing;
using QRCoder;
using System.Text.RegularExpressions;


namespace StBenedict
{
    public partial class Billing : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Kuraisura\\Downloads\\StBenedict7.0\\StBenedict6.0\\StBenedict4.0\\StBenedict4.0\\StBenedict\\StBenedict\\StBenedict\\StBenedict.mdf;Integrated Security=True";

        private List<PatientRecord> patientRecords = new List<PatientRecord>();

        public Billing()
        {
            InitializeComponent();
            LoadPatientData();
            DisableEditing();
        }

        private void DisableEditing()
        {
            // Disable interaction for controls except for dtpDate, txtTimeIn, and txtTimeOut
            txtProcedure.Enabled = false;
            dtpDate.Enabled = false;
            txtDiagnosis.Enabled = false;
            txtPreCost.Enabled = false;
            txtProCost.Enabled = false;
            txtToolCost.Enabled = false;
            txtPrescription.Enabled = false;
            txtChange.Enabled = false;
            txtTotal.Enabled = false;
            txtTools.Enabled = false;
        }

        private void LoadPatientData()
        {
            try
            {
                // Connect to the database and retrieve patient data
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT PatientFullName, Diagnosis, AppointmentDate, Prescription, Surgery FROM MedicalHistory";
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    // Clear the combo box and the patient records list
                    cbPatientFullName.Items.Clear();
                    patientRecords.Clear();

                    // Read data from the database
                    while (reader.Read())
                    {
                        string fullName = reader["PatientFullName"].ToString();
                        cbPatientFullName.Items.Add(fullName);

                        // Store the data for later retrieval
                        patientRecords.Add(new PatientRecord
                        {
                            FullName = fullName,
                            Diagnosis = reader["Diagnosis"].ToString(),
                            AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]),
                            Prescription = reader["Prescription"].ToString(),
                            Procedure = reader["Surgery"].ToString()
                        });
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading patient data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GeneratePrescriptionCost()
        {
            try
            {
                // Get the prescription text
                string prescription = txtPrescription.Text;

                // Check if the prescription exists in the MedicationPrices dictionary
                if (MedicationPrices.TryGetValue(prescription, out var cost))
                {
                    // Set the cost in txtPreCost
                    txtPreCost.Text = cost.ToString("N2"); // Format as a plain number
                }
                else
                {
                    // Handle case where prescription is not found
                    txtPreCost.Text = "Cost Not Found";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating prescription cost: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void GenerateProcedureCost()
        {
            try
            {
                // Get the procedure text
                string procedure = txtProcedure.Text;

                // Check if the procedure exists in the Costs dictionary
                if (Costs.TryGetValue(procedure, out var cost))
                {
                    // Set the cost in txtProCost
                    txtProCost.Text = cost.ToString("N2"); // Format as a plain number
                }
                else
                {
                    // Handle case where procedure is not found
                    txtProCost.Text = "Cost Not Found";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating procedure cost: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateTotal()
        {
            try
            {
                // Parse costs from the textboxes
                decimal preCost = decimal.TryParse(txtPreCost.Text, out var preResult) ? preResult : 0;
                decimal proCost = decimal.TryParse(txtProCost.Text, out var proResult) ? proResult : 0;
                decimal toolCost = decimal.TryParse(txtToolCost.Text, out var toolResult) ? toolResult : 0;

                // Calculate the total
                decimal total = preCost + proCost + toolCost;

                // Display the total in txtTotal
                txtTotal.Text = total.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating total: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void GenerateToolCost()
        {
            try
            {
                // Get the diagnosis text
                string diagnosis = txtDiagnosis.Text;

                // Check if the diagnosis exists in the DiseaseTreatments dictionary
                if (medicalTreatmentCosts.DiseaseTreatments.TryGetValue(diagnosis, out var treatments))
                {
                    // Calculate the total cost of treatments/tools
                    decimal totalCost = treatments.Sum(treatment => treatment.Item2);

                    // Display the total cost in txtToolCost
                    txtToolCost.Text = totalCost.ToString("N2"); // Format as a plain number
                }
                else
                {
                    // Handle case where no tools/treatments are found for the diagnosis
                    txtToolCost.Text = "Cost Not Found";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating tool cost: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public class PatientRecord
        {
            public string FullName { get; set; }
            public string Diagnosis { get; set; }
            public DateTime AppointmentDate { get; set; }
            public string Prescription { get; set; }
            public string Procedure { get; set; }
        }

        private MedicalTreatmentCosts medicalTreatmentCosts = new MedicalTreatmentCosts();


        private void LoadTreatments(string diagnosis)
        {
            // Check if the diagnosis exists in the dictionary
            if (medicalTreatmentCosts.DiseaseTreatments.TryGetValue(diagnosis, out var treatments))
            {
                // Get the list of treatment names
                string treatmentsString = string.Join(" , ", treatments.Select(t => t.Item1));

                // Display in the txtTools textbox
                txtTools.Text = $"{treatmentsString}";
            }
            else
            {
                // Default message if no treatments are found
                txtTools.Text = "Surgery Tools/Treatments: No treatments available for this diagnosis.";
            }
        }

        private void CalculateChange()
        {
            try
            {
                // Parse costs from the text boxes
                decimal preCost = decimal.TryParse(txtPreCost.Text, out var preCostValue) ? preCostValue : 0;
                decimal proCost = decimal.TryParse(txtProCost.Text, out var proCostValue) ? proCostValue : 0;
                decimal toolCost = decimal.TryParse(txtToolCost.Text, out var toolCostValue) ? toolCostValue : 0;

                // Calculate the total cost
                decimal totalCost = preCost + proCost + toolCost;

                // Display the total cost in txtTotal (if it's not already user-entered)
                txtTotal.Text = totalCost.ToString("N2");

                // Parse the amount entered by the user
                if (decimal.TryParse(txtAmount.Text, out var amountPaid))
                {
                    if (amountPaid < totalCost)
                    {
                        // Show a warning if the amount paid is less than the total cost
                        txtChange.Text = "Not enough money, Please try again next life";
                    }
                    else
                    {
                        // Calculate and display the change
                        decimal change = amountPaid - totalCost;
                        txtChange.Text = change.ToString("C2");
                    }
                }
                else
                {
                    // Handle invalid input in txtAmount
                    MessageBox.Show("Please enter a valid amount.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAmount.Text = string.Empty;
                    txtChange.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating change: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            CalculateChange();
            txtAmount.TextChanged += txtAmount_TextChanged;

        }



        public class MedicalTreatmentCosts
        {
            public Dictionary<string, List<Tuple<string, decimal>>> DiseaseTreatments { get; } =
        new Dictionary<string, List<Tuple<string, decimal>>>
    {
        // General Medicine
        { "Hypertension", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Blood Pressure Monitoring", 100),
            new Tuple<string, decimal>("Antihypertensive Medications", 200),
            new Tuple<string, decimal>("Consultation Fee", 150)
        }},
        { "Diabetes Mellitus", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Blood Glucose Test", 100),
            new Tuple<string, decimal>("Insulin Therapy", 500),
            new Tuple<string, decimal>("Consultation Fee", 150)
        }},
        { "Hyperlipidemia", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Lipid Profile Test", 200),
            new Tuple<string, decimal>("Statins", 300),
            new Tuple<string, decimal>("Consultation Fee", 150)
        }},
        { "Asthma", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Peak Flow Meter", 50),
            new Tuple<string, decimal>("Inhalers", 150),
            new Tuple<string, decimal>("Consultation Fee", 150)
        }},
        { "COPD", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Spirometry Test", 200),
            new Tuple<string, decimal>("Bronchodilators", 300),
            new Tuple<string, decimal>("Consultation Fee", 150)
        }},
        { "GERD", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Endoscopy", 800),
            new Tuple<string, decimal>("Proton Pump Inhibitors", 200),
            new Tuple<string, decimal>("Consultation Fee", 150)
        }},
        { "Upper Respiratory Infections", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Consultation Fee", 150),
            new Tuple<string, decimal>("Antibiotics", 200)
        }},
        { "Anemia", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("CBC Test", 100),
            new Tuple<string, decimal>("Iron Supplements", 50),
            new Tuple<string, decimal>("Consultation Fee", 150)
        }},
        { "Thyroid Disorders", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("TSH Test", 200),
            new Tuple<string, decimal>("Thyroid Hormone Medications", 300),
            new Tuple<string, decimal>("Consultation Fee", 150)
        }},
        { "Kidney Disease", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Renal Function Test", 200),
            new Tuple<string, decimal>("Dialysis", 1000),
            new Tuple<string, decimal>("Consultation Fee", 150)
        }},
        { "Obesity", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("BMI Measurement", 50),
            new Tuple<string, decimal>("Weight Loss Program", 500),
            new Tuple<string, decimal>("Consultation Fee", 150)
        }},
        { "Allergic Rhinitis", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Allergy Testing", 300),
            new Tuple<string, decimal>("Antihistamines", 100),
            new Tuple<string, decimal>("Consultation Fee", 150)
        }},
        { "Sleep Apnea", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Sleep Study", 1000),
            new Tuple<string, decimal>("CPAP Machine", 1200),
            new Tuple<string, decimal>("Consultation Fee", 150)
        }},
        { "Fatigue Syndromes", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Blood Tests", 200),
            new Tuple<string, decimal>("Consultation Fee", 150)
        }},
        { "Acid Reflux", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Endoscopy", 800),
            new Tuple<string, decimal>("Antacids", 100),
            new Tuple<string, decimal>("Consultation Fee", 150)
        }},
        { "UTIs", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Urine Test", 150),
            new Tuple<string, decimal>("Antibiotics", 100),
            new Tuple<string, decimal>("Consultation Fee", 150)
        }},
        { "Mental Health Conditions", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Psychiatric Evaluation", 300),
            new Tuple<string, decimal>("Therapy Sessions", 200),
            new Tuple<string, decimal>("Consultation Fee", 150)
        }},
        { "Infections", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Blood Tests", 200),
            new Tuple<string, decimal>("Antibiotics", 200),
            new Tuple<string, decimal>("Consultation Fee", 150)
        }},
        { "Chronic Pain Syndromes", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("MRI", 1000),
            new Tuple<string, decimal>("Pain Medications", 300),
            new Tuple<string, decimal>("Consultation Fee", 150)
        }},

        // Pediatrics
        { "Bronchiolitis", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Pulse Oximeter", 100),
            new Tuple<string, decimal>("Nebulizer Therapy", 200),
            new Tuple<string, decimal>("Consultation Fee", 150)
        }},
        { "Pneumonia", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Chest X-ray", 300),
            new Tuple<string, decimal>("Antibiotics", 200),
            new Tuple<string, decimal>("Consultation Fee", 150)
        }},
        { "Croup", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Corticosteroid Treatment", 100),
            new Tuple<string, decimal>("Consultation Fee", 150)
        }},
        { "Gastroenteritis", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Oral Rehydration Solution", 50),
            new Tuple<string, decimal>("Consultation Fee", 150)
        }},
        { "Ear Infections", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Antibiotics", 100),
            new Tuple<string, decimal>("Consultation Fee", 150)
        }},
        { "RSV Infection", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("PCR Test", 200),
            new Tuple<string, decimal>("Consultation Fee", 150)
        }},
        { "Diarrhea and Vomiting", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Oral Rehydration Solution", 50),
            new Tuple<string, decimal>("Consultation Fee", 150)
        }},
        { "Fever and Sepsis", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Blood Cultures", 300),
            new Tuple<string, decimal>("Antibiotics", 200),
            new Tuple<string, decimal>("Consultation Fee", 150)
        }},
        { "ADHD", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Psychiatric Evaluation", 300),
            new Tuple<string, decimal>("Stimulant Medications", 200),
            new Tuple<string, decimal>("Consultation Fee", 150)
        }},
        { "ASD", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Psychiatric Evaluation", 300),
            new Tuple<string, decimal>("Therapy Sessions", 200),
            new Tuple<string, decimal>("Consultation Fee", 150)
        }},
        { "Eczema", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Topical Steroids", 100),
            new Tuple<string, decimal>("Consultation Fee", 150),
            new Tuple<string, decimal>("Skin Care Products", 150)
        }},
        { "Childhood Obesity", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("BMI Measurement", 50),
            new Tuple<string, decimal>("Consultation Fee", 150),
            new Tuple<string, decimal>("Weight Management Program", 500)
        }},
        { "Congenital heart defects", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Echocardiogram", 800),
            new Tuple<string, decimal>("Heart Surgery", 10000),
            new Tuple<string, decimal>("Consultation Fee", 150)
        }},

        // Orthopedics
        { "Fractures", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("X-ray", 300),
            new Tuple<string, decimal>("Casting", 400),
            new Tuple<string, decimal>("Surgical Repair", 5000),
            new Tuple<string, decimal>("Consultation Fee", 200),
            new Tuple<string, decimal>("Hospital Stay", 1000)
        }},
        { "Osteoarthritis", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("X-ray", 300),
            new Tuple<string, decimal>("Pain Medications", 200),
            new Tuple<string, decimal>("Physical Therapy", 250),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Rheumatoid Arthritis", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Blood Tests", 200),
            new Tuple<string, decimal>("DMARDs", 500),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Spondylosis", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("X-ray", 300),
            new Tuple<string, decimal>("Pain Medications", 200),
            new Tuple<string, decimal>("Physical Therapy", 250),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Sciatica", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("MRI", 500),
            new Tuple<string, decimal>("Pain Medications", 200),
            new Tuple<string, decimal>("Physical Therapy", 250),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Carpal Tunnel Syndrome", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("EMG", 400),
            new Tuple<string, decimal>("Wrist Splint", 50),
            new Tuple<string, decimal>("Surgical Intervention", 3000),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Sprains and Strains", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("X-ray", 300),
            new Tuple<string, decimal>("Splinting", 100),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Bursitis", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("X-ray", 300),
            new Tuple<string, decimal>("Anti-inflammatory Medications", 100),
            new Tuple<string, decimal>("Physical Therapy", 250),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Tendonitis", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("MRI", 500),
            new Tuple<string, decimal>("Anti-inflammatory Medications", 100),
            new Tuple<string, decimal>("Physical Therapy", 250),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Herniated Discs", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("MRI", 500),
            new Tuple<string, decimal>("Pain Medications", 200),
            new Tuple<string, decimal>("Surgical Intervention", 5000),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Osteoporosis", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("DEXA Scan", 400),
            new Tuple<string, decimal>("Bisphosphonates", 300),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},

        // Cardiology
        { "Coronary Artery Disease", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("ECG", 200),
            new Tuple<string, decimal>("Stress Test", 400),
            new Tuple<string, decimal>("Coronary Angiography", 2500),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Heart Attack", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("ECG", 200),
            new Tuple<string, decimal>("Cardiac Enzyme Tests", 300),
            new Tuple<string, decimal>("Angioplasty", 5000),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Heart Failure", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Echocardiogram", 800),
            new Tuple<string, decimal>("Diuretics", 100),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Arrhythmias", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("ECG", 200),
            new Tuple<string, decimal>("Holter Monitor", 300),
            new Tuple<string, decimal>("Pacemaker", 5000),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Valvular Heart Diseases", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Echocardiogram", 800),
            new Tuple<string, decimal>("Valve Replacement Surgery", 10000),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Cardiomyopathy", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Echocardiogram", 800),
            new Tuple<string, decimal>("Heart Failure Medications", 300),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},

        // Dermatology
        { "Acne", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Topical Treatments", 100),
            new Tuple<string, decimal>("Oral Antibiotics", 200),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Psoriasis", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Topical Steroids", 100),
            new Tuple<string, decimal>("Biologic Medications", 1500),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Rosacea", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Topical Medications", 100),
            new Tuple<string, decimal>("Oral Medications", 200),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Melanoma", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Skin Biopsy", 500),
            new Tuple<string, decimal>("Surgical Removal", 5000),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "BCC", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Skin Biopsy", 500),
            new Tuple<string, decimal>("Cryotherapy", 150),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "SCC", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Skin Biopsy", 500),
            new Tuple<string, decimal>("Surgical Removal", 3000),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Hives", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Antihistamines", 100),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Contact Dermatitis", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Topical Steroids", 100),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        
        // Ophthalmology
        { "Cataracts", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Eye Exam", 150),
            new Tuple<string, decimal>("Cataract Surgery", 10000),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Glaucoma", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Eye Exam", 150),
            new Tuple<string, decimal>("Tonometry", 200),
            new Tuple<string, decimal>("Medications", 300),
            new Tuple<string, decimal>("Laser Surgery", 5000),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Macular Degeneration", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Eye Exam", 150),
            new Tuple<string, decimal>("OCT Scan", 400),
            new Tuple<string, decimal>("Anti-VEGF Injections", 1000),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Diabetic Retinopathy", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Eye Exam", 150),
            new Tuple<string, decimal>("Fundus Photography", 500),
            new Tuple<string, decimal>("Laser Surgery", 5000),
            new Tuple<string, decimal>("Anti-VEGF Injections", 1000),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Retinal Detachment", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Eye Exam", 150),
            new Tuple<string, decimal>("Surgical Repair", 10000),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Conjunctivitis", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Eye Exam", 150),
            new Tuple<string, decimal>("Antibiotic Eye Drops", 100),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Dry Eye Syndrome", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Eye Exam", 150),
            new Tuple<string, decimal>("Artificial Tears", 50),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Astigmatism", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Eye Exam", 150),
            new Tuple<string, decimal>("Eyeglasses", 300),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Myopia", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Eye Exam", 150),
            new Tuple<string, decimal>("Eyeglasses", 300),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Hyperopia", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Eye Exam", 150),
            new Tuple<string, decimal>("Eyeglasses", 300),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Presbyopia", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Eye Exam", 150),
            new Tuple<string, decimal>("Eyeglasses", 300),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Strabismus", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Eye Exam", 150),
            new Tuple<string, decimal>("Surgical Correction", 5000),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Amblyopia", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Eye Exam", 150),
            new Tuple<string, decimal>("Patch Therapy", 100),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Eye Injuries", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Eye Exam", 150),
            new Tuple<string, decimal>("Surgical Intervention", 5000),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Keratoconus", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Eye Exam", 150),
            new Tuple<string, decimal>("Corneal Crosslinking", 2000),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Uveitis", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Eye Exam", 150),
            new Tuple<string, decimal>("Steroid Eye Drops", 100),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Pterygium", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Eye Exam", 150),
            new Tuple<string, decimal>("Surgical Removal", 3000),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Blepharitis", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Eye Exam", 150),
            new Tuple<string, decimal>("Antibiotic Eye Ointment", 100),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Eye Infections", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Eye Exam", 150),
            new Tuple<string, decimal>("Antibiotic Eye Drops", 100),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Retinal Vascular Occlusion", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Eye Exam", 150),
            new Tuple<string, decimal>("Laser Therapy", 5000),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Color Blindness", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Eye Exam", 150),
            new Tuple<string, decimal>("Color Vision Test", 200),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Corneal Ulcers", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Eye Exam", 150),
            new Tuple<string, decimal>("Antibiotic Eye Drops", 100),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Optic Neuritis", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Eye Exam", 150),
            new Tuple<string, decimal>("Steroid Medications", 100),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }},
        { "Eye Tumors", new List<Tuple<string, decimal>> {
            new Tuple<string, decimal>("Eye Exam", 150),
            new Tuple<string, decimal>("Biopsy", 500),
            new Tuple<string, decimal>("Consultation Fee", 200)
        }}
    };
        }

        private Dictionary<string, decimal> MedicationPrices = new Dictionary<string, decimal>
        {
            // General Medicine
            { "Amlodipine 5mg daily", 10.00m },
            { "Lisinopril 10mg daily", 12.00m },
            { "Metformin 500mg twice daily", 15.00m },
            { "Insulin as per sliding scale", 50.00m },
            { "Atorvastatin 20mg daily", 25.00m },
            { "Salbutamol inhaler as needed", 8.00m },
            { "Budesonide 200mcg daily", 30.00m },
            { "Tiotropium inhaler once daily", 35.00m },
            { "Omeprazole 20mg daily", 12.00m },
            { "Antacids as needed", 5.00m },
            { "Amoxicillin 500mg three times daily", 20.00m },
            { "Paracetamol for fever", 5.00m },
            { "Ferrous sulfate 325mg daily", 8.00m },
            { "Vitamin B12 supplements", 15.00m },
            { "Levothyroxine", 10.00m },
            { "Losartan", 14.00m },
            { "Low protein diet", 30.00m },
            { "Lifestyle modifications", 0.00m },
            { "Orlistat 120mg as directed", 40.00m },
            { "Cetirizine 10mg daily", 5.00m },
            { "Nasal corticosteroids", 20.00m },
            { "CPAP therapy", 300.00m },
            { "Weight management", 0.00m },
            { "Multivitamins", 10.00m },
            { "Regular exercise", 0.00m },
            { "Ranitidine", 15.00m },
            { "Nitrofurantoin", 18.00m },
            { "Hydration therapy", 0.00m },
            { "Sertraline", 25.00m },
            { "Psychotherapy sessions", 100.00m },
            { "Amoxicillin/Clavulanate 875mg/125mg twice daily", 45.00m },
            { "Gabapentin 300mg daily", 20.00m },
            { "Physiotherapy", 60.00m },

            // Pediatrics
            { "Supportive care", 0.00m },
            { "Saline nasal drops", 6.00m },
            { "Amoxicillin", 18.00m },
            { "Dexamethasone", 10.00m },
            { "Humidified air", 0.00m },
            { "Oral rehydration solution (ORS)", 10.00m },
            { "Zinc supplements", 8.00m },
            { "Analgesics as needed", 5.00m },
            { "Oxygen therapy if needed", 50.00m },
            { "Probiotics", 15.00m },
            { "IV antibiotics", 100.00m },
            { "Methylphenidate 5mg daily", 30.00m },
            { "Behavioral therapy", 80.00m },
            { "Speech therapy", 90.00m },
            { "Structured learning programs", 0.00m },
            { "Emollients", 8.00m },
            { "Topical corticosteroids", 12.00m },
            { "Dietary counseling", 50.00m },
            { "Physical activity plans", 0.00m },
            { "Surgical correction", 5000.00m },
            { "Cardiology follow-ups", 100.00m },

            // Orthopedics
            { "Immobilization with a cast", 100.00m },
            { "Pain management", 25.00m },
            { "NSAIDs", 10.00m },
            { "Methotrexate 15mg weekly", 40.00m },
            { "Folic acid supplements", 5.00m },
            { "Physical therapy", 60.00m },
            { "Wrist splints", 20.00m },
            { "Steroid injections", 75.00m },
            { "RICE method (Rest, Ice, Compression, Elevation)", 0.00m },
            { "Topical NSAIDs", 15.00m },
            { "Calcium and Vitamin D supplements", 20.00m },
            { "Bisphosphonates", 35.00m },

            // Cardiology
            { "Aspirin 81mg daily", 8.00m },
            { "Nitroglycerin as needed", 10.00m },
            { "Dual antiplatelet therapy", 50.00m },
            { "Furosemide 40mg daily", 15.00m },
            { "ACE inhibitors", 25.00m },
            { "Amiodarone 200mg daily", 35.00m },
            { "Electrolyte monitoring", 20.00m },
            { "Surgical repair", 10000.00m },
            { "Prophylactic antibiotics", 30.00m },
            { "Beta-blockers", 15.00m },

            // Dermatology
            { "Benzoyl peroxide gel", 10.00m },
            { "Oral doxycycline", 20.00m },
            { "Phototherapy", 200.00m },
            { "Topical metronidazole", 12.00m },
            { "Avoid triggers", 0.00m },
            { "Surgical excision", 3000.00m },
            { "Topical imiquimod", 50.00m },
            { "Mohs surgery", 5000.00m },
            { "Antihistamines", 8.00m },

            // Ophthalmology
            { "Latanoprost 0.005% eye drops", 25.00m },
            { "Anti-VEGF injections (e.g., Ranibizumab)", 1500.00m },
            { "AREDS2 supplements", 35.00m },
            { "Artificial tears (e.g., Carboxymethylcellulose)", 10.00m },
            { "Cyclosporine eye drops", 40.00m },
            { "Moxifloxacin 0.5% eye drops", 20.00m },
            { "Prednisolone acetate 1% eye drops", 15.00m },
            { "Erythromycin 0.5% ointment", 12.00m },
            { "Ciprofloxacin 0.3% eye drops", 18.00m },
            { "Intravenous methylprednisolone", 200.00m }
        };



        private Dictionary<string, decimal> Costs = new Dictionary<string, decimal>
{
    // General Medicine
    { "Renal artery stenting", 15000.00m }, // Hypertension
    { "Pancreas transplantation", 120000.00m }, // Diabetes Mellitus
    { "Liposuction (for severe lipid deposits)", 5000.00m }, // Hyperlipidemia
    { "Bronchial thermoplasty", 20000.00m }, // Asthma
    { "Lung volume reduction surgery (LVRS)", 80000.00m }, // COPD
    { "Endoscopic sinus surgery", 15000.00m }, // Upper Respiratory Infections
    { "Splenectomy", 25000.00m }, // Anemia
    { "Thyroidectomy", 18000.00m }, // Thyroid Disorders
    { "Kidney transplant", 300000.00m }, // Kidney Disease
    { "Bariatric surgery", 25000.00m }, // Obesity
    { "Uvulopalatopharyngoplasty (UPPP)", 20000.00m }, // Sleep Apnea
    { "Fundoplication", 30000.00m }, // Acid Reflux
    { "Ureteral reimplantation", 35000.00m }, // UTIs
    { "Deep brain stimulation", 100000.00m }, // Mental Health Conditions
    { "Abscess drainage", 10000.00m }, // Infections
    { "Spinal cord stimulation", 75000.00m }, // Chronic Pain Syndromes

    // Pediatrics
    { "Bronchoscopy", 12000.00m }, // Bronchiolitis
    { "Thoracentesis or decortication", 20000.00m }, // Pneumonia
    { "Tracheostomy", 15000.00m }, // Croup
    { "Tympanostomy", 8000.00m }, // Ear Infections
    { "Corrective heart surgery", 150000.00m }, // Congenital Heart Defects

    // Orthopedics
    { "Open reduction and internal fixation (ORIF)", 20000.00m }, // Fractures
    { "Total joint replacement", 50000.00m }, // Osteoarthritis
    { "Synovectomy or joint replacement", 40000.00m }, // Rheumatoid Arthritis
    { "Spinal decompression surgery", 70000.00m }, // Spondylosis
    { "Microdiscectomy", 30000.00m }, // Sciatica
    { "Carpal tunnel release surgery", 10000.00m }, // Carpal Tunnel Syndrome
    { "Bursectomy", 15000.00m }, // Bursitis
    { "Tendon repair", 20000.00m }, // Tendonitis
    { "Laminectomy or discectomy", 40000.00m }, // Herniated Discs
    { "Vertebroplasty or kyphoplasty", 25000.00m }, // Osteoporosis

    // Cardiology
    { "Coronary artery bypass grafting (CABG)", 120000.00m }, // Coronary Artery Disease
    { "Emergency angioplasty or CABG", 100000.00m }, // Heart Attack
    { "LVAD implantation or heart transplant", 300000.00m }, // Heart Failure
    { "Pacemaker or ICD implantation", 60000.00m }, // Arrhythmias
    { "Valve replacement or repair", 150000.00m }, // Valvular Heart Diseases
    { "Heart transplant", 300000.00m }, // Cardiomyopathy

    // Dermatology
    { "Laser resurfacing or surgical excision of cysts", 5000.00m }, // Acne
    { "Laser therapy", 7000.00m }, // Rosacea
    { "Wide local excision or sentinel lymph node biopsy", 25000.00m }, // Melanoma
    { "Mohs surgery", 10000.00m }, // BCC
    { "Excision or Mohs surgery", 12000.00m }, // SCC

    // Ophthalmology
    { "Cataract surgery", 15000.00m }, // Cataracts
    { "Trabeculectomy or shunt implantation", 30000.00m }, // Glaucoma
    { "Laser photocoagulation", 20000.00m }, // Macular Degeneration
    { "Scleral buckle or vitrectomy", 40000.00m }, // Retinal Detachment
    { "Punctal occlusion", 5000.00m }, // Dry Eye Syndrome
    { "LASIK surgery", 8000.00m }, // Astigmatism
    { "Presbyopia-correcting lens implants", 10000.00m }, // Presbyopia
    { "Strabismus surgery", 15000.00m }, // Strabismus
    { "Corneal repair or enucleation", 20000.00m }, // Eye Injuries
    { "Corneal transplant", 30000.00m }, // Keratoconus
    { "Pterygium excision", 7000.00m }, // Pterygium
    { "Vitrectomy", 30000.00m }, // Retinal Vascular Occlusion
    { "Enucleation or orbital exenteration", 50000.00m } // Eye Tumors
};



        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                string directoryPath = @"C:\Users\Public\Documents";

                // Get user input for validation
                string patientName = cbPatientFullName.Text.Trim();
                if (string.IsNullOrWhiteSpace(patientName))
                {
                    MessageBox.Show("Please select the patient's name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Sanitize patient's name to match saved file format
                string sanitizedPatientName = Regex.Replace(patientName, @"\W+", "_").ToLower();

                // Search for PDF files matching the pattern
                string[] receiptFiles = Directory.GetFiles(directoryPath, $"Receipt_{sanitizedPatientName}_*.pdf");

                if (receiptFiles.Length > 0)
                {
                    // Open the first matching file (or handle multiple matches as needed)
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = receiptFiles[0],
                        UseShellExecute = true
                    });
                }
                else
                {
                    MessageBox.Show($"No receipt found for patient: {patientName}", "Receipt Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while trying to view the receipt: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure Total is calculated and valid
                if (!decimal.TryParse(txtTotal.Text, out var totalAmount) || totalAmount <= 0)
                {
                    MessageBox.Show("Invalid total amount. Please ensure all costs are calculated properly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate that an amount is entered
                if (string.IsNullOrWhiteSpace(txtAmount.Text))
                {
                    MessageBox.Show("Please enter the amount given by the patient.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Parse the entered amount
                if (!decimal.TryParse(txtAmount.Text, out var amountGiven) || amountGiven <= 0)
                {
                    MessageBox.Show("Invalid amount entered. Please enter a valid numeric value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if the amount given is less than the total
                if (amountGiven < totalAmount)
                {
                    MessageBox.Show("Not enough money provided. Please try again.", "Insufficient Payment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Calculate the change
                decimal change = amountGiven - totalAmount;

                // Update the txtChange field
                txtChange.Text = change.ToString("N2");

                // Save payment to the database
                SavePaymentToDatabase(amountGiven, totalAmount, change);

                // Generate PDF receipt
                string receiptFileName = GeneratePDFReceipt(totalAmount, amountGiven, change);

                // Confirmation of successful payment
                MessageBox.Show($"Payment successful!\nReceipt saved at: {receiptFileName}",
                    "Payment Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Optional: Clear or reset fields if needed after payment
                ResetBillingForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while processing the payment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GeneratePDFReceipt(decimal totalAmount, decimal amountGiven, decimal change)
        {
            string directoryPath = @"C:\\Users\\Public\\Documents";

            // Generate receipt number
            string receiptNumber = new Random().Next(1000000, 9999999).ToString();

            // File name includes the patient's name and receipt number
            string sanitizedPatientName = cbPatientFullName.Text.Replace(" ", "_"); // Replace spaces for file safety
            string fileName = Path.Combine(directoryPath, $"Receipt_{sanitizedPatientName}_{receiptNumber}.pdf");

            // Ensure the directory exists
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Create the PDF
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            using (Document doc = new Document(PageSize.A4, 10f, 10f, 20f, 20f))
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();

                // Add hospital details
                Paragraph header = new Paragraph("Bill Receipt", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16));
                header.Alignment = Element.ALIGN_CENTER;
                doc.Add(header);

                doc.Add(new Paragraph(" ")); // Blank line

                doc.Add(new Paragraph("Name of Medical Institution: St. Benedict Hospital", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                doc.Add(new Paragraph($"Doctor's Name: {lblDoctor.Text}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));

                doc.Add(new Paragraph(" ")); // Blank line

                // Patient information
                doc.Add(new Paragraph("Patient Information:", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));
                doc.Add(new Paragraph($"Patient's Name: {cbPatientFullName.Text}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));

                // Receipt details
                Paragraph receiptInfo = new Paragraph();
                receiptInfo.Alignment = Element.ALIGN_RIGHT;
                receiptInfo.Add(new Chunk($"Receipt Number: {receiptNumber}\n", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                receiptInfo.Add(new Chunk($"Date: {DateTime.Now:MM/dd/yyyy}\n", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                doc.Add(receiptInfo);

                doc.Add(new Paragraph(" ")); // Blank line

                // Table for billing details
                PdfPTable table = new PdfPTable(3) { WidthPercentage = 100 };
                table.AddCell("Description");
                table.AddCell("Details");
                table.AddCell("Cost");

                table.AddCell("Prescription/Medication");
                table.AddCell(txtPrescription.Text);
                table.AddCell(txtPreCost.Text);

                table.AddCell("Surgery Procedure");
                table.AddCell(txtProcedure.Text);
                table.AddCell(txtProCost.Text);

                table.AddCell("Surgery Tools/Treatments");
                table.AddCell(txtTools.Text);
                table.AddCell(txtToolCost.Text);

                table.AddCell("Method of Payment");
                table.AddCell(cbMethod.Text);
                table.AddCell("-");

                table.AddCell("Total");
                table.AddCell("-");
                table.AddCell(txtTotal.Text);

                table.AddCell("Amount");
                table.AddCell("-");
                table.AddCell(txtAmount.Text);

                table.AddCell("Change");
                table.AddCell("-");
                table.AddCell(txtChange.Text);

                doc.Add(table);

                doc.Add(new Paragraph(" ")); // Blank line

                // QR Code
                string qrContent = $"Receipt Number: {receiptNumber}\nThank you for choosing St. Benedict! Bawi next life";
                iTextSharp.text.Image qrCode = GenerateQRCode(qrContent);
                if (qrCode != null)
                {
                    qrCode.ScaleAbsolute(64f, 64f);
                    qrCode.Alignment = Element.ALIGN_CENTER;
                    doc.Add(qrCode);
                }

                doc.Close();
            }

            return fileName;
        }


        private iTextSharp.text.Image GenerateQRCode(string qrContent)
        {
            try
            {
                using (QRCoder.QRCodeGenerator qrGenerator = new QRCoder.QRCodeGenerator())
                {
                    QRCoder.QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrContent, QRCoder.QRCodeGenerator.ECCLevel.Q);
                    using (QRCoder.QRCode qrCode = new QRCoder.QRCode(qrCodeData))
                    {
                        using (Bitmap bitmap = qrCode.GetGraphic(20))
                        {
                            using (MemoryStream stream = new MemoryStream())
                            {
                                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png); // Save as PNG
                                byte[] imageBytes = stream.ToArray(); // Convert to byte array
                                return iTextSharp.text.Image.GetInstance(imageBytes); // Convert to iTextSharp image
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while generating the QR Code: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }






        private void SavePaymentToDatabase(decimal amountGiven, decimal totalCost, decimal changeAmount)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                INSERT INTO Receipt 
                (DoctorFullName, Specialization, PatientFullName, Diagnosis, AppointmentDate, 
                Prescription, SurgeryProcedure, SurgeryTools, Amount, MethodOfPayment, 
                TotalCost, ChangeAmount, PreTotalCost, ProTotalCost, ToolTotalCost)
                VALUES 
                (@DoctorFullName, @Specialization, @PatientFullName, @Diagnosis, @AppointmentDate, 
                @Prescription, @SurgeryProcedure, @SurgeryTools, @Amount, @MethodOfPayment, 
                @TotalCost, @ChangeAmount, @PreTotalCost, @ProTotalCost, @ToolTotalCost)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters
                        command.Parameters.AddWithValue("@DoctorFullName", lblDoctor.Text);
                        command.Parameters.AddWithValue("@Specialization", lblRole.Text); // Assuming lblRole holds the specialization
                        command.Parameters.AddWithValue("@PatientFullName", cbPatientFullName.Text);
                        command.Parameters.AddWithValue("@Diagnosis", txtDiagnosis.Text);
                        command.Parameters.AddWithValue("@AppointmentDate", dtpDate.Value);
                        command.Parameters.AddWithValue("@Prescription", txtPrescription.Text);
                        command.Parameters.AddWithValue("@SurgeryProcedure", txtProcedure.Text);
                        command.Parameters.AddWithValue("@SurgeryTools", txtToolCost.Text); // Assuming tools are listed here
                        command.Parameters.AddWithValue("@Amount", amountGiven);
                        command.Parameters.AddWithValue("@MethodOfPayment", cbMethod.SelectedItem?.ToString());
                        command.Parameters.AddWithValue("@TotalCost", totalCost);
                        command.Parameters.AddWithValue("@ChangeAmount", changeAmount);
                        command.Parameters.AddWithValue("@PreTotalCost", decimal.Parse(txtPreCost.Text));
                        command.Parameters.AddWithValue("@ProTotalCost", decimal.Parse(txtProCost.Text));
                        command.Parameters.AddWithValue("@ToolTotalCost", decimal.Parse(txtToolCost.Text));

                        // Execute the query
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving payment to database: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // Reset fields after successful payment (optional)
        private void ResetBillingForm()
        {
            txtPreCost.Text = string.Empty;
            txtProCost.Text = string.Empty;
            txtToolCost.Text = string.Empty;
            txtTotal.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtChange.Text = string.Empty;
            cbPatientFullName.SelectedIndex = -1; // Reset dropdown
            txtDiagnosis.Text = string.Empty;
            dtpDate.Value = DateTime.Now; // Reset to current date
            txtPrescription.Text = string.Empty;
            txtProcedure.Text = string.Empty;
            txtTools.Text = string.Empty;
            cbMethod.SelectedItem = string.Empty;
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Implement delete functionality here if needed
        }

        private void cbPatientFullName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedName = cbPatientFullName.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedName)) return;

            // Find the selected patient's record
            var selectedRecord = patientRecords.FirstOrDefault(record => record.FullName == selectedName);
            if (selectedRecord != null)
            {
                // Display the patient's details
                txtDiagnosis.Text = selectedRecord.Diagnosis;
                dtpDate.Value = selectedRecord.AppointmentDate;
                txtPrescription.Text = selectedRecord.Prescription;
                txtProcedure.Text = selectedRecord.Procedure;

                // Load treatments for the selected diagnosis
                LoadTreatments(selectedRecord.Diagnosis);

                // Generate costs
                GeneratePrescriptionCost();
                GenerateProcedureCost();
                GenerateToolCost();
                CalculateTotal();

                // Fetch doctor's name and role from the MedicalHistory table
                FetchDoctorDetails(selectedName);
            }
        }

        private void FetchDoctorDetails(string patientName)
        {
            try
            {
                // Connect to the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT DoctorName, Role FROM MedicalHistory WHERE PatientFullName = @PatientName";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PatientName", patientName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Update labels with the doctor's details
                                lblDoctor.Text = reader["DoctorName"].ToString();
                                lblRole.Text = reader["Role"].ToString();
                            }
                            else
                            {
                                // Handle case where doctor details are not found
                                lblDoctor.Text = "Doctor Not Found";
                                lblRole.Text = "Role Not Found";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching doctor details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void txtTools_TextChanged(object sender, EventArgs e)
        {
            GenerateToolCost();
            txtTools.TextChanged += txtTools_TextChanged;

        }


        private void txtProcedure_TextChanged(object sender, EventArgs e)
        {
            GenerateProcedureCost();
            txtProcedure.TextChanged += txtProcedure_TextChanged;
        }


        private void txtPrescription_TextChanged(object sender, EventArgs e)
        {
            GeneratePrescriptionCost();
            txtPrescription.TextChanged += txtPrescription_TextChanged;
        }

        private void txtPreCost_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
            UpdateTotal();
            txtPreCost.TextChanged += txtPreCost_TextChanged;
        }

        private void txtProCost_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
            UpdateTotal();
            txtProCost.TextChanged += txtProCost_TextChanged;
        }

        private void txtToolCost_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
            UpdateTotal();
            txtToolCost.TextChanged += txtToolCost_TextChanged;
        }


        private void UpdateTotal()
        {
            try
            {
                // Parse the costs from the textboxes
                decimal preCost = string.IsNullOrEmpty(txtPreCost.Text) ? 0 : decimal.Parse(txtPreCost.Text.TrimStart('P'));
                decimal proCost = string.IsNullOrEmpty(txtProCost.Text) ? 0 : decimal.Parse(txtProCost.Text.TrimStart('P'));
                decimal toolCost = string.IsNullOrEmpty(txtToolCost.Text) ? 0 : decimal.Parse(txtToolCost.Text.TrimStart('P'));

                // Calculate the total
                decimal total = preCost + proCost + toolCost;

                // Update txtTotal
                txtTotal.Text = $"P{total:N2}";
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid cost values. Ensure all cost fields have valid numeric values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Billing_Load(object sender, EventArgs e)
        {
            txtPreCost.TextChanged += (s, ev) => UpdateTotal();
            txtProCost.TextChanged += (s, ev) => UpdateTotal();
            txtToolCost.TextChanged += (s, ev) => UpdateTotal();
            txtPreCost.TextChanged += (s, ev) => CalculateTotal();
            txtProCost.TextChanged += (s, ev) => CalculateTotal();
            txtToolCost.TextChanged += (s, ev) => CalculateTotal();
        }



        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits, backspace, and a single decimal point
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Prevent multiple decimal points
            if (e.KeyChar == '.' && txtAmount.Text.Contains('.'))
            {
                e.Handled = true;
            }
        }



    }
}
