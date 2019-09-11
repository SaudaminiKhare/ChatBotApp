CREATE TABLE [dbo].[Monitors] (
    [Model]          VARCHAR (10) NOT NULL,
    [Name]           VARCHAR (50) NULL,
    [Sales_Incharge] VARCHAR (50) NULL, 
    CONSTRAINT [PK_Monitors] PRIMARY KEY ([Model])
);

