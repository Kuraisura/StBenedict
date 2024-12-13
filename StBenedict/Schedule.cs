using System;
using System.Collections.Generic;

namespace StBenedict
{
    internal class Schedule
    {
        public Dictionary<string, List<string>> DiseaseSchedule { get; private set; }

        public Schedule()
        {
            DiseaseSchedule = new Dictionary<string, List<string>>
            {
                // General Medicine
                { "Hypertension", new List<string> { "Mon/Wed/Fri (10am-12nn): Routine Check-ups", "Wed (1pm-3pm): Chronic Illness Management" } },
                { "Diabetes Mellitus", new List<string> { "Mon/Wed/Fri (10am-12nn): Routine Check-ups", "Wed (1pm-3pm): Chronic Illness Management" } },
                { "Hyperlipidemia", new List<string> { "Mon/Wed/Fri (10am-12nn): Routine Check-ups" } },
                { "Asthma", new List<string> { "Mon/Wed/Fri (10am-12nn): Routine Check-ups", "Mon/Wed (2pm-4pm): Emergency Medical Consultation" } },
                { "COPD", new List<string> { "Wed (1pm-3pm): Chronic Illness Management", "Mon/Wed (2pm-4pm): Emergency Medical Consultation" } },
                { "GERD", new List<string> { "Mon/Wed/Fri (10am-12nn): Routine Check-ups" } },
                { "Upper Respiratory Infections", new List<string> { "Mon/Wed (2pm-4pm): Emergency Medical Consultation" } },
                { "Anemia", new List<string> { "Mon/Wed/Fri (10am-12nn): Routine Check-ups" } },
                { "Thyroid Disorders", new List<string> { "Mon/Wed/Fri (10am-12nn): Routine Check-ups" } },
                { "Kidney Disease", new List<string> { "Wed (1pm-3pm): Chronic Illness Management" } },
                { "Obesity", new List<string> { "Mon/Wed/Fri (10am-12nn): Routine Check-ups" } },
                { "Allergic Rhinitis", new List<string> { "Mon/Wed/Fri (10am-12nn): Routine Check-ups" } },
                { "Sleep Apnea", new List<string> { "Mon/Wed/Fri (10am-12nn): Routine Check-ups" } },
                { "Fatigue Syndromes", new List<string> { "Mon/Wed/Fri (10am-12nn): Routine Check-ups" } },
                { "Acid Reflux", new List<string> { "Mon/Wed/Fri (10am-12nn): Routine Check-ups" } },
                { "UTIs", new List<string> { "Mon/Wed/Fri (10am-12nn): Routine Check-ups" } },
                { "Mental Health Conditions", new List<string> { "Wed/Fri (4pm-5pm): Follow-up Consultation" } },
                { "Infections", new List<string> { "Mon/Wed (2pm-4pm): Emergency Medical Consultation" } },
                { "Chronic Pain Syndromes", new List<string> { "Wed (1pm-3pm): Chronic Illness Management" } },

                // Pediatrics
                { "Bronchiolitis", new List<string> { "Wed (1pm-3pm): Acute Illness and Infections" } },
                { "Pneumonia", new List<string> { "Wed (1pm-3pm): Acute Illness and Infections" } },
                { "Croup", new List<string> { "Wed (1pm-3pm): Acute Illness and Infections" } },
                { "Gastroenteritis", new List<string> { "Wed (1pm-3pm): Acute Illness and Infections" } },
                { "Ear Infections", new List<string> { "Wed (1pm-3pm): Acute Illness and Infections" } },
                { "RSV Infection", new List<string> { "Wed (1pm-3pm): Acute Illness and Infections" } },
                { "Diarrhea and Vomiting", new List<string> { "Wed (1pm-3pm): Acute Illness and Infections" } },
                { "Fever and Sepsis", new List<string> { "Wed (1pm-3pm): Acute Illness and Infections" } },
                { "ADHD", new List<string> { "Mon/Wed (2pm-4pm): Developmental and Behavioral Concerns" } },
                { "ASD", new List<string> { "Mon/Wed (2pm-4pm): Developmental and Behavioral Concerns" } },
                { "Eczema", new List<string> { "Mon/Wed/Fri (10am-12nn): Acne and Eczema Treatment" } },
                { "Childhood Obesity", new List<string> { "Wed/Fri (4pm-5pm): Well-child Check-ups" } },
                { "Congenital Heart Defects", new List<string> { "Fri (11am-12nn): Pediatric Cardiology" } },

                // Orthopedics
                { "Fractures", new List<string> { "Tue/Thu/Sat (11am-12nn): Joint and Bone Health" } },
                { "Osteoarthritis", new List<string> { "Fri (10am-12nn): Arthritis and Degenerative Joint Diseases" } },
                { "Rheumatoid Arthritis", new List<string> { "Fri (10am-12nn): Arthritis and Degenerative Joint Diseases" } },
                { "Spondylosis", new List<string> { "Tue/Thu (12nn-1pm): Spine and Back Issues" } },
                { "Sciatica", new List<string> { "Tue/Thu (12nn-1pm): Spine and Back Issues" } },
                { "Carpal Tunnel Syndrome", new List<string> { "Tue/Thu/Sat (11am-12nn): Joint and Bone Health" } },
                { "Sprains and Strains", new List<string> { "Mon/Wed (10am-12nn): Sports Injury Assessments" } },
                { "Bursitis", new List<string> { "Tue/Thu/Sat (11am-12nn): Joint and Bone Health" } },
                { "Tendonitis", new List<string> { "Tue/Thu/Sat (11am-12nn): Joint and Bone Health" } },
                { "Herniated Discs", new List<string> { "Tue/Thu (12nn-1pm): Spine and Back Issues" } },
                { "Osteoporosis", new List<string> { "Fri (10am-12nn): Arthritis and Degenerative Joint Diseases" } },

                // Cardiology
                { "Coronary Artery Disease", new List<string> { "Mon/Wed (10am-12nn): Heart Disease Prevention" } },
                { "Heart Attack", new List<string> { "Wed (11am-1pm): Acute Heart Conditions" } },
                { "Heart Failure", new List<string> { "Mon/Wed (12nn-2pm): Chronic Heart Disease Management" } },
                { "Arrhythmias", new List<string> { "Mon/Wed (12nn-2pm): Chronic Heart Disease Management" } },
                { "Valvular Heart Diseases", new List<string> { "Mon/Wed (10am-12nn): Heart Disease Prevention" } },
                { "Cardiomyopathy", new List<string> { "Mon/Wed (12nn-2pm): Chronic Heart Disease Management" } },

                // Dermatology
                { "Acne", new List<string> { "Mon/Wed/Fri (10am-12nn): Acne and Eczema Treatment" } },
                { "Psoriasis", new List<string> { "Mon/Wed/Fri (10am-12nn): Acne and Eczema Treatment" } },
                { "Rosacea", new List<string> { "Mon/Wed/Fri (10am-12nn): Acne and Eczema Treatment" } },
                { "Melanoma", new List<string> { "Wed (2pm-4pm): Skin Health and Routine Check-ups" } },
                { "BCC", new List<string> { "Wed (2pm-4pm): Skin Health and Routine Check-ups" } },
                { "SCC", new List<string> { "Wed (2pm-4pm): Skin Health and Routine Check-ups" } },
                { "Hives", new List<string> { "Mon/Wed/Fri (10am-12nn): Acne and Eczema Treatment" } },
                { "Contact Dermatitis", new List<string> { "Mon/Wed/Fri (10am-12nn): Acne and Eczema Treatment" } },

                // Ophthalmology
                { "Cataracts", new List<string> { "Thu (8am-10am): Cataract and Glaucoma Screening" } },
                { "Glaucoma", new List<string> { "Thu (8am-10am): Cataract and Glaucoma Screening" } },
                { "Macular Degeneration", new List<string> { "Mon/Wed/Sat (10am-12nn): Vision Check-ups" } },
                { "Diabetic Retinopathy", new List<string> { "Mon/Wed/Sat (10am-12nn): Vision Check-ups" } },
                { "Retinal Detachment", new List<string> { "Thu (8am-10am): Cataract and Glaucoma Screening" } },
                { "Conjunctivitis", new List<string> { "Mon/Wed/Sat (10am-12nn): Eye Health Consultation" } },
                { "Dry Eye Syndrome", new List<string> { "Mon/Wed/Sat (10am-12nn): Eye Health Consultation" } },
                { "Astigmatism", new List<string> { "Mon/Wed/Sat (10am-12nn): Vision Check-ups" } },
                { "Myopia", new List<string> { "Mon/Wed/Sat (10am-12nn): Vision Check-ups" } },
                { "Hyperopia", new List<string> { "Mon/Wed/Sat (10am-12nn): Vision Check-ups" } },
                { "Presbyopia", new List<string> { "Mon/Wed/Sat (10am-12nn): Vision Check-ups" } },
                { "Strabismus", new List<string> { "Mon/Wed/Sat (10am-12nn): Vision Check-ups" } },
                { "Amblyopia", new List<string> { "Mon/Wed/Sat (10am-12nn): Vision Check-ups" } },
                { "Eye Injuries", new List<string> { "Mon/Wed/Sat (10am-12nn): Emergency Eye Care" } },
                { "Keratoconus", new List<string> { "Mon/Wed/Sat (10am-12nn): Vision Check-ups" } },
                { "Uveitis", new List<string> { "Mon/Wed/Sat (10am-12nn): Eye Health Consultation" } },
                { "Pterygium", new List<string> { "Mon/Wed/Sat (10am-12nn): Eye Health Consultation" } },
                { "Blepharitis", new List<string> { "Mon/Wed/Sat (10am-12nn): Eye Health Consultation" } },
                { "Eye Infections", new List<string> { "Mon/Wed/Sat (10am-12nn): Eye Health Consultation" } },
                { "Retinal Vascular Occlusion", new List<string> { "Thu (8am-10am): Cataract and Glaucoma Screening" } },
                { "Color Blindness", new List<string> { "Mon/Wed/Sat (10am-12nn): Vision Check-ups" } },
                { "Corneal Ulcers", new List<string> { "Mon/Wed/Sat (10am-12nn): Emergency Eye Care" } },
                { "Optic Neuritis", new List<string> { "Mon/Wed/Sat (10am-12nn): Eye Health Consultation" } },
                { "Eye Tumors", new List<string> { "Thu (8am-10am): Cataract and Glaucoma Screening" } }
            };
        }
    }
}
