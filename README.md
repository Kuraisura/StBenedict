# 🏥 St. Benedict

**Hospital Management System** · `Windows Forms`

Hospital management system for managing doctors, patients, appointments, and medical billing.

## Screenshots

### System initialization — the loading screen with stethoscope icon signals medical context while the database connects. Progress bar prevents users from thinking the app has frozen.

![System initialization — the loading screen with stethoscope icon signals medical context while the database connects. Progress bar prevents users from thinking the app has frozen.](screenshots/1.png)

### Secure staff access — the split-layout login separates branding (left) from credentials (right). Only authorized hospital staff can access patient records, which is critical for HIPAA-equivalent data privacy.

![Secure staff access — the split-layout login separates branding (left) from credentials (right). Only authorized hospital staff can access patient records, which is critical for HIPAA-equivalent data privacy.](screenshots/2.png)

### Doctor directory management — the form registers new physicians with specialization and login credentials. The empty table indicates no doctors have been added yet; this must be populated before appointments can be scheduled.

![Doctor directory management — the form registers new physicians with specialization and login credentials. The empty table indicates no doctors have been added yet; this must be populated before appointments can be scheduled.](screenshots/3.png)

### Patient intake — captures demographic and medical information (name, age, diagnosis, DOB) and links each patient to a recommended doctor. This is the entry point for all patient records in the system.

![Patient intake — captures demographic and medical information (name, age, diagnosis, DOB) and links each patient to a recommended doctor. This is the entry point for all patient records in the system.](screenshots/4.png)

### Appointment scheduler — connects patients with doctors by date, time, and floor. Status tracking (pending/confirmed/completed) lets reception staff manage the daily patient flow efficiently.

![Appointment scheduler — connects patients with doctors by date, time, and floor. Status tracking (pending/confirmed/completed) lets reception staff manage the daily patient flow efficiently.](screenshots/5.png)

### Billing & payment — calculates treatment costs (surgery, prescription, procedure), generates receipts, and processes payments. The Pay/Receipt buttons complete the financial cycle for each patient visit.

![Billing & payment — calculates treatment costs (surgery, prescription, procedure), generates receipts, and processes payments. The Pay/Receipt buttons complete the financial cycle for each patient visit.](screenshots/6.png)

## Features

- Admin login with secure authentication
- Doctor registration and management
- Patient registration with diagnosis tracking
- Appointment scheduling with status tracking
- Medical billing with receipts and payment processing

## Tech Stack

- C#
- WinForms
- .NET
- SQL Server

## About

A Windows Forms hospital management application featuring doctor and patient databases, appointment scheduling, and a medical billing system with receipt generation. Built with a clean split-layout login and sidebar navigation.

---

Built by [Mark Crysler Baddo](https://github.com/Kuraisura) · [Portfolio](https://kuraisler.xyz)
