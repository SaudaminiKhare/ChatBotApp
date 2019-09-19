CREATE TABLE [dbo].[Questions] (
    [Question_ID] INT           NOT NULL,
    [Question]    VARCHAR (100) NOT NULL,
    [Option]      VARCHAR (50)  NULL,
    CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED ([Question_ID] ASC)
);

