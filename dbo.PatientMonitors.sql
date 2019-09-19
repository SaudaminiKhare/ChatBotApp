CREATE TABLE [dbo].[PatientMonitors] (
    [Model]      VARCHAR (10) NOT NULL,
    [Features] VARCHAR (MAX) NOT NULL,
    FOREIGN KEY ([Model]) REFERENCES [dbo].[Monitors] ([Model]), 
    CONSTRAINT [PK_PatientMonitors] PRIMARY KEY ([Model])
);
