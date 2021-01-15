CREATE TABLE [dbo].[ToDo] (
    [idToDo]      UNIQUEIDENTIFIER NOT NULL,
    [subject]     NVARCHAR (255)   NOT NULL,
    [description] NVARCHAR (MAX)   NULL,
    [startDate]   DATETIME         NOT NULL,
    [dueDate]     DATETIME         NULL,
    [idStatus]    UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_ToDo] PRIMARY KEY CLUSTERED ([idToDo] ASC),
    CONSTRAINT [FK_ToDo_Status] FOREIGN KEY ([idStatus]) REFERENCES [dbo].[Status] ([idStatus])
);

