using System;
using System.Collections.Generic;

namespace MedicalApp
{
    public class Prescription
    {
        public static Dictionary<string, List<string>> DiseasePrescriptions = new Dictionary<string, List<string>>()
        {
            // General Medicine 
            { "Hypertension", new List<string> { "Amlodipine", "5mg", "daily", "No special notes" } },
            { "Diabetes Mellitus", new List<string> { "Metformin", "500mg", "twice daily", "For blood sugar control" } },
            { "Hyperlipidemia", new List<string> { "Atorvastatin", "20mg", "daily", "For lowering cholesterol" } },
            { "Asthma", new List<string> { "Salbutamol", "Inhaler as needed", "PRN", "For bronchodilation" } },
            { "COPD", new List<string> { "Tiotropium", "Inhaler once daily", "daily", "For long-term bronchodilation" } },
            { "GERD", new List<string> { "Omeprazole", "20mg", "daily", "For reducing gastric acid" } },
            { "Upper Respiratory Infections", new List<string> { "Amoxicillin", "500mg", "three times daily", "For bacterial infection" } },
            { "Anemia", new List<string> { "Ferrous sulfate", "325mg", "daily", "To increase iron levels" } },
            { "Thyroid disorders", new List<string> { "Levothyroxine", "50mcg", "daily", "For thyroid hormone replacement" } },
            { "Kidney Disease", new List<string> { "Losartan", "50mg", "daily", "For kidney protection and blood pressure control" } },
            { "Obesity", new List<string> { "Orlistat", "120mg", "as directed", "For weight management" } },
            { "Allergic Rhinitis", new List<string> { "Cetirizine", "10mg", "daily", "For allergy relief" } },
            { "Sleep Apnea", new List<string> { "CPAP therapy", "No dosage", "As prescribed", "For managing sleep apnea" } },
            { "Fatigue Syndromes", new List<string> { "Multivitamins", "No dosage", "Daily", "For general well-being" } },
            { "Acid Reflux", new List<string> { "Ranitidine", "150mg", "twice daily", "For managing acid reflux" } },
            { "UTIs", new List<string> { "Nitrofurantoin", "100mg", "twice daily", "For treating urinary tract infections" } },
            { "Mental Health Conditions", new List<string> { "Sertraline", "50mg", "daily", "For managing depression and anxiety" } },
            { "Infections", new List<string> { "Amoxicillin/Clavulanate", "875mg/125mg", "twice daily", "For treating infections" } },
            { "Chronic Pain Syndromes", new List<string> { "Gabapentin", "300mg", "daily", "For nerve pain management" } },

            // Pediatrics
            { "Bronchiolitis", new List<string> { "Supportive care", "No dosage", "As needed", "Monitor for signs of respiratory distress" } },
            { "Pneumonia", new List<string> { "Amoxicillin", "40mg/kg", "daily", "For bacterial pneumonia" } },
            { "Croup", new List<string> { "Dexamethasone", "0.15mg/kg", "As prescribed", "For reducing inflammation in the airways" } },
            { "Gastroenteritis", new List<string> { "ORS", "No dosage", "As directed", "For hydration support" } },
            { "Ear Infections", new List<string> { "Amoxicillin", "90mg/kg/day", "daily", "For bacterial ear infection" } },
            { "RSV Infection", new List<string> { "Supportive care", "No dosage", "As needed", "For respiratory support" } },
            { "Diarrhea and Vomiting", new List<string> { "ORS", "No dosage", "As directed", "For fluid and electrolyte balance" } },
            { "Fever and Sepsis", new List<string> { "IV antibiotics", "No dosage", "As directed", "For bacterial infections" } },
            { "ADHD", new List<string> { "Methylphenidate", "5mg", "daily", "For attention and hyperactivity control" } },
            { "ASD", new List<string> { "Speech therapy", "No dosage", "As prescribed", "For language development" } },
            { "Eczema", new List<string> { "Topical corticosteroids", "No dosage", "As needed", "For managing skin inflammation" } },
            { "Childhood Obesity", new List<string> { "Dietary counseling", "No dosage", "As directed", "For promoting healthy weight" } },
            { "Congenital heart defects", new List<string> { "Surgical correction", "No dosage", "As needed", "For surgical intervention" } },

            // Orthopedics
            { "Fractures", new List<string> { "Immobilization", "No dosage", "As prescribed", "For fracture management" } },
            { "Osteoarthritis", new List<string> { "NSAIDs", "No dosage", "As directed", "For pain and inflammation" } },
            { "Rheumatoid Arthritis", new List<string> { "Methotrexate", "15mg", "weekly", "For disease-modifying therapy" } },
            { "Spondylosis", new List<string> { "Physical therapy", "No dosage", "As directed", "For spine mobility and pain relief" } },
            { "Sciatica", new List<string> { "Gabapentin", "300mg", "daily", "For nerve pain relief" } },
            { "Carpal Tunnel Syndrome", new List<string> { "Wrist splints", "No dosage", "As needed", "For wrist support" } },
            { "Sprains and Strains", new List<string> { "RICE method", "No dosage", "As needed", "For rest and recovery" } },
            { "Bursitis", new List<string> { "NSAIDs", "No dosage", "As directed", "For pain and swelling reduction" } },
            { "Tendonitis", new List<string> { "Topical NSAIDs", "No dosage", "As directed", "For tendon inflammation" } },
            { "Herniated Discs", new List<string> { "Physiotherapy", "No dosage", "As prescribed", "For rehabilitation" } },
            { "Osteoporosis", new List<string> { "Calcium", "No dosage", "Daily", "For bone health" } },

            // Cardiology
            { "Coronary Artery Disease", new List<string> { "Aspirin", "81mg", "daily", "For preventing blood clots" } },
            { "Heart Attack", new List<string> { "Nitroglycerin", "as needed", "PRN", "For chest pain relief" } },
            { "Heart Failure", new List<string> { "Furosemide", "40mg", "daily", "For fluid management" } },
            { "Arrhythmias", new List<string> { "Amiodarone", "200mg", "daily", "For rhythm control" } },
            { "Valvular Heart Diseases", new List<string> { "Surgical repair", "No dosage", "As needed", "For valve replacement or repair" } },
            { "Cardiomyopathy", new List<string> { "Beta-blockers", "No dosage", "Daily", "For heart function support" } },

            // Dermatology
            { "Acne", new List<string> { "Benzoyl peroxide", "gel", "Daily", "For acne control" } },
            { "Psoriasis", new List<string> { "Topical corticosteroids", "No dosage", "As needed", "For controlling flare-ups" } },
            { "Rosacea", new List<string> { "Topical metronidazole", "No dosage", "As directed", "For managing rosacea" } },
            { "Melanoma", new List<string> { "Surgical excision", "No dosage", "As needed", "For tumor removal" } },
            { "BCC", new List<string> { "Surgical excision", "No dosage", "As needed", "For basal cell carcinoma treatment" } },
            { "SCC", new List<string> { "Mohs surgery", "No dosage", "As needed", "For squamous cell carcinoma removal" } },
            { "Hives", new List<string> { "Antihistamines", "No dosage", "As needed", "For allergic reactions" } },
            { "Contact Dermatitis", new List<string> { "Topical corticosteroids", "No dosage", "As needed", "For reducing skin inflammation" } },

            // Ophthalmology
            { "Cataracts", new List<string> { "No Medication Is Needed", "No dosage", "No Frequency", "For surgical intervention" } },
            { "Glaucoma", new List<string> { "Latanoprost", "0.005%", "daily", "For lowering intraocular pressure" } },
            { "Macular Degeneration", new List<string> { "Anti-VEGF", "injections", "As prescribed", "For slowing disease progression" } },
            { "Diabetic Retinopathy", new List<string> { "Anti-VEGF", "injections", "As prescribed", "For preventing vision loss" } },
            { "Retinal Detachment", new List<string> { "No Medication Is Needed", "No dosage", "No Frequency", "Requires surgical intervention" } },
            { "Conjunctivitis", new List<string> { "Moxifloxacin", "0.5%", "eye drops", "For bacterial eye infection" } },
            { "Dry Eye Syndrome", new List<string> { "Artificial tears", "No dosage", "As needed", "For moisture and lubrication" } },
            { "Astigmatism", new List<string> { "No Medication Is Needed", "No dosage", "No Frequency", "Corrective lenses may be used" } },
            { "Myopia", new List<string> { "No Medication Is Needed", "No dosage", "No Frequency", "Corrective lenses may be used" } },
            { "Hyperopia", new List<string> { "No Medication Is Needed", "No dosage", "No Frequency", "Corrective lenses may be used" } },
            { "Presbyopia", new List<string> { "No Medication Is Needed", "No dosage", "No Frequency", "Corrective lenses may be used" } },
            { "Strabismus", new List<string> { "No Medication Is Needed", "No dosage", "No Frequency", "May require surgical correction" } },
            { "Amblyopia", new List<string> { "No Medication Is Needed", "No dosage", "No Frequency", "May require vision therapy" } },
            { "Eye Injuries", new List<string> { "Ciprofloxacin", "0.3%", "eye drops", "For eye infection prevention" } },
            { "Keratoconus", new List<string> { "No Medication Is Needed", "No dosage", "No Frequency", "May require contact lenses or surgery" } },
            { "Uveitis", new List<string> { "Prednisolone acetate", "1%", "eye drops", "For inflammation control" } },
            { "Pterygium", new List<string> { "Artificial tears", "No dosage", "As needed", "For eye lubrication" } },
            { "Blepharitis", new List<string> { "Erythromycin", "0.5%", "ointment", "For eyelid inflammation" } },
            { "Eye Infections", new List<string> { "Ciprofloxacin", "0.3%", "eye drops", "For treating bacterial eye infections" } },
            { "Retinal Vascular Occlusion", new List<string> { "No Medication Is Needed", "No dosage", "No Frequency", "Requires surgical or laser intervention" } },
            { "Color Blindness", new List<string> { "No Medication Is Needed", "No dosage", "No Frequency", "No specific treatment available" } },
            { "Corneal Ulcers", new List<string> { "Moxifloxacin", "0.5%", "eye drops", "For treating corneal infection" } },
            { "Optic Neuritis", new List<string> { "Intravenous methylprednisolone", "No dosage", "As prescribed", "For treating optic nerve inflammation" } },
            { "Eye Tumors", new List<string> { "No Medication Is Needed", "No dosage", "No Frequency", "Requires surgical or oncological management" } }
        };
    }
}
