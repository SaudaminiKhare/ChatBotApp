CREATE TABLE [dbo].[Questions] (
    [Question_ID] VARCHAR (10)  NOT NULL,
    [Question]    VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED ([Question_ID] ASC)
);

