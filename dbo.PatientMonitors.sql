CREATE TABLE [dbo].[PatientMonitors] (
    [Model]      VARCHAR (10) NOT NULL,
    [Feature_ID] VARCHAR (10) NOT NULL,
    [Presence]   BIT          NOT NULL,
	CONSTRAINT PK_Monitor PRIMARY KEY (Model,Feature_ID),
	FOREIGN KEY (Feature_ID) REFERENCES Features(Feature_ID),
	FOREIGN KEY (Model) REFERENCES Monitors(Model)
);

