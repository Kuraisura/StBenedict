using System.Collections.Generic;
using System;

public class MedicalTreatmentCosts
{
    public Dictionary<string, List<Tuple<string, decimal>>> DiseaseTreatments = new Dictionary<string, List<Tuple<string, decimal>>>
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
