CREATE TABLE [dbo].[Status] (
    [IdStatus]   UNIQUEIDENTIFIER NOT NULL,
    [StatusName] NVARCHAR (100)   NOT NULL,
    [Order]      INT              NOT NULL,
    CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED ([IdStatus] ASC)
);



