CREATE TABLE [dbo].[Status] (
    [idStatus] UNIQUEIDENTIFIER NOT NULL,
    [status]   NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED ([idStatus] ASC)
);

