CREATE TABLE [dbo].[Users] (
    [UserID]    INT          IDENTITY (1, 1) NOT NULL,
    [FirstName] VARCHAR (50) NOT NULL,
    [LastName]  VARCHAR (50) NOT NULL,
    [EmaiID]    VARCHAR (50) NOT NULL,
    [Username]  VARCHAR (50) NOT NULL,
    [Password]  VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC)
);

