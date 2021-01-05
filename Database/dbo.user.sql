CREATE TABLE [dbo].[user]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [username] NCHAR(50) NULL, 
    [password] NCHAR(50) NULL, 
    [mobile] NCHAR(50) NULL
)
