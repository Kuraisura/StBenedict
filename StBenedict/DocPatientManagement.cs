using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StBenedict
{
    public partial class DocPatientManagement : Form
    {

        private const string ConnectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Kuraisura\Downloads\StBenedict7.0\StBenedict6.0\StBenedict4.0\StBenedict4.0\StBenedict\StBenedict\StBenedict\StBenedict.mdf;Integrated Security=True";

        public DocPatientManagement()
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

        }

        private void LoadPatientNames()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    // Query to retrieve full names from the Patient table
                    string query = @"
                SELECT 
                    CONCAT(FirstName, ' ', 
                           ISNULL(MiddleName + ' ', ''), 
                           LastName, 
                           CASE WHEN Suffix IS NOT NULL AND Suffix <> '' THEN ', ' + Suffix ELSE '' END) AS FullName
                FROM Patient";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        cbPatientFullName.Items.Clear(); // Clear any existing items

                        while (reader.Read())
                        {
                            cbPatientFullName.Items.Add(reader["FullName"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading patient names: {ex.Message}");
            }
        }

        private void DocPatientManagement_Load(object sender, EventArgs e)
        {
            LoadPatientNames(); // Load all patient names into the combo box
        }

        private void cbPatFullName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Ensure a patient is selected
                if (cbPatientFullName.SelectedIndex == -1)
                {
                    txtDiagnosis.Text = "";
                    dtpDate.Value = DateTime.Now;
                    txtTimeIn.Clear();
                    txtTimeOut.Clear();
                    lblDoctor.Text = "";
                    lblRole.Text = "";
                    return;
                }

                // Get the selected patient's full name
                string selectedPatient = cbPatientFullName.SelectedItem.ToString();

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    // Query to retrieve the diagnosis, appointment details, doctor's information, and role (Specialty)
                    string query = @"
            SELECT 
                TOP 1 
                pd.Diagnosis, 
                a.AppointmentDate, 
                a.TimeIn, 
                a.TimeOut,
                d.FirstName AS DoctorFirstName, 
                d.LastName AS DoctorLastName,
                d.MiddleName AS DoctorMiddleName,
                d.Specialty AS DoctorSpecialty
            FROM Patient p
            INNER JOIN PatientDiagnosis pd ON p.PatientID = pd.PatientID
            INNER JOIN Appointment a ON p.PatientID = a.PatientID
            INNER JOIN Doctor d ON a.DoctorID = d.DoctorID
            WHERE CONCAT(p.FirstName, ' ', 
                         ISNULL(p.MiddleName + ' ', ''), 
                         p.LastName, 
                         CASE WHEN p.Suffix IS NOT NULL AND p.Suffix <> '' THEN ', ' + p.Suffix ELSE '' END) = @FullName
            ORDER BY a.AppointmentDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FullName", selectedPatient);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Fetch and set the diagnosis and appointment details
                                txtDiagnosis.Text = reader["Diagnosis"]?.ToString() ?? "No diagnosis available.";

                                if (reader["AppointmentDate"] != DBNull.Value)
                                {
                                    dtpDate.Value = Convert.ToDateTime(reader["AppointmentDate"]);
                                }
                                else
                                {
                                    dtpDate.Value = DateTime.Now;
                                }

                                txtTimeIn.Text = reader["TimeIn"]?.ToString() ?? "N/A";
                                txtTimeOut.Text = reader["TimeOut"]?.ToString() ?? "N/A";

                                // Autofill procedure and prescription
                                AutofillProcedureAndPrescription(txtDiagnosis.Text);

                                // Set the doctor's full name and specialty (role)
                                string doctorFullName = $"{reader["DoctorFirstName"]} {reader["DoctorMiddleName"]} {reader["DoctorLastName"]}";
                                lblDoctor.Text = $"{doctorFullName}";
                                lblRole.Text = $"{reader["DoctorSpecialty"]?.ToString() ?? "No specialty available"}";
                            }
                            else
                            {
                                txtDiagnosis.Text = "No diagnosis available.";
                                dtpDate.Value = DateTime.Now;
                                txtTimeIn.Clear();
                                txtTimeOut.Clear();
                                lblDoctor.Text = "";
                                lblRole.Text = "";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving appointment details: {ex.Message}");
            }
        }




        private void AutofillProcedureAndPrescription(string diagnosis)
        {
            // Example dictionaries for procedures and prescriptions
            var procedures = new Dictionary<string, string>
            {
                 // General Medicine
            { "Hypertension", "Renal artery stenting" },
            { "Diabetes Mellitus", "Pancreas transplantation" },
            { "Hyperlipidemia", "Liposuction (for severe lipid deposits)" },
            { "Asthma", "Bronchial thermoplasty" },
            { "COPD", "Lung volume reduction surgery (LVRS)" },
            { "GERD", "Fundoplication" },
            { "Upper Respiratory Infections", "Endoscopic sinus surgery" },
            { "Anemia", "Splenectomy" },
            { "Thyroid Disorders", "Thyroidectomy" },
            { "Kidney Disease", "Kidney transplant" },
            { "Obesity", "Bariatric surgery" },
            { "Allergic Rhinitis", "Endoscopic sinus surgery" },
            { "Sleep Apnea", "Uvulopalatopharyngoplasty (UPPP)" },
            { "Fatigue Syndromes", "None" },
            { "Acid Reflux", "Fundoplication" },
            { "UTIs", "Ureteral reimplantation" },
            { "Mental Health Conditions", "Deep brain stimulation" },
            { "Infections", "Abscess drainage" },
            { "Chronic Pain Syndromes", "Spinal cord stimulation" },

            // Pediatrics
            { "Bronchiolitis", "Bronchoscopy" },
            { "Pneumonia", "Thoracentesis or decortication" },
            { "Croup", "Tracheostomy" },
            { "Gastroenteritis", "None" },
            { "Ear Infections", "Tympanostomy" },
            { "RSV Infection", "Bronchoscopy" },
            { "Diarrhea and Vomiting", "None" },
            { "Fever and Sepsis", "None" },
            { "ADHD", "None" },
            { "ASD", "None" },
            { "Eczema", "None" },
            { "Childhood Obesity", "Bariatric surgery" },
            { "Congenital Heart Defects", "Corrective heart surgery" },

            // Orthopedics
            { "Fractures", "Open reduction and internal fixation (ORIF)" },
            { "Osteoarthritis", "Total joint replacement" },
            { "Rheumatoid Arthritis", "Synovectomy or joint replacement" },
            { "Spondylosis", "Spinal decompression surgery" },
            { "Sciatica", "Microdiscectomy" },
            { "Carpal Tunnel Syndrome", "Carpal tunnel release surgery" },
            { "Sprains and Strains", "None" },
            { "Bursitis", "Bursectomy" },
            { "Tendonitis", "Tendon repair" },
            { "Herniated Discs", "Laminectomy or discectomy" },
            { "Osteoporosis", "Vertebroplasty or kyphoplasty" },

            // Cardiology
            { "Coronary Artery Disease", "Coronary artery bypass grafting (CABG)" },
            { "Heart Attack", "Emergency angioplasty or CABG" },
            { "Heart Failure", "Left ventricular assist device (LVAD) implantation" },
            { "Arrhythmias", "Pacemaker or ICD implantation" },
            { "Valvular Heart Diseases", "Valve replacement or repair" },
            { "Cardiomyopathy", "Heart transplant" },

            // Dermatology
            { "Acne", "Laser resurfacing or surgical excision of cysts" },
            { "Psoriasis", "None" },
            { "Rosacea", "Laser therapy" },
            { "Melanoma", "Wide local excision or sentinel lymph node biopsy" },
            { "BCC", "Mohs surgery" },
            { "SCC", "Excision or Mohs surgery" },
            { "Hives", "None" },
            { "Contact Dermatitis", "None" },

            // Ophthalmology
            { "Cataracts", "Cataract surgery" },
            { "Glaucoma", "Trabeculectomy or shunt implantation" },
            { "Macular Degeneration", "Laser photocoagulation" },
            { "Diabetic Retinopathy", "Vitrectomy" },
            { "Retinal Detachment", "Scleral buckle or vitrectomy" },
            { "Conjunctivitis", "None" },
            { "Dry Eye Syndrome", "Punctal occlusion" },
            { "Astigmatism", "LASIK surgery" },
            { "Myopia", "LASIK surgery" },
            { "Hyperopia", "LASIK surgery" },
            { "Presbyopia", "Presbyopia-correcting lens implants" },
            { "Strabismus", "Strabismus surgery" },
            { "Amblyopia", "None" },
            { "Eye Injuries", "Corneal repair or enucleation" },
            { "Keratoconus", "Corneal transplant" },
            { "Uveitis", "None" },
            { "Pterygium", "Pterygium excision" },
            { "Blepharitis", "None" },
            { "Eye Infections", "Vitrectomy" },
            { "Retinal Vascular Occlusion", "Vitrectomy" },
            { "Color Blindness", "None" },
            { "Corneal Ulcers", "Corneal transplant" },
            { "Optic Neuritis", "None" },
            { "Eye Tumors", "Enucleation or orbital exenteration" }
            };

            var prescriptions = new Dictionary<string, List<string>>
            {
               // General Medicine 
    { "Hypertension", new List<string> { "Amlodipine" } },
    { "Diabetes Mellitus", new List<string> { "Metformin" } },
    { "Hyperlipidemia", new List<string> { "Atorvastatin" } },
    { "Asthma", new List<string> { "Salbutamol" } },
    { "COPD", new List<string> { "Tiotropium" } },
    { "GERD", new List<string> { "Omeprazole" } },
    { "Upper Respiratory Infections", new List<string> { "Amoxicillin" } },
    { "Anemia", new List<string> { "Ferrous sulfate" } },
    { "Thyroid disorders", new List<string> { "Levothyroxine" } },
    { "Kidney Disease", new List<string> { "Losartan" } },
    { "Obesity", new List<string> { "Orlistat" } },
    { "Allergic Rhinitis", new List<string> { "Cetirizine" } },
    { "Sleep Apnea", new List<string> { "CPAP therapy" } },
    { "Fatigue Syndromes", new List<string> { "Multivitamins" } },
    { "Acid Reflux", new List<string> { "Ranitidine" } },
    { "UTIs", new List<string> { "Nitrofurantoin" } },
    { "Mental Health Conditions", new List<string> { "Sertraline" } },
    { "Infections", new List<string> { "Amoxicillin/Clavulanate" } },
    { "Chronic Pain Syndromes", new List<string> { "Gabapentin" } },

            // Pediatrics
    { "Bronchiolitis", new List<string> { "Supportive care" } },
    { "Pneumonia", new List<string> { "Amoxicillin" } },
    { "Croup", new List<string> { "Dexamethasone" } },
    { "Gastroenteritis", new List<string> { "ORS" } },
    { "Ear Infections", new List<string> { "Amoxicillin" } },
    { "RSV Infection", new List<string> { "Supportive care" } },
    { "Diarrhea and Vomiting", new List<string> { "ORS" } },
    { "Fever and Sepsis", new List<string> { "IV antibiotics" } },
    { "ADHD", new List<string> { "Methylphenidate" } },
    { "ASD", new List<string> { "Speech therapy" } },
    { "Eczema", new List<string> { "Topical corticosteroids" } },
    { "Childhood Obesity", new List<string> { "Dietary counseling" } },
    { "Congenital heart defects", new List<string> { "Surgical correction" } },

    // Orthopedics
    { "Fractures", new List<string> { "Immobilization" } },
    { "Osteoarthritis", new List<string> { "NSAIDs" } },
    { "Rheumatoid Arthritis", new List<string> { "Methotrexate" } },
    { "Spondylosis", new List<string> { "Physical therapy" } },
    { "Sciatica", new List<string> { "Gabapentin" } },
    { "Carpal Tunnel Syndrome", new List<string> { "Wrist splints" } },
    { "Sprains and Strains", new List<string> { "RICE method" } },
    { "Bursitis", new List<string> { "NSAIDs" } },
    { "Tendonitis", new List<string> { "Topical NSAIDs" } },
    { "Herniated Discs", new List<string> { "Physiotherapy" } },
    { "Osteoporosis", new List<string> { "Calcium" } },

            // Cardiology
    { "Coronary Artery Disease", new List<string> { "Aspirin" } },
    { "Heart Attack", new List<string> { "Nitroglycerin" } },
    { "Heart Failure", new List<string> { "Furosemide" } },
    { "Arrhythmias", new List<string> { "Amiodarone" } },
    { "Valvular Heart Diseases", new List<string> { "Surgical repair" } },
    { "Cardiomyopathy", new List<string> { "Beta-blockers" } },

    // Dermatology
    { "Acne", new List<string> { "Benzoyl peroxide" } },
    { "Psoriasis", new List<string> { "Topical corticosteroids" } },
    { "Rosacea", new List<string> { "Topical metronidazole" } },
    { "Melanoma", new List<string> { "Surgical excision" } },
    { "BCC", new List<string> { "Surgical excision" } },
    { "SCC", new List<string> { "Mohs surgery" } },
    { "Hives", new List<string> { "Antihistamines" } },
    { "Contact Dermatitis", new List<string> { "Topical corticosteroids" } },

    // Ophthalmology
    { "Cataracts", new List<string> { "No Medication Is Needed" } },
    { "Glaucoma", new List<string> { "Latanoprost" } },
    { "Macular Degeneration", new List<string> { "Anti-VEGF" } },
    { "Diabetic Retinopathy", new List<string> { "Anti-VEGF" } },
    { "Retinal Detachment", new List<string> { "No Medication Is Needed" } },
    { "Conjunctivitis", new List<string> { "Moxifloxacin" } },
    { "Dry Eye Syndrome", new List<string> { "Artificial tears" } },
    { "Astigmatism", new List<string> { "No Medication Is Needed" } },
    { "Myopia", new List<string> { "No Medication Is Needed" } },
    { "Hyperopia", new List<string> { "No Medication Is Needed" } },
    { "Presbyopia", new List<string> { "No Medication Is Needed" } },
    { "Strabismus", new List<string> { "No Medication Is Needed" } },
    { "Amblyopia", new List<string> { "No Medication Is Needed" } },
    { "Eye Injuries", new List<string> { "Ciprofloxacin" } },
    { "Keratoconus", new List<string> { "No Medication Is Needed" } },
    { "Uveitis", new List<string> { "Prednisolone acetate" } },
    { "Pterygium", new List<string> { "Artificial tears" } },
    { "Blepharitis", new List<string> { "Erythromycin" } },
    { "Eye Infections", new List<string> { "Ciprofloxacin" } },
    { "Retinal Vascular Occlusion", new List<string> { "No Medication Is Needed" } },
    { "Color Blindness", new List<string> { "No Medication Is Needed" } },
    { "Corneal Ulcers", new List<string> { "Moxifloxacin" } },
    { "Optic Neuritis", new List<string> { "Intravenous methylprednisolone" } },
    { "Eye Tumors", new List<string> { "No Medication Is Needed" } }
            };

            var dosages = new Dictionary<string, string>
{
    // General Medicine
    { "Hypertension", "5mg" },
    { "Diabetes Mellitus", "500mg" },
    { "Hyperlipidemia", "20mg" },
    { "Asthma", "Inhaler as needed" },
    { "COPD", "Inhaler once daily" },
    { "GERD", "20mg" },
    { "Upper Respiratory Infections", "500mg" },
    { "Anemia", "325mg" },
    { "Thyroid disorders", "50mcg" },
    { "Kidney Disease", "50mg" },
    { "Obesity", "120mg" },
    { "Allergic Rhinitis", "10mg" },
    { "Sleep Apnea", "No dosage" },
    { "Fatigue Syndromes", "No dosage" },
    { "Acid Reflux", "150mg" },
    { "UTIs", "100mg" },
    { "Mental Health Conditions", "50mg" },
    { "Infections", "875mg/125mg" },
    { "Chronic Pain Syndromes", "300mg" },

                // Pediatrics
    { "Bronchiolitis", "No dosage" },
    { "Pneumonia", "40mg/kg" },
    { "Croup", "0.15mg/kg" },
    { "Gastroenteritis", "No dosage" },
    { "Ear Infections", "90mg/kg/day" },
    { "RSV Infection", "No dosage" },
    { "Diarrhea and Vomiting", "No dosage" },
    { "Fever and Sepsis", "No dosage" },
    { "ADHD", "5mg" },
    { "ASD", "No dosage" },
    { "Eczema", "No dosage" },
    { "Childhood Obesity", "No dosage" },
    { "Congenital heart defects", "No dosage" },

    // Orthopedics
    { "Fractures", "No dosage" },
    { "Osteoarthritis", "No dosage" },
    { "Rheumatoid Arthritis", "15mg" },
    { "Spondylosis", "No dosage" },
    { "Sciatica", "300mg" },
    { "Carpal Tunnel Syndrome", "No dosage" },
    { "Sprains and Strains", "No dosage" },
    { "Bursitis", "No dosage" },
    { "Tendonitis", "No dosage" },
    { "Herniated Discs", "No dosage" },
    { "Osteoporosis", "No dosage" },

    // Cardiology
    { "Coronary Artery Disease", "81mg" },
    { "Heart Attack", "As needed" },
    { "Heart Failure", "40mg" },
    { "Arrhythmias", "200mg" },
    { "Valvular Heart Diseases", "No dosage" },
    { "Cardiomyopathy", "No dosage" },

    // Dermatology
    { "Acne", "gel" },
    { "Psoriasis", "No dosage" },
    { "Rosacea", "No dosage" },
    { "Melanoma", "No dosage" },
    { "BCC", "No dosage" },
    { "SCC", "No dosage" },
    { "Hives", "No dosage" },
    { "Contact Dermatitis", "No dosage" },

    // Ophthalmology
    { "Cataracts", "No dosage" },
    { "Glaucoma", "0.005%" },
    { "Macular Degeneration", "injections" },
    { "Diabetic Retinopathy", "injections" },
    { "Retinal Detachment", "No dosage" },
    { "Conjunctivitis", "0.5%" },
    { "Dry Eye Syndrome", "No dosage" },
    { "Astigmatism", "No dosage" },
    { "Myopia", "No dosage" },
    { "Hyperopia", "No dosage" },
    { "Presbyopia", "No dosage" },
    { "Strabismus", "No dosage" },
    { "Amblyopia", "No dosage" },
    { "Eye Injuries", "0.3%" },
    { "Keratoconus", "No dosage" },
    { "Uveitis", "1%" },
    { "Pterygium", "No dosage" },
    { "Blepharitis", "0.5%" },
    { "Eye Infections", "0.3%" },
    { "Retinal Vascular Occlusion", "No dosage" },
    { "Color Blindness", "No dosage" },
    { "Corneal Ulcers", "0.5%" },
    { "Optic Neuritis", "No dosage" },
    { "Eye Tumors", "No dosage" }
};

            var frequency = new Dictionary<string, string>
{
    // General Medicine
    { "Hypertension", "daily" },
    { "Diabetes Mellitus", "twice daily" },
    { "Hyperlipidemia", "daily" },
    { "Asthma", "PRN" },
    { "COPD", "daily" },
    { "GERD", "daily" },
    { "Upper Respiratory Infections", "three times daily" },
    { "Anemia", "daily" },
    { "Thyroid disorders", "daily" },
    { "Kidney Disease", "daily" },
    { "Obesity", "as directed" },
    { "Allergic Rhinitis", "daily" },
    { "Sleep Apnea", "As prescribed" },
    { "Fatigue Syndromes", "Daily" },
    { "Acid Reflux", "twice daily" },
    { "UTIs", "twice daily" },
    { "Mental Health Conditions", "daily" },
    { "Infections", "twice daily" },
    { "Chronic Pain Syndromes", "daily" },

                // Pediatrics
    { "Bronchiolitis", "As needed" },
    { "Pneumonia", "daily" },
    { "Croup", "As prescribed" },
    { "Gastroenteritis", "As directed" },
    { "Ear Infections", "daily" },
    { "RSV Infection", "As needed" },
    { "Diarrhea and Vomiting", "As directed" },
    { "Fever and Sepsis", "As directed" },
    { "ADHD", "daily" },
    { "ASD", "As prescribed" },
    { "Eczema", "As needed" },
    { "Childhood Obesity", "As directed" },
    { "Congenital heart defects", "As needed" },

    // Orthopedics
    { "Fractures", "As prescribed" },
    { "Osteoarthritis", "As directed" },
    { "Rheumatoid Arthritis", "weekly" },
    { "Spondylosis", "As directed" },
    { "Sciatica", "daily" },
    { "Carpal Tunnel Syndrome", "As needed" },
    { "Sprains and Strains", "As needed" },
    { "Bursitis", "As directed" },
    { "Tendonitis", "As directed" },
    { "Herniated Discs", "As prescribed" },
    { "Osteoporosis", "Daily" },

    // Cardiology
    { "Coronary Artery Disease", "daily" },
    { "Heart Attack", "PRN" },
    { "Heart Failure", "daily" },
    { "Arrhythmias", "daily" },
    { "Valvular Heart Diseases", "As needed" },
    { "Cardiomyopathy", "Daily" },

                // Dermatology
    { "Acne", "Daily" },
    { "Psoriasis", "As needed" },
    { "Rosacea", "As directed" },
    { "Melanoma", "As needed" },
    { "BCC", "As needed" },
    { "SCC", "As needed" },
    { "Hives", "As needed" },
    { "Contact Dermatitis", "As needed" },

    // Ophthalmology
    { "Cataracts", "No Frequency" },
    { "Glaucoma", "daily" },
    { "Macular Degeneration", "As prescribed" },
    { "Diabetic Retinopathy", "As prescribed" },
    { "Retinal Detachment", "No Frequency" },
    { "Conjunctivitis", "As needed" },
    { "Dry Eye Syndrome", "As needed" },
    { "Astigmatism", "No Frequency" },
    { "Myopia", "No Frequency" },
    { "Hyperopia", "No Frequency" },
    { "Presbyopia", "No Frequency" },
    { "Strabismus", "No Frequency" },
    { "Amblyopia", "No Frequency" },
    { "Eye Injuries", "As needed" },
    { "Keratoconus", "No Frequency" },
    { "Uveitis", "As prescribed" },
    { "Pterygium", "As needed" },
    { "Blepharitis", "As needed" },
    { "Eye Infections", "As needed" },
    { "Retinal Vascular Occlusion", "No Frequency" },
    { "Color Blindness", "No Frequency" },
    { "Corneal Ulcers", "As needed" },
    { "Optic Neuritis", "As prescribed" },
    { "Eye Tumors", "No Frequency" },
};

            var notes = new Dictionary<string, string>
{
    // General Medicine 
    { "Hypertension", "No special notes" },
    { "Diabetes Mellitus", "For blood sugar control" },
    { "Hyperlipidemia", "For lowering cholesterol" },
    { "Asthma", "For bronchodilation" },
    { "COPD", "For long-term bronchodilation" },
    { "GERD", "For reducing gastric acid" },
    { "Upper Respiratory Infections", "For bacterial infection" },
    { "Anemia", "To increase iron levels" },
    { "Thyroid disorders", "For thyroid hormone replacement" },
    { "Kidney Disease", "For kidney protection and blood pressure control" },
    { "Obesity", "For weight management" },
    { "Allergic Rhinitis", "For allergy relief" },
    { "Sleep Apnea", "For managing sleep apnea" },
    { "Fatigue Syndromes", "For general well-being" },
    { "Acid Reflux", "For managing acid reflux" },
    { "UTIs", "For treating urinary tract infections" },
    { "Mental Health Conditions", "For managing depression and anxiety" },
    { "Infections", "For treating infections" },
    { "Chronic Pain Syndromes", "For nerve pain management" },

    // Pediatrics
    { "Bronchiolitis", "Monitor for signs of respiratory distress" },
    { "Pneumonia", "For bacterial pneumonia" },
    { "Croup", "For reducing inflammation in the airways" },
    { "Gastroenteritis", "For hydration support" },
    { "Ear Infections", "For bacterial ear infection" },
    { "RSV Infection", "For respiratory support" },
    { "Diarrhea and Vomiting", "For fluid and electrolyte balance" },
    { "Fever and Sepsis", "For bacterial infections" },
    { "ADHD", "For attention and hyperactivity control" },
    { "ASD", "For language development" },
    { "Eczema", "For managing skin inflammation" },
    { "Childhood Obesity", "For promoting healthy weight" },
    { "Congenital heart defects", "For surgical intervention" },

                // Orthopedics
    { "Fractures", "For fracture management" },
    { "Osteoarthritis", "For pain and inflammation" },
    { "Rheumatoid Arthritis", "For disease-modifying therapy" },
    { "Spondylosis", "For spine mobility and pain relief" },
    { "Sciatica", "For nerve pain relief" },
    { "Carpal Tunnel Syndrome", "For wrist support" },
    { "Sprains and Strains", "For rest and recovery" },
    { "Bursitis", "For pain and swelling reduction" },
    { "Tendonitis", "For tendon inflammation" },
    { "Herniated Discs", "For rehabilitation" },
    { "Osteoporosis", "For bone health" },

    // Cardiology
    { "Coronary Artery Disease", "For preventing blood clots" },
    { "Heart Attack", "For chest pain relief" },
    { "Heart Failure", "For fluid management" },
    { "Arrhythmias", "For rhythm control" },
    { "Valvular Heart Diseases", "For valve replacement or repair" },
    { "Cardiomyopathy", "For heart function support" },

    // Dermatology
    { "Acne", "For acne control" },
    { "Psoriasis", "For controlling flare-ups" },
    { "Rosacea", "For managing rosacea" },
    { "Melanoma", "For tumor removal" },
    { "BCC", "For basal cell carcinoma treatment" },
    { "SCC", "For squamous cell carcinoma removal" },
    { "Hives", "For allergic reactions" },
    { "Contact Dermatitis", "For reducing skin inflammation" },

                // Ophthalmology
    { "Cataracts", "For surgical intervention" },
    { "Glaucoma", "For lowering intraocular pressure" },
    { "Macular Degeneration", "For slowing disease progression" },
    { "Diabetic Retinopathy", "For preventing vision loss" },
    { "Retinal Detachment", "Requires surgical intervention" },
    { "Conjunctivitis", "For bacterial eye infection" },
    { "Dry Eye Syndrome", "For moisture and lubrication" },
    { "Astigmatism", "Corrective lenses may be used" },
    { "Myopia", "Corrective lenses may be used" },
    { "Hyperopia", "Corrective lenses may be used" },
    { "Presbyopia", "Corrective lenses may be used" },
    { "Strabismus", "May require surgical correction" },
    { "Amblyopia", "May require vision therapy" },
    { "Eye Injuries", "For eye infection prevention" },
    { "Keratoconus", "May require contact lenses or surgery" },
    { "Uveitis", "For inflammation control" },
    { "Pterygium", "For eye lubrication" },
    { "Blepharitis", "For eyelid inflammation" },
    { "Eye Infections", "For treating bacterial eye infections" },
    { "Retinal Vascular Occlusion", "Requires surgical or laser intervention" },
    { "Color Blindness", "No specific treatment available" },
    { "Corneal Ulcers", "For treating corneal infection" },
    { "Optic Neuritis", "For treating optic nerve inflammation" },
    { "Eye Tumors", "Requires surgical or oncological management" }


};


            // Retrieve prescription based on the diagnosis
            if (prescriptions.TryGetValue(diagnosis, out List<string> medList))
            {
                txtPrescription.Text = string.Join(", ", medList); // Join the list items into a single string
            }
            else
            {
                txtPrescription.Text = "None";
            }

            // Retrieve dosage based on the diagnosis
            if (dosages.TryGetValue(diagnosis, out string dosage))
            {
                txtDosage.Text = dosage;
            }
            else
            {
                txtDosage.Text = "No dosage";
            }

            // Retrieve frequency based on the diagnosis
            if (frequency.TryGetValue(diagnosis, out string frequencyValue))
            {
                txtFrequency.Text = frequencyValue;
            }
            else
            {
                txtFrequency.Text = "No frequency";
            }

            // Retrieve notes based on the diagnosis
            if (notes.TryGetValue(diagnosis, out string note))
            {
                txtNotes.Text = note;
            }
            else
            {
                txtNotes.Text = "No notes available";
            }

            // Retrieve procedure based on the diagnosis
            if (procedures.TryGetValue(diagnosis, out string procedure))
            {
                txtProcedure.Text = procedure;
            }
            else
            {
                txtProcedure.Text = "None";
            }

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                // Get selected patient name and details
                string selectedPatient = cbPatientFullName.SelectedItem?.ToString();
                if (string.IsNullOrWhiteSpace(selectedPatient))
                {
                    MessageBox.Show("Please select a patient.");
                    return;
                }

                string diagnosis = txtDiagnosis.Text.Trim();
                string selectedProcedure = txtProcedure.Text?.ToString() ?? "None";
                string selectedPrescription = txtPrescription.Text?.ToString() ?? "None";
                string frequency = txtFrequency.Text?.ToString() ?? "Not Specified";
                string dosage = txtDosage.Text?.ToString() ?? "Not Specified";
                string notes = txtNotes.Text.Trim();

                // Get the status from the ComboBox (cbStatus)
                string status = cbStatus.Text.Trim() ?? "Active"; // Default to "Active" if not selected

                // Retrieve doctor name and role
                string doctorName = lblDoctor.Text.Trim();
                string role = lblRole.Text.Trim();

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    // Step 1: Retrieve PatientID based on the selected full name
                    string getPatientIdQuery = @"
            SELECT PatientID 
            FROM Patient 
            WHERE CONCAT(FirstName, ' ', 
                         ISNULL(MiddleName + ' ', ''), 
                         LastName, 
                         CASE WHEN Suffix IS NOT NULL AND Suffix <> '' THEN ', ' + Suffix ELSE '' END) = @FullName";

                    SqlCommand cmd = new SqlCommand(getPatientIdQuery, conn);
                    cmd.Parameters.AddWithValue("@FullName", selectedPatient);
                    object patientIdObj = cmd.ExecuteScalar();

                    if (patientIdObj == null)
                    {
                        MessageBox.Show("Patient not found in the database.");
                        return;
                    }

                    int patientId = Convert.ToInt32(patientIdObj);

                    // Step 2: Insert the medical history data into the MedicalHistory table
                    string saveDataQuery = @"
            INSERT INTO MedicalHistory (DoctorName, Role, PatientFullName, Diagnosis, AppointmentDate, 
                                        TimeIn, TimeOut, Surgery, Prescription, Dosage, Frequency, Notes, Status)
            VALUES (@DoctorName, @Role, @PatientFullName, @Diagnosis, @AppointmentDate, @TimeIn, @TimeOut, 
                    @Surgery, @Prescription, @Dosage, @Frequency, @Notes, @Status)";

                    cmd = new SqlCommand(saveDataQuery, conn);
                    cmd.Parameters.AddWithValue("@DoctorName", doctorName);
                    cmd.Parameters.AddWithValue("@Role", role);
                    cmd.Parameters.AddWithValue("@PatientFullName", selectedPatient);
                    cmd.Parameters.AddWithValue("@Diagnosis", diagnosis);
                    cmd.Parameters.AddWithValue("@AppointmentDate", dtpDate.Value); // Use DateTimePicker value
                    cmd.Parameters.AddWithValue("@TimeIn", txtTimeIn.Text?.ToString() ?? "N/A");
                    cmd.Parameters.AddWithValue("@TimeOut", txtTimeOut.Text?.ToString() ?? "N/A");
                    cmd.Parameters.AddWithValue("@Surgery", selectedProcedure);
                    cmd.Parameters.AddWithValue("@Prescription", selectedPrescription);
                    cmd.Parameters.AddWithValue("@Dosage", dosage);
                    cmd.Parameters.AddWithValue("@Frequency", frequency);
                    cmd.Parameters.AddWithValue("@Notes", notes);
                    cmd.Parameters.AddWithValue("@Status", status);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    MessageBox.Show(rowsAffected > 0 ? "Information saved successfully!" : "No changes made.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}");
            }
        }



    }
}
