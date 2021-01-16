CREATE TABLE [dbo].[ToDo] (
    [IdToDo]      UNIQUEIDENTIFIER NOT NULL,
    [Subject]     NVARCHAR (255)   NOT NULL,
    [IdStatus]    UNIQUEIDENTIFIER NOT NULL,
    [Description] NVARCHAR (4000)  NULL,
    CONSTRAINT [PK_ToDo] PRIMARY KEY CLUSTERED ([IdToDo] ASC),
    CONSTRAINT [FK_ToDo_Status] FOREIGN KEY ([IdStatus]) REFERENCES [dbo].[Status] ([IdStatus])
);



