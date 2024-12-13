using System;
using System.Collections.Generic;

namespace StBenedict
{
    internal class PrescriptionCost
    {
        // Static dictionary mapping medications to their prices
        private static readonly Dictionary<string, decimal> MedicationPrices = new Dictionary<string, decimal>
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
            { "Levothyroxine 50mcg daily", 10.00m },
            { "Losartan 50mg daily", 14.00m },
            { "Low protein diet", 30.00m },
            { "Lifestyle modifications", 0.00m },
            { "Orlistat 120mg as directed", 40.00m },
            { "Cetirizine 10mg daily", 5.00m },
            { "Nasal corticosteroids", 20.00m },
            { "CPAP therapy", 300.00m },
            { "Weight management", 0.00m },
            { "Multivitamins", 10.00m },
            { "Regular exercise", 0.00m },
            { "Ranitidine 150mg twice daily", 15.00m },
            { "Nitrofurantoin 100mg twice daily", 18.00m },
            { "Hydration therapy", 0.00m },
            { "Sertraline 50mg daily", 25.00m },
            { "Psychotherapy sessions", 100.00m },
            { "Amoxicillin/Clavulanate 875mg/125mg twice daily", 45.00m },
            { "Gabapentin 300mg daily", 20.00m },
            { "Physiotherapy", 60.00m },

            // Pediatrics
            { "Supportive care", 0.00m },
            { "Saline nasal drops", 6.00m },
            { "Amoxicillin 40mg/kg daily", 18.00m },
            { "Dexamethasone 0.15mg/kg", 10.00m },
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
        }
}
