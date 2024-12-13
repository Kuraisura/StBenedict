CREATE TABLE [dbo].[PatientProcedures] (
    [ProcedureID] INT IDENTITY(1, 1) PRIMARY KEY,
    [PatientID] INT NOT NULL,
    [Diagnosis] NVARCHAR(255),
    [ProcedureName] NVARCHAR(255),
    [Prescription] NVARCHAR(255),
    [Dosage] NVARCHAR(255),
    [Frequency] NVARCHAR(255),
    [Notes] NVARCHAR(MAX),
    FOREIGN KEY ([PatientID]) REFERENCES [dbo].[Patient]([PatientID])
);