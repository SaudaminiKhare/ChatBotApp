CREATE TABLE [dbo].[Features] (
    [Feature_ID]   VARCHAR (10) NOT NULL,
    [Feature_Name] VARCHAR (50) NULL,
    [Row_ID] INT NOT NULL, 
    CONSTRAINT [PK_Features] PRIMARY KEY CLUSTERED ([Feature_ID] ASC)
);

