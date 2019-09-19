CREATE TABLE [dbo].[Features] (
[Row_ID] int NOT NULL,
    [Feature_ID]   VARCHAR (10) NOT NULL,
    [Feature_Name] VARCHAR (50) NULL,
    CONSTRAINT [PK_Features] PRIMARY KEY CLUSTERED ([Feature_ID] ASC)
);

