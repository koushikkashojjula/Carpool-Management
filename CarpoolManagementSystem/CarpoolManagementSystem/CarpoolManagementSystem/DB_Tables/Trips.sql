CREATE TABLE [dbo].[Trips] (
    [Id]          INT          NOT NULL,
    [source]      VARCHAR (50) NOT NULL,
    [destination] VARCHAR (50) NOT NULL,
    [date]        DATE         NOT NULL,
    [created_by]  INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Trips_Users] FOREIGN KEY ([created_by]) REFERENCES [dbo].[Users] ([UserID])
);

