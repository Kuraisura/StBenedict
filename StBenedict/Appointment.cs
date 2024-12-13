using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient; // For database access
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace StBenedict
{
    public partial class Appointment : Form
    {
        // Constants and fields
        private Timer btnTimerInsert, btnTimerUpdate, btnTimerDelete;
        private const int ButtonMinWidth = 40; // Min button width (icon only)
        private const int ButtonMaxWidth = 100; // Max button width (with text)
        private const int AnimationSpeed = 10; // Animation speed
        private int selectedAppointmentId = -1; // Tracks selected appointment


        // Database connection string
        private const string ConnectionString =
             @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Kuraisura\Downloads\StBenedict7.0\StBenedict6.0\StBenedict4.0\StBenedict4.0\StBenedict\StBenedict\StBenedict\StBenedict.mdf;Integrated Security=True";
        public Appointment()
        {
            InitializeComponent();

            // Initialize button animation timers
            btnTimerInsert = new Timer { Interval = 10 };
            btnTimerUpdate = new Timer { Interval = 10 };
            btnTimerDelete = new Timer { Interval = 10 };

            // Assign animation logic
            btnTimerInsert.Tick += BtnInsert_Animate;
            btnTimerUpdate.Tick += BtnUpdate_Animate;
            btnTimerDelete.Tick += BtnDelete_Animate;

            // Configure buttons
            SetupButton(btnInsert, "     Insert");
            SetupButton(btnUpdate, "     Update");
            SetupButton(btnDelete, "     Delete");

            // Load data for dropdowns
            LoadPatients();
        }

        // Appointment_Load: called when the form is loaded
        private void Appointment_Load(object sender, EventArgs e)
        {
            
            // Initialize Floor dropdown (if necessary)
            InitializeFloorDropdown();

            // Initialize columns for dgvAppointment
            dgvAppointment.AutoGenerateColumns = false;

            // Define columns if not already added
            if (dgvAppointment.Columns.Count == 0)
            {
                dgvAppointment.Columns.Add("AppointmentID", "Appointment ID");
                dgvAppointment.Columns.Add("PatientName", "Patient Name");
                dgvAppointment.Columns.Add("DoctorName", "Doctor Name");
                dgvAppointment.Columns.Add("AppointmentDate", "Appointment Date");
                dgvAppointment.Columns.Add("AppointmentStatus", "Status");
                dgvAppointment.Columns.Add("AppointmentFloor", "Floor");
                dgvAppointment.Columns.Add("AppointmentTime", "Time");
                dgvAppointment.Columns.Add("TimeAvailability", "Availability");
                dgvAppointment.Columns.Add("TimeIn", "Time In");
                dgvAppointment.Columns.Add("TimeOut", "Time Out");

                // Add select button column
                var selectColumn = new DataGridViewImageColumn
                {
                    Name = "Select",
                    HeaderText = "Select",
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                dgvAppointment.Columns.Add(selectColumn);
            }

            // Load all appointment data
            LoadAppointments();
        }



        // Button setup
        private void SetupButton(Guna2GradientButton button, string text)
        {
            button.Width = ButtonMinWidth;
            button.Text = ""; // Initially hide text
            button.TextAlign = HorizontalAlignment.Center;
            button.ImageAlign = HorizontalAlignment.Left; // Align icon left
            button.Tag = text; // Store full text in Tag

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

        // Start animation
        private void StartAnimation(Guna2GradientButton button, bool expanding)
        {
            Timer timer = button == btnInsert
                ? btnTimerInsert
                : button == btnUpdate
                    ? btnTimerUpdate
                    : btnTimerDelete;

            timer.Tag = new { Button = button, Expanding = expanding };
            timer.Start();
        }

        // Animation logic
        private void BtnInsert_Animate(object sender, EventArgs e) => AnimateButton(btnTimerInsert);
        private void BtnUpdate_Animate(object sender, EventArgs e) => AnimateButton(btnTimerUpdate);
        private void BtnDelete_Animate(object sender, EventArgs e) => AnimateButton(btnTimerDelete);

        private void AnimateButton(Timer timer)
        {
            dynamic state = timer.Tag;
            Guna2GradientButton button = state.Button;
            bool expanding = state.Expanding;

            if (expanding && button.Width < ButtonMaxWidth)
            {
                int delta = AnimationSpeed;
                button.Left -= delta; // Move left
                button.Width += delta; // Expand width

                if (button.Width >= ButtonMaxWidth)
                {
                    button.Width = ButtonMaxWidth;
                    timer.Stop();
                }
            }
            else if (!expanding && button.Width > ButtonMinWidth)
            {
                int delta = AnimationSpeed;
                button.Left += delta; // Move right
                button.Width -= delta; // Collapse width

                if (button.Width <= ButtonMinWidth)
                {
                    button.Width = ButtonMinWidth;
                    timer.Stop();
                }
            }
        }

        private void LoadPatients()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
        SELECT 
            p.FirstName, 
            p.MiddleName, 
            p.LastName, 
            CASE WHEN p.Suffix = 'None' THEN '' ELSE p.Suffix END AS Suffix,
            pd.Diagnosis
        FROM Patient p
        LEFT JOIN PatientDiagnosis pd ON p.PatientID = pd.PatientID
        ";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    cbPatFullName.Items.Clear(); // Clear the dropdown before adding items

                    while (reader.Read())
                    {
                        string firstName = reader["FirstName"].ToString();
                        string middleName = reader["MiddleName"].ToString();
                        string lastName = reader["LastName"].ToString();
                        string suffix = reader["Suffix"].ToString();
                        string diagnosis = reader["Diagnosis"].ToString();

                        // Use the helper method for formatting the full name
                        string fullName = FormatName(firstName, middleName, lastName, suffix);

                        // Append the diagnosis to the full name (if diagnosis exists)
                        if (!string.IsNullOrEmpty(diagnosis))
                        {
                            fullName += " (" + diagnosis + ")";
                        }

                        cbPatFullName.Items.Add(fullName); // Add formatted name to the dropdown
                    }
                }

                // Add event handler to populate doctor's name based on selected patient
                cbPatFullName.SelectedIndexChanged += CbPatFullName_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading patients: {ex.Message}");
            }
        }


        private string FormatName(string firstName, string middleName, string lastName, string suffix)
        {
            // Combine name parts, omitting middle name and suffix if empty
            string formattedName = $"{firstName} {middleName} {lastName}".Trim(); // Remove extra spaces
            if (!string.IsNullOrWhiteSpace(suffix)) formattedName += $" {suffix}";

            return formattedName;
        }


        private void CbPatFullName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPatFullName.SelectedIndex != -1)
            {
                string selectedPatient = cbPatFullName.SelectedItem.ToString();

                // Remove the diagnosis part from the selected patient name
                string patientNameWithoutDiagnosis = RemoveDiagnosis(selectedPatient);

                // Now pass the patient name without the diagnosis to load the recommended doctor
                LoadRecommendedDoctor(patientNameWithoutDiagnosis);

                // Load the schedule based on the patient's diagnosis
                string diagnosis = GetDiagnosis(selectedPatient);  // Extract the diagnosis from the selected patient
                LoadScheduleForDiagnosis(diagnosis);  // Load the schedule
            }
        }

        private string RemoveDiagnosis(string patientName)
        {
            // Find the index of the opening parenthesis
            int startIndex = patientName.IndexOf('(');

            // If there is a diagnosis (i.e., the parenthesis is found), remove it
            if (startIndex != -1)
            {
                return patientName.Substring(0, startIndex).Trim(); // Get the part before the parenthesis
            }

            // If there's no diagnosis, return the full name as is
            return patientName;
        }

        private string GetDiagnosis(string patientName)
        {
            // Find the index of the opening parenthesis
            int startIndex = patientName.IndexOf('(');
            int endIndex = patientName.IndexOf(')');

            // If there is a diagnosis (i.e., the parenthesis is found), extract the diagnosis
            if (startIndex != -1 && endIndex != -1)
            {
                return patientName.Substring(startIndex + 1, endIndex - startIndex - 1);
            }

            // If there's no diagnosis, return an empty string
            return string.Empty;
        }

        private void cbTimeAvailability_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ensure that an item is selected in the ComboBox
            if (cbTimeAvailability.SelectedIndex != -1)
            {
                string patientFullName = cbPatFullName.SelectedItem?.ToString();
                string diagnosis = ExtractDiagnosisFromFullName(patientFullName);

                // Check if the diagnosis exists in the dictionary
                if (schedule.ContainsKey(diagnosis))
                {
                    // Retrieve the selected schedule entry based on the selected index
                    var selectedSchedule = schedule[diagnosis][cbTimeAvailability.SelectedIndex];

                    // Extract time from the selected schedule entry
                    string selectedTimeAvailability = selectedSchedule.Time;

                    // Call the method to extract start and end times from the availability string
                    (string timeIn, string timeOut) = ExtractTimeFromAvailability(selectedTimeAvailability);

                    // Set the extracted times to the corresponding DateTimePickers
                    if (!string.IsNullOrEmpty(timeIn) && !string.IsNullOrEmpty(timeOut))
                    {
                        // Convert times to DateTime and set them
                        dtpTimeIn.Value = ConvertToDateTime(timeIn);
                        dtpTimeOut.Value = ConvertToDateTime(timeOut);
                    }
                    else
                    {
                        MessageBox.Show("Invalid time format.");
                    }
                }
            }
        }

        private string ExtractDiagnosisFromFullName(string fullName)
        {
            if (string.IsNullOrEmpty(fullName))
                return string.Empty;

            // Check if the full name contains parentheses and extract the text within them
            int startIndex = fullName.LastIndexOf('(');
            int endIndex = fullName.LastIndexOf(')');

            if (startIndex != -1 && endIndex != -1 && endIndex > startIndex)
            {
                return fullName.Substring(startIndex + 1, endIndex - startIndex - 1).Trim();
            }

            // If no diagnosis is found, return an empty string
            return string.Empty;
        }


        // Method to extract start and end times from the time availability string
        private (string, string) ExtractTimeFromAvailability(string timeAvailability)
        {
            // Assume the time format is something like "10am-12nn"
            var timeParts = timeAvailability.Split('-');
            if (timeParts.Length == 2)
            {
                return (timeParts[0].Trim(), timeParts[1].Trim()); // Return the start and end times
            }
            else
            {
                return (string.Empty, string.Empty); // Invalid format, return empty strings
            }
        }

        // Method to convert the string time into DateTime
        private DateTime ConvertToDateTime(string time)
        {
            // Assuming the time string is in the format "10am" or "12nn", and the date is today
            string timeWithToday = DateTime.Now.ToString("MM/dd/yyyy") + " " + time;
            DateTime result;

            // Try parsing the time into a DateTime
            if (DateTime.TryParse(timeWithToday, out result))
            {
                return result;
            }
            else
            {
                MessageBox.Show($"Invalid time format: {time}");
                return DateTime.Now; // Default to current date and time if parsing fails
            }
        }

        private Dictionary<string, List<ScheduleEntry>> schedule = new Dictionary<string, List<ScheduleEntry>>()
{
        {
      "Hypertension",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Routine Check-ups"),
        new ScheduleEntry("Wed", "1pm-3pm", "Chronic Illness Management")
      }
    }, {
      "Diabetes Mellitus",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Routine Check-ups"),
        new ScheduleEntry("Wed", "1pm-3pm", "Chronic Illness Management")
      }
    }, {
      "Hyperlipidemia",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Routine Check-ups")
      }
    }, {
      "Asthma",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Routine Check-ups"),
        new ScheduleEntry("Mon/Wed", "2pm-4pm", "Emergency Medical Consultation")
      }
    }, {
      "COPD",
      new List < ScheduleEntry > {
        new ScheduleEntry("Wed", "1pm-3pm", "Chronic Illness Management"),
        new ScheduleEntry("Mon/Wed", "2pm-4pm", "Emergency Medical Consultation")
      }
    }, {
      "GERD",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Routine Check-ups")
      }
    }, {
      "Upper Respiratory Infections",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed", "2pm-4pm", "Emergency Medical Consultation")
      }
    }, {
      "Anemia",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Routine Check-ups")
      }
    }, {
      "Thyroid Disorders",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Routine Check-ups")
      }
    }, {
      "Kidney Disease",
      new List < ScheduleEntry > {
        new ScheduleEntry("Wed", "1pm-3pm", "Chronic Illness Management")
      }
    }, {
      "Obesity",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Routine Check-ups")
      }
    }, {
      "Allergic Rhinitis",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Routine Check-ups")
      }
    }, {
      "Sleep Apnea",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Routine Check-ups")
      }
    }, {
      "Fatigue Syndromes",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Routine Check-ups")
      }
    }, {
      "Acid Reflux",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Routine Check-ups")
      }
    }, {
      "UTIs",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Routine Check-ups")
      }
    }, {
      "Mental Health Conditions",
      new List < ScheduleEntry > {
        new ScheduleEntry("Wed/Fri", "4pm-5pm", "Follow-up Consultation")
      }
    }, {
      "Infections",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed", "2pm-4pm", "Emergency Medical Consultation")
      }
    }, {
      "Chronic Pain Syndromes",
      new List < ScheduleEntry > {
        new ScheduleEntry("Wed", "1pm-3pm", "Chronic Illness Management")
      }
    },
    // Pediatrics
    {
      "Bronchiolitis",
      new List < ScheduleEntry > {
        new ScheduleEntry("Wed", "1pm-3pm", "Acute Illness and Infections")
      }
    }, {
      "Pneumonia",
      new List < ScheduleEntry > {
        new ScheduleEntry("Wed", "1pm-3pm", "Acute Illness and Infections")
      }
    }, {
      "Croup",
      new List < ScheduleEntry > {
        new ScheduleEntry("Wed", "1pm-3pm", "Acute Illness and Infections")
      }
    }, {
      "Gastroenteritis",
      new List < ScheduleEntry > {
        new ScheduleEntry("Wed", "1pm-3pm", "Acute Illness and Infections")
      }
    }, {
      "Ear Infections",
      new List < ScheduleEntry > {
        new ScheduleEntry("Wed", "1pm-3pm", "Acute Illness and Infections")
      }
    }, {
      "RSV Infection",
      new List < ScheduleEntry > {
        new ScheduleEntry("Wed", "1pm-3pm", "Acute Illness and Infections")
      }
    }, {
      "Diarrhea and Vomiting",
      new List < ScheduleEntry > {
        new ScheduleEntry("Wed", "1pm-3pm", "Acute Illness and Infections")
      }
    }, {
      "Fever and Sepsis",
      new List < ScheduleEntry > {
        new ScheduleEntry("Wed", "1pm-3pm", "Acute Illness and Infections")
      }
    }, {
      "ADHD",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed", "2pm-4pm", "Developmental and Behavioral Concerns")
      }
    }, {
      "ASD",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed", "2pm-4pm", "Developmental and Behavioral Concerns")
      }
    }, {
      "Eczema",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Acne and Eczema Treatment")
      }
    }, {
      "Childhood Obesity",
      new List < ScheduleEntry > {
        new ScheduleEntry("Wed/Fri", "4pm-5pm", "Well-child Check-ups")
      }
    }, {
      "Congenital Heart Defects",
      new List < ScheduleEntry > {
        new ScheduleEntry("Fri", "11am-12pm", "Pediatric Cardiology")
      }
    },
    // Orthopedics
    {
      "Fractures",
      new List < ScheduleEntry > {
        new ScheduleEntry("Tue/Thu/Sat", "11am-12pm", "Joint and Bone Health")
      }
    }, {
      "Osteoarthritis",
      new List < ScheduleEntry > {
        new ScheduleEntry("Fri", "10am-12pm", "Arthritis and Degenerative Joint Diseases")
      }
    }, {
      "Rheumatoid Arthritis",
      new List < ScheduleEntry > {
        new ScheduleEntry("Fri", "10am-12pm", "Arthritis and Degenerative Joint Diseases")
      }
    }, {
      "Spondylosis",
      new List < ScheduleEntry > {
        new ScheduleEntry("Tue/Thu", "12pm-1pm", "Spine and Back Issues")
      }
    }, {
      "Sciatica",
      new List < ScheduleEntry > {
        new ScheduleEntry("Tue/Thu", "12pm-1pm", "Spine and Back Issues")
      }
    }, {
      "Carpal Tunnel Syndrome",
      new List < ScheduleEntry > {
        new ScheduleEntry("Tue/Thu/Sat", "11am-12pm", "Joint and Bone Health")
      }
    }, {
      "Sprains and Strains",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed", "10am-12pm", "Sports Injury Assessments")
      }
    }, {
      "Bursitis",
      new List < ScheduleEntry > {
        new ScheduleEntry("Tue/Thu/Sat", "11am-12pm", "Joint and Bone Health")
      }
    }, {
      "Tendonitis",
      new List < ScheduleEntry > {
        new ScheduleEntry("Tue/Thu/Sat", "11am-12pm", "Joint and Bone Health")
      }
    }, {
      "Herniated Discs",
      new List < ScheduleEntry > {
        new ScheduleEntry("Tue/Thu", "12pm-1pm", "Spine and Back Issues")
      }
    }, {
      "Osteoporosis",
      new List < ScheduleEntry > {
        new ScheduleEntry("Fri", "10am-12pm", "Arthritis and Degenerative Joint Diseases")
      }
    },
    //Cardiology
    {
      "Coronary Artery Disease",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed", "10am-12pm", "Heart Disease Prevention")
      }
    }, {
      "Heart Attack",
      new List < ScheduleEntry > {
        new ScheduleEntry("Wed", "11am-1pm", "Acute Heart Conditions")
      }
    }, {
      "Heart Failure",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed", "12pm-2pm", "Chronic Heart Disease Management")
      }
    }, {
      "Arrhythmias",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed", "12pm-2pm", "Chronic Heart Disease Management")
      }
    }, {
      "Valvular Heart Diseases",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed", "10am-12pm", "Heart Disease Prevention")
      }
    }, {
      "Cardiomyopathy",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed", "12pm-2pm", "Chronic Heart Disease Management")
      }
    },
    //Dermatology
    {
      "Acne",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Acne and Eczema Treatment")
      }
    }, {
      "Psoriasis",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Acne and Eczema Treatment")
      }
    }, {
      "Rosacea",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Acne and Eczema Treatment")
      }
    }, {
      "Melanoma",
      new List < ScheduleEntry > {
        new ScheduleEntry("Wed", "2pm-4pm", "Skin Health and Routine Check-ups")
      }
    }, {
      "BCC",
      new List < ScheduleEntry > {
        new ScheduleEntry("Wed", "2pm-4pm", "Skin Health and Routine Check-ups")
      }
    }, {
      "SCC",
      new List < ScheduleEntry > {
        new ScheduleEntry("Wed", "2pm-4pm", "Skin Health and Routine Check-ups")
      }
    }, {
      "Hives",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Acne and Eczema Treatment")
      }
    }, {
      "Contact Dermatitis",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Acne and Eczema Treatment")
      }
    },

    // Ophthalmology
    {
      "Cataracts",
      new List < ScheduleEntry > {
        new ScheduleEntry("Thu", "8am-10am", "Cataract and Glaucoma Screening")
      }
    }, {
      "Glaucoma",
      new List < ScheduleEntry > {
        new ScheduleEntry("Thu", "8am-10am", "Cataract and Glaucoma Screening")
      }
    }, {
      "Macular Degeneration",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Vision Check-ups")
      }
    }, {
      "Diabetic Retinopathy",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Vision Check-ups")
      }
    }, {
      "Retinal Detachment",
      new List < ScheduleEntry > {
        new ScheduleEntry("Thu", "8am-10am", "Cataract and Glaucoma Screening")
      }
    }, {
      "Conjunctivitis",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Eye Health Consultation")
      }
    }, {
      "Dry Eye Syndrome",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Eye Health Consultation")
      }
    }, {
      "Astigmatism",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Vision Check-ups")
      }
    }, {
      "Myopia",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Vision Check-ups")
      }
    }, {
      "Hyperopia",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Vision Check-ups")
      }
    }, {
      "Presbyopia",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Vision Check-ups")
      }
    }, {
      "Strabismus",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Vision Check-ups")
      }
    }, {
      "Amblyopia",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Vision Check-ups")
      }
    }, {
      "Eye Injuries",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Emergency Eye Care")
      }
    }, {
      "Keratoconus",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Vision Check-ups")
      }
    }, {
      "Uveitis",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Eye Health Consultation")
      }
    }, {
      "Pterygium",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Eye Health Consultation")
      }
    }, {
      "Blepharitis",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Eye Health Consultation")
      }
    }, {
      "Eye Infections",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Eye Health Consultation")
      }
    }, {
      "Retinal Vascular Occlusion",
      new List < ScheduleEntry > {
        new ScheduleEntry("Thu", "8am-10am", "Cataract and Glaucoma Screening")
      }
    }, {
      "Color Blindness",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Vision Check-ups")
      }
    }, {
      "Corneal Ulcers",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Emergency Eye Care")
      }
    }, {
      "Optic Neuritis",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Eye Health Consultation")
      }
    }, {
      "Eye Tumors",
      new List < ScheduleEntry > {
        new ScheduleEntry("Thu", "8am-10am", "Cataract and Glaucoma Screening")
      }
    }
  };

        private void LoadScheduleForDiagnosis(string diagnosis)
        {
            // Example dictionary of diagnoses and their schedule entries
            Dictionary<string, List<ScheduleEntry>> schedule = new Dictionary<string, List<ScheduleEntry>>()
    {
        {
      "Hypertension",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Routine Check-ups"),
        new ScheduleEntry("Wed", "1pm-3pm", "Chronic Illness Management")
      }
    }, {
      "Diabetes Mellitus",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Routine Check-ups"),
        new ScheduleEntry("Wed", "1pm-3pm", "Chronic Illness Management")
      }
    }, {
      "Hyperlipidemia",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Routine Check-ups")
      }
    }, {
      "Asthma",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Routine Check-ups"),
        new ScheduleEntry("Mon/Wed", "2pm-4pm", "Emergency Medical Consultation")
      }
    }, {
      "COPD",
      new List < ScheduleEntry > {
        new ScheduleEntry("Wed", "1pm-3pm", "Chronic Illness Management"),
        new ScheduleEntry("Mon/Wed", "2pm-4pm", "Emergency Medical Consultation")
      }
    }, {
      "GERD",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Routine Check-ups")
      }
    }, {
      "Upper Respiratory Infections",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed", "2pm-4pm", "Emergency Medical Consultation")
      }
    }, {
      "Anemia",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Routine Check-ups")
      }
    }, {
      "Thyroid Disorders",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Routine Check-ups")
      }
    }, {
      "Kidney Disease",
      new List < ScheduleEntry > {
        new ScheduleEntry("Wed", "1pm-3pm", "Chronic Illness Management")
      }
    }, {
      "Obesity",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Routine Check-ups")
      }
    }, {
      "Allergic Rhinitis",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Routine Check-ups")
      }
    }, {
      "Sleep Apnea",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Routine Check-ups")
      }
    }, {
      "Fatigue Syndromes",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Routine Check-ups")
      }
    }, {
      "Acid Reflux",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Routine Check-ups")
      }
    }, {
      "UTIs",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Routine Check-ups")
      }
    }, {
      "Mental Health Conditions",
      new List < ScheduleEntry > {
        new ScheduleEntry("Wed/Fri", "4pm-5pm", "Follow-up Consultation")
      }
    }, {
      "Infections",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed", "2pm-4pm", "Emergency Medical Consultation")
      }
    }, {
      "Chronic Pain Syndromes",
      new List < ScheduleEntry > {
        new ScheduleEntry("Wed", "1pm-3pm", "Chronic Illness Management")
      }
    },
    // Pediatrics
    {
      "Bronchiolitis",
      new List < ScheduleEntry > {
        new ScheduleEntry("Wed", "1pm-3pm", "Acute Illness and Infections")
      }
    }, {
      "Pneumonia",
      new List < ScheduleEntry > {
        new ScheduleEntry("Wed", "1pm-3pm", "Acute Illness and Infections")
      }
    }, {
      "Croup",
      new List < ScheduleEntry > {
        new ScheduleEntry("Wed", "1pm-3pm", "Acute Illness and Infections")
      }
    }, {
      "Gastroenteritis",
      new List < ScheduleEntry > {
        new ScheduleEntry("Wed", "1pm-3pm", "Acute Illness and Infections")
      }
    }, {
      "Ear Infections",
      new List < ScheduleEntry > {
        new ScheduleEntry("Wed", "1pm-3pm", "Acute Illness and Infections")
      }
    }, {
      "RSV Infection",
      new List < ScheduleEntry > {
        new ScheduleEntry("Wed", "1pm-3pm", "Acute Illness and Infections")
      }
    }, {
      "Diarrhea and Vomiting",
      new List < ScheduleEntry > {
        new ScheduleEntry("Wed", "1pm-3pm", "Acute Illness and Infections")
      }
    }, {
      "Fever and Sepsis",
      new List < ScheduleEntry > {
        new ScheduleEntry("Wed", "1pm-3pm", "Acute Illness and Infections")
      }
    }, {
      "ADHD",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed", "2pm-4pm", "Developmental and Behavioral Concerns")
      }
    }, {
      "ASD",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed", "2pm-4pm", "Developmental and Behavioral Concerns")
      }
    }, {
      "Eczema",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Acne and Eczema Treatment")
      }
    }, {
      "Childhood Obesity",
      new List < ScheduleEntry > {
        new ScheduleEntry("Wed/Fri", "4pm-5pm", "Well-child Check-ups")
      }
    }, {
      "Congenital Heart Defects",
      new List < ScheduleEntry > {
        new ScheduleEntry("Fri", "11am-12pm", "Pediatric Cardiology")
      }
    },
    // Orthopedics
    {
      "Fractures",
      new List < ScheduleEntry > {
        new ScheduleEntry("Tue/Thu/Sat", "11am-12pm", "Joint and Bone Health")
      }
    }, {
      "Osteoarthritis",
      new List < ScheduleEntry > {
        new ScheduleEntry("Fri", "10am-12pm", "Arthritis and Degenerative Joint Diseases")
      }
    }, {
      "Rheumatoid Arthritis",
      new List < ScheduleEntry > {
        new ScheduleEntry("Fri", "10am-12pm", "Arthritis and Degenerative Joint Diseases")
      }
    }, {
      "Spondylosis",
      new List < ScheduleEntry > {
        new ScheduleEntry("Tue/Thu", "12pm-1pm", "Spine and Back Issues")
      }
    }, {
      "Sciatica",
      new List < ScheduleEntry > {
        new ScheduleEntry("Tue/Thu", "12pm-1pm", "Spine and Back Issues")
      }
    }, {
      "Carpal Tunnel Syndrome",
      new List < ScheduleEntry > {
        new ScheduleEntry("Tue/Thu/Sat", "11am-12pm", "Joint and Bone Health")
      }
    }, {
      "Sprains and Strains",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed", "10am-12pm", "Sports Injury Assessments")
      }
    }, {
      "Bursitis",
      new List < ScheduleEntry > {
        new ScheduleEntry("Tue/Thu/Sat", "11am-12pm", "Joint and Bone Health")
      }
    }, {
      "Tendonitis",
      new List < ScheduleEntry > {
        new ScheduleEntry("Tue/Thu/Sat", "11am-12pm", "Joint and Bone Health")
      }
    }, {
      "Herniated Discs",
      new List < ScheduleEntry > {
        new ScheduleEntry("Tue/Thu", "12pm-1pm", "Spine and Back Issues")
      }
    }, {
      "Osteoporosis",
      new List < ScheduleEntry > {
        new ScheduleEntry("Fri", "10am-12pm", "Arthritis and Degenerative Joint Diseases")
      }
    },
    //Cardiology
    {
      "Coronary Artery Disease",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed", "10am-12pm", "Heart Disease Prevention")
      }
    }, {
      "Heart Attack",
      new List < ScheduleEntry > {
        new ScheduleEntry("Wed", "11am-1pm", "Acute Heart Conditions")
      }
    }, {
      "Heart Failure",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed", "12pm-2pm", "Chronic Heart Disease Management")
      }
    }, {
      "Arrhythmias",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed", "12pm-2pm", "Chronic Heart Disease Management")
      }
    }, {
      "Valvular Heart Diseases",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed", "10am-12pm", "Heart Disease Prevention")
      }
    }, {
      "Cardiomyopathy",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed", "12pm-2pm", "Chronic Heart Disease Management")
      }
    },
    //Dermatology
    {
      "Acne",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Acne and Eczema Treatment")
      }
    }, {
      "Psoriasis",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Acne and Eczema Treatment")
      }
    }, {
      "Rosacea",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Acne and Eczema Treatment")
      }
    }, {
      "Melanoma",
      new List < ScheduleEntry > {
        new ScheduleEntry("Wed", "2pm-4pm", "Skin Health and Routine Check-ups")
      }
    }, {
      "BCC",
      new List < ScheduleEntry > {
        new ScheduleEntry("Wed", "2pm-4pm", "Skin Health and Routine Check-ups")
      }
    }, {
      "SCC",
      new List < ScheduleEntry > {
        new ScheduleEntry("Wed", "2pm-4pm", "Skin Health and Routine Check-ups")
      }
    }, {
      "Hives",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Acne and Eczema Treatment")
      }
    }, {
      "Contact Dermatitis",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Fri", "10am-12pm", "Acne and Eczema Treatment")
      }
    },

    // Ophthalmology
    {
      "Cataracts",
      new List < ScheduleEntry > {
        new ScheduleEntry("Thu", "8am-10am", "Cataract and Glaucoma Screening")
      }
    }, {
      "Glaucoma",
      new List < ScheduleEntry > {
        new ScheduleEntry("Thu", "8am-10am", "Cataract and Glaucoma Screening")
      }
    }, {
      "Macular Degeneration",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Vision Check-ups")
      }
    }, {
      "Diabetic Retinopathy",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Vision Check-ups")
      }
    }, {
      "Retinal Detachment",
      new List < ScheduleEntry > {
        new ScheduleEntry("Thu", "8am-10am", "Cataract and Glaucoma Screening")
      }
    }, {
      "Conjunctivitis",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Eye Health Consultation")
      }
    }, {
      "Dry Eye Syndrome",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Eye Health Consultation")
      }
    }, {
      "Astigmatism",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Vision Check-ups")
      }
    }, {
      "Myopia",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Vision Check-ups")
      }
    }, {
      "Hyperopia",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Vision Check-ups")
      }
    }, {
      "Presbyopia",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Vision Check-ups")
      }
    }, {
      "Strabismus",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Vision Check-ups")
      }
    }, {
      "Amblyopia",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Vision Check-ups")
      }
    }, {
      "Eye Injuries",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Emergency Eye Care")
      }
    }, {
      "Keratoconus",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Vision Check-ups")
      }
    }, {
      "Uveitis",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Eye Health Consultation")
      }
    }, {
      "Pterygium",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Eye Health Consultation")
      }
    }, {
      "Blepharitis",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Eye Health Consultation")
      }
    }, {
      "Eye Infections",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Eye Health Consultation")
      }
    }, {
      "Retinal Vascular Occlusion",
      new List < ScheduleEntry > {
        new ScheduleEntry("Thu", "8am-10am", "Cataract and Glaucoma Screening")
      }
    }, {
      "Color Blindness",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Vision Check-ups")
      }
    }, {
      "Corneal Ulcers",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Emergency Eye Care")
      }
    }, {
      "Optic Neuritis",
      new List < ScheduleEntry > {
        new ScheduleEntry("Mon/Wed/Sat", "10am-12pm", "Eye Health Consultation")
      }
    }, {
      "Eye Tumors",
      new List < ScheduleEntry > {
        new ScheduleEntry("Thu", "8am-10am", "Cataract and Glaucoma Screening")
      }
    }
  };

            cbTimeAvailability.Items.Clear();

            // Check if the diagnosis exists in the dictionary
            if (schedule.ContainsKey(diagnosis))
            {
                var scheduleEntries = schedule[diagnosis];

                foreach (var entry in scheduleEntries)
                {
                    // Format the time availability and add to the ComboBox
                    string formattedTimeAvailability = FormatTimeAvailability(entry);
                    cbTimeAvailability.Items.Add(formattedTimeAvailability);
                }
            }
            else
            {
                MessageBox.Show("No schedule found for the selected diagnosis.");
            }
        }

        // Method to format the time availability
        private string FormatTimeAvailability(ScheduleEntry entry)
        {
            return $"{entry.Days} ({entry.Time}): {entry.Description}";
        }



        private int GetFloorBySpecialty(string specialty)
        {
            switch (specialty)
            {
                case "General Medicine":
                case "Cardiology":
                    return 1; // Floor 1
                case "Pediatrics":
                case "Dermatology":
                    return 2; // Floor 2
                case "Orthopedics":
                case "Ophthalmology":
                    return 3; // Floor 3
                default:
                    return 0; // Default case if no match (you could choose to handle this differently)
            }
        }






        private string FormatTime(string time)
        {
            string[] parts = time.Split('-');
            string startTime = FormatSingleTime(parts[0].Trim());
            string endTime = FormatSingleTime(parts[1].Trim());

            return $"{startTime} - {endTime}";
        }

        private string FormatSingleTime(string time)
        {
            string ampm = time.Substring(time.Length - 2).ToUpper(); // Get "AM" or "PM"
            string hour = time.Substring(0, time.Length - 2); // Get the hour part

            DateTime parsedTime = DateTime.ParseExact(hour + " " + ampm, "h tt", CultureInfo.InvariantCulture); // Parse time

            return parsedTime.ToString("hh:mmtt").ToUpper(); // Format as "10:00AM"
        }





        private void LoadRecommendedDoctor(string patientName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    FirstName, 
                    MiddleName, 
                    LastName, 
                    CASE WHEN Suffix = 'None' THEN '' ELSE Suffix END AS Suffix,
                    Specialty
                FROM Doctor
                WHERE FullName = (SELECT RecommendedDoctor FROM Patient WHERE FullName = @PatientName)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@PatientName", patientName);

                    SqlDataReader reader = cmd.ExecuteReader();

                    cbDocFullName.Items.Clear(); // Clear the dropdown before adding items

                    if (reader.Read())
                    {
                        string firstName = reader["FirstName"].ToString();
                        string middleName = reader["MiddleName"].ToString();
                        string lastName = reader["LastName"].ToString();
                        string suffix = reader["Suffix"].ToString();
                        string specialty = reader["Specialty"].ToString();

                        string fullName = FormatName(firstName, middleName, lastName, suffix);
                        string formattedDoctor = $"{fullName} ({specialty})";

                        cbDocFullName.Items.Add(formattedDoctor); // Add doctor to the dropdown
                        cbDocFullName.SelectedIndex = 0; // Auto-select the first doctor
                        CbDocFullName_SelectedIndexChanged(this, EventArgs.Empty); // Trigger the floor selection logic
                    }
                    else
                    {
                        MessageBox.Show("No recommended doctor found for the selected patient.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading recommended doctor: {ex.Message}");
            }
        }

        private void LoadAppointments()
        {
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    // SQL query to fetch appointment details, including TimeIn and TimeOut
                    string query = @"
                SELECT 
                    a.AppointmentID,
                    p.FullName AS PatientName,
                    d.FullName AS DoctorName,
                    a.AppointmentDate,
                    a.AppointmentStatus,
                    a.AppointmentFloor,
                    a.TimeAvailability,
                    a.TimeIn,
                    a.TimeOut
                FROM 
                    Appointment a
                INNER JOIN 
                    Patient p ON a.PatientID = p.PatientID
                INNER JOIN 
                    Doctor d ON a.DoctorID = d.DoctorID
                ORDER BY 
                    a.AppointmentDate";

                    var adapter = new SqlDataAdapter(query, conn);
                    var dt = new DataTable();
                    adapter.Fill(dt);

                    dgvAppointment.Rows.Clear();  // Clear previous rows

                    foreach (DataRow row in dt.Rows)
                    {
                        // Correctly map the fetched data to the appropriate DataGridView columns
                        dgvAppointment.Rows.Add(
                            row["AppointmentID"],
                            row["PatientName"],
                            row["DoctorName"],
                            row["AppointmentDate"],
                            row["AppointmentStatus"],
                            row["AppointmentFloor"],
                            row["TimeAvailability"],  // This should map to the 'Availability' column
                            row["TimeIn"],  // This should map to the 'Time In' column
                            row["TimeOut"]  // This should map to the 'Time Out' column
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading appointments: " + ex.Message);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                try
                {
                    // Retrieve the selected patient and doctor IDs
                    int patientId = GetPatientIdFromName(cbPatFullName.SelectedItem.ToString());
                    int doctorId = GetDoctorIdFromName(cbDocFullName.SelectedItem.ToString());

                    if (patientId == -1 || doctorId == -1)
                    {
                        MessageBox.Show("Invalid Patient or Doctor. Please select valid entries.");
                        return;
                    }

                    DateTime appointmentDate = dtpDate.Value;
                    string appointmentStatus = cbAppointmentStatus.SelectedItem.ToString();
                    string appointmentTime = cbTimeAvailability.SelectedItem.ToString();
                    string appointmentFloor = cbFloor.SelectedItem.ToString();
                    string timeAvailability = cbTimeAvailability.SelectedItem.ToString();

                    // Extract the time range from the selected TimeAvailability
                    string timeRange = ExtractTimeRange(timeAvailability);
                    if (string.IsNullOrEmpty(timeRange))
                    {
                        MessageBox.Show("No valid time range found in the selected availability.");
                        return;
                    }

                    // Extract the start and end times
                    (string timeIn, string timeOut) = ExtractTimes(timeRange);
                    if (string.IsNullOrEmpty(timeIn) || string.IsNullOrEmpty(timeOut))
                    {
                        MessageBox.Show("Invalid time slot selected.");
                        return;
                    }

                    // Set the TimeIn and TimeOut DateTimePickers
                    dtpTimeIn.Value = ConvertToDateTime(timeIn);
                    dtpTimeOut.Value = ConvertToDateTime(timeOut);

                    // Validate the appointment date against the doctor's availability
                    if (!IsValidAppointmentDate(appointmentDate, timeAvailability))
                    {
                        MessageBox.Show($"Invalid appointment date. The selected doctor is only available on: {timeAvailability}.");
                        return;
                    }

                    // Insert the appointment into the database
                    using (SqlConnection conn = new SqlConnection(ConnectionString))
                    {
                        conn.Open();
                        string query = @"
                    INSERT INTO Appointment 
                    (PatientID, DoctorID, AppointmentDate, AppointmentStatus, AppointmentFloor, 
                    TimeAvailability, TimeIn, TimeOut)
                    VALUES 
                    (@PatientID, @DoctorID, @AppointmentDate, @AppointmentStatus, @AppointmentFloor, 
                    @TimeAvailability, @TimeIn, @TimeOut)";

                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@PatientID", patientId);
                        cmd.Parameters.AddWithValue("@DoctorID", doctorId);
                        cmd.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
                        cmd.Parameters.AddWithValue("@AppointmentStatus", appointmentStatus);
                        cmd.Parameters.AddWithValue("@AppointmentFloor", appointmentFloor);
                        cmd.Parameters.AddWithValue("@TimeAvailability", timeAvailability);
                        cmd.Parameters.AddWithValue("@TimeIn", dtpTimeIn.Value.ToString("hh:mm tt"));
                        cmd.Parameters.AddWithValue("@TimeOut", dtpTimeOut.Value.ToString("hh:mm tt"));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Appointment successfully created!");

                        // Refresh the appointments grid after insert
                        LoadAppointments();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating appointment: {ex.Message}");
                }
            }
        }

        private string ExtractTimeRange(string timeAvailability)
        {
            // Regex to extract time range inside parentheses (e.g., "10am-12nn")
            var match = Regex.Match(timeAvailability, @"\((\d{1,2}[apm]+)-(\d{1,2}[apm]+)\)");
            return match.Success ? match.Groups[1].Value + "-" + match.Groups[2].Value : string.Empty;
        }

        private (string, string) ExtractTimes(string timeRange)
        {
            // Example timeRange: "10am-12nn"
            var match = Regex.Match(timeRange, @"(\d{1,2}[apm]+)-(\d{1,2}[apm]+)");

            if (match.Success)
            {
                string startTime = match.Groups[1].Value; // "10am"
                string endTime = match.Groups[2].Value;   // "12nn"

                // Convert to 12-hour format
                string formattedStartTime = ConvertTo12HourTime(startTime);
                string formattedEndTime = ConvertTo12HourTime(endTime);

                return (formattedStartTime, formattedEndTime);
            }

            return (string.Empty, string.Empty);
        }

        private string ConvertTo12HourTime(string time)
        {
            DateTime dt = DateTime.ParseExact(time, "htt", null);
            return dt.ToString("hh:mm tt");  // Format as "hh:mm am/pm"
        }

        


        private bool IsValidAppointmentDate(DateTime date, string timeAvailability)
        {
            // Get the day of the week for the selected date
            DayOfWeek dayOfWeek = date.DayOfWeek;

            // Check if the day matches the allowed days in the time availability
            if (timeAvailability.Contains("Mon") && dayOfWeek == DayOfWeek.Monday)
                return true;
            if (timeAvailability.Contains("Tue") && dayOfWeek == DayOfWeek.Tuesday)
                return true;
            if (timeAvailability.Contains("Wed") && dayOfWeek == DayOfWeek.Wednesday)
                return true;
            if (timeAvailability.Contains("Thu") && dayOfWeek == DayOfWeek.Thursday)
                return true;
            if (timeAvailability.Contains("Fri") && dayOfWeek == DayOfWeek.Friday)
                return true;
            if (timeAvailability.Contains("Sat") && dayOfWeek == DayOfWeek.Saturday)
                return true;
            if (timeAvailability.Contains("Sun") && dayOfWeek == DayOfWeek.Sunday)
                return true;

            // If no match, return false
            return false;
        }

        public class ScheduleEntry
        {
            public string Days { get; set; }
            public string Time { get; set; }
            public string Description { get; set; }

            public ScheduleEntry(string days, string time, string description)
            {
                Days = days;
                Time = time;
                Description = description;
            }
        }





        private int GetPatientIdFromName(string patientName)
        {
            // Extract only the name part (remove the diagnosis if it exists)
            string nameOnly = patientName.Split('(')[0].Trim();  // Everything before the first '(' is the name

            int patientId = -1;  // Default invalid ID

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT PatientID FROM Patient WHERE FullName = @PatientName"; // Use parameter for patient name
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PatientName", nameOnly);  // Use the extracted name without diagnosis

                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    patientId = Convert.ToInt32(result);
                }
            }

            return patientId;
        }



        private int GetDoctorIdFromName(string doctorName)
        {
            // Extract only the name part (remove the specialty if it exists)
            string nameOnly = doctorName.Split('(')[0].Trim();  // Everything before the first '(' is the name

            int doctorId = -1;  // Default invalid ID

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT DoctorID FROM Doctor WHERE FullName = @DoctorName"; // Use parameter for doctor name
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DoctorName", nameOnly);  // Use the extracted name without specialty

                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    doctorId = Convert.ToInt32(result);
                }
            }

            return doctorId;
        }



        private int GetSelectedAppointmentId()
        {
            int appointmentId = -1; // Default value if no appointment is selected

            // Check if a row is selected in the DataGridView
            if (dgvAppointment.SelectedRows.Count > 0)
            {
                // Get the AppointmentID from the selected row (assuming the first column is AppointmentID)
                appointmentId = Convert.ToInt32(dgvAppointment.SelectedRows[0].Cells["AppointmentID"].Value);
            }

            return appointmentId; // Return the AppointmentID (or -1 if no appointment is selected)
        }





        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                try
                {
                    int patientId = GetPatientIdFromName(cbPatFullName.SelectedItem.ToString());
                    int doctorId = GetDoctorIdFromName(cbDocFullName.SelectedItem.ToString());

                    if (patientId == -1 || doctorId == -1)
                    {
                        MessageBox.Show("Invalid Patient or Doctor. Please select valid entries.");
                        return;
                    }

                    DateTime appointmentDate = dtpDate.Value;
                    string appointmentStatus = cbAppointmentStatus.SelectedItem.ToString();
                    string appointmentTime = cbTimeAvailability.SelectedItem.ToString();
                    string appointmentFloor = cbFloor.SelectedItem.ToString();
                    string timeAvailability = cbTimeAvailability.SelectedItem.ToString();
                    DateTime timeIn = dtpTimeIn.Value;  // Example: DateTimePicker for TimeIn
                    DateTime timeOut = dtpTimeOut.Value; // Example: DateTimePicker for TimeOut
                    int appointmentId = GetSelectedAppointmentId();

                    // Validate the appointment date against the doctor's availability
                    if (!IsValidAppointmentDate(appointmentDate, timeAvailability))
                    {
                        MessageBox.Show($"Invalid appointment date. The selected doctor is only available on: {timeAvailability}.");
                        return;
                    }

                    using (SqlConnection conn = new SqlConnection(ConnectionString))
                    {
                        conn.Open();
                        string query = @"
        UPDATE Appointment 
        SET PatientID = @PatientID, DoctorID = @DoctorID, AppointmentDate = @AppointmentDate, 
            AppointmentStatus = @AppointmentStatus, AppointmentFloor = @AppointmentFloor, 
            AppointmentTime = @AppointmentTime, TimeAvailability = @TimeAvailability,
            TimeIn = @TimeIn, TimeOut = @TimeOut
        WHERE AppointmentID = @AppointmentID";

                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@PatientID", patientId);
                        cmd.Parameters.AddWithValue("@DoctorID", doctorId);
                        cmd.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
                        cmd.Parameters.AddWithValue("@AppointmentStatus", appointmentStatus);
                        cmd.Parameters.AddWithValue("@AppointmentFloor", appointmentFloor);
                        cmd.Parameters.AddWithValue("@AppointmentTime", appointmentTime);
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




        private void CbDocFullName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDocFullName.SelectedIndex != -1)
            {
                // Get the selected doctor's name (e.g., "Mark Crysler Baddo (General Medicine)")
                string selectedDoctor = cbDocFullName.SelectedItem.ToString();

                // Extract the specialty from the selected doctor's name
                string doctorSpecialty = selectedDoctor.Split('(')[1].Split(')')[0].Trim(); // Get the text inside the parentheses

                // Get the floor ID based on the doctor's specialty
                int floorID = GetFloorBySpecialty(doctorSpecialty);

                // Clear the current floor options
                cbFloor.Items.Clear();

                // Add the correct floor to the dropdown
                cbFloor.Items.Add($"{floorID}");

                // Automatically select the only available floor based on the specialty
                cbFloor.SelectedItem = $"{floorID}";
            }
        }

        



        private void InitializeFloorDropdown()
        {
            // Add floor options to the cbFloor dropdown
            cbFloor.Items.Clear();
            cbFloor.Items.Add("1");
            cbFloor.Items.Add("2");
            cbFloor.Items.Add("3");
        }





        // Validate form inputs
        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(cbPatFullName.Text))
            {
                MessageBox.Show("Please select a patient.");
                return false;
            }

            if (string.IsNullOrEmpty(cbDocFullName.Text))
            {
                MessageBox.Show("Please select a doctor.");
                return false;
            }

            if (dtpDate.Value < DateTime.Today)
            {
                MessageBox.Show("Appointment date cannot be in the past.");
                return false;
            }

            if (string.IsNullOrEmpty(cbAppointmentStatus.Text))
            {
                MessageBox.Show("Please select an appointment status.");
                return false;
            }

            if (string.IsNullOrEmpty(cbFloor.Text))
            {
                MessageBox.Show("Please select a floor.");
                return false;
            }

            if (string.IsNullOrEmpty(cbTimeAvailability.Text))
            {
                MessageBox.Show("Please select time availability.");
                return false;
            }

            return true;
        }

    }
}
