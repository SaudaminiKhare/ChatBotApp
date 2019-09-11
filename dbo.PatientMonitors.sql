CREATE TABLE [dbo].[PatientMonitors] (
    [Model]      VARCHAR (10) NOT NULL,
    [Feature_ID] VARCHAR (10) NOT NULL,
	CONSTRAINT PK_Monitor PRIMARY KEY (Model,Feature_ID)
);

