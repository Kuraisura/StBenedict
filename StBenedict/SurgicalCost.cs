using System;
using System.Collections.Generic;

namespace StBenedict
{
    internal class SurgicalCost
    {
        public static Dictionary<string, decimal> Costs = new Dictionary<string, decimal>
        {
            // General Medicine
            { "Hypertension", 15000.00m }, // Renal artery stenting
            { "Diabetes Mellitus", 120000.00m }, // Pancreas transplantation
            { "Hyperlipidemia", 5000.00m }, // Liposuction (for severe lipid deposits)
            { "Asthma", 20000.00m }, // Bronchial thermoplasty
            { "COPD", 80000.00m }, // Lung volume reduction surgery (LVRS)
            { "GERD", 30000.00m }, // Fundoplication
            { "Upper Respiratory Infections", 15000.00m }, // Endoscopic sinus surgery
            { "Anemia", 25000.00m }, // Splenectomy
            { "Thyroid Disorders", 18000.00m }, // Thyroidectomy
            { "Kidney Disease", 300000.00m }, // Kidney transplant
            { "Obesity", 25000.00m }, // Bariatric surgery
            { "Allergic Rhinitis", 15000.00m }, // Endoscopic sinus surgery
            { "Sleep Apnea", 20000.00m }, // Uvulopalatopharyngoplasty (UPPP)
            { "Fatigue Syndromes", 0.00m }, // None
            { "Acid Reflux", 30000.00m }, // Fundoplication
            { "UTIs", 35000.00m }, // Ureteral reimplantation
            { "Mental Health Conditions", 100000.00m }, // Deep brain stimulation
            { "Infections", 10000.00m }, // Abscess drainage
            { "Chronic Pain Syndromes", 75000.00m }, // Spinal cord stimulation

            // Pediatrics
            { "Bronchiolitis", 12000.00m }, // Bronchoscopy
            { "Pneumonia", 20000.00m }, // Thoracentesis or decortication
            { "Croup", 15000.00m }, // Tracheostomy
            { "Gastroenteritis", 0.00m }, // None
            { "Ear Infections", 8000.00m }, // Tympanostomy
            { "RSV Infection", 12000.00m }, // Bronchoscopy
            { "Diarrhea and Vomiting", 0.00m }, // None
            { "Fever and Sepsis", 0.00m }, // None
            { "ADHD", 0.00m }, // None
            { "ASD", 0.00m }, // None
            { "Eczema", 0.00m }, // None
            { "Childhood Obesity", 25000.00m }, // Bariatric surgery
            { "Congenital Heart Defects", 150000.00m }, // Corrective heart surgery

            // Orthopedics
            { "Fractures", 20000.00m }, // Open reduction and internal fixation (ORIF)
            { "Osteoarthritis", 50000.00m }, // Total joint replacement
            { "Rheumatoid Arthritis", 40000.00m }, // Synovectomy or joint replacement
            { "Spondylosis", 70000.00m }, // Spinal decompression surgery
            { "Sciatica", 30000.00m }, // Microdiscectomy
            { "Carpal Tunnel Syndrome", 10000.00m }, // Carpal tunnel release surgery
            { "Sprains and Strains", 0.00m }, // None
            { "Bursitis", 15000.00m }, // Bursectomy
            { "Tendonitis", 20000.00m }, // Tendon repair
            { "Herniated Discs", 40000.00m }, // Laminectomy or discectomy
            { "Osteoporosis", 25000.00m }, // Vertebroplasty or kyphoplasty

            // Cardiology
            { "Coronary Artery Disease", 120000.00m }, // Coronary artery bypass grafting (CABG)
            { "Heart Attack", 100000.00m }, // Emergency angioplasty or CABG
            { "Heart Failure", 300000.00m }, // LVAD implantation or heart transplant
            { "Arrhythmias", 60000.00m }, // Pacemaker or ICD implantation
            { "Valvular Heart Diseases", 150000.00m }, // Valve replacement or repair
            { "Cardiomyopathy", 300000.00m }, // Heart transplant

            // Dermatology
            { "Acne", 5000.00m }, // Laser resurfacing or surgical excision of cysts
            { "Psoriasis", 0.00m }, // None
            { "Rosacea", 7000.00m }, // Laser therapy
            { "Melanoma", 25000.00m }, // Wide local excision or sentinel lymph node biopsy
            { "BCC", 10000.00m }, // Mohs surgery
            { "SCC", 12000.00m }, // Excision or Mohs surgery
            { "Hives", 0.00m }, // None
            { "Contact Dermatitis", 0.00m }, // None

            // Ophthalmology
            { "Cataracts", 15000.00m }, // Cataract surgery
            { "Glaucoma", 30000.00m }, // Trabeculectomy or shunt implantation
            { "Macular Degeneration", 20000.00m }, // Laser photocoagulation
            { "Diabetic Retinopathy", 25000.00m }, // Vitrectomy
            { "Retinal Detachment", 40000.00m }, // Scleral buckle or vitrectomy
            { "Conjunctivitis", 0.00m }, // None
            { "Dry Eye Syndrome", 5000.00m }, // Punctal occlusion
            { "Astigmatism", 8000.00m }, // LASIK surgery
            { "Myopia", 8000.00m }, // LASIK surgery
            { "Hyperopia", 8000.00m }, // LASIK surgery
            { "Presbyopia", 10000.00m }, // Presbyopia-correcting lens implants
            { "Strabismus", 15000.00m }, // Strabismus surgery
            { "Amblyopia", 0.00m }, // None
            { "Eye Injuries", 20000.00m }, // Corneal repair or enucleation
            { "Keratoconus", 30000.00m }, // Corneal transplant
            { "Uveitis", 0.00m }, // None
            { "Pterygium", 7000.00m }, // Pterygium excision
            { "Blepharitis", 0.00m }, // None
            { "Eye Infections", 25000.00m }, // Vitrectomy
            { "Retinal Vascular Occlusion", 30000.00m }, // Vitrectomy
            { "Color Blindness", 0.00m }, // None
            { "Corneal Ulcers", 30000.00m }, // Corneal transplant
            { "Optic Neuritis", 0.00m }, // None
            { "Eye Tumors", 50000.00m } // Enucleation or orbital exenteration
        };
    }
}
