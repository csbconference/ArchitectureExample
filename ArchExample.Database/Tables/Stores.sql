CREATE TABLE [dbo].[Stores]
(
	[Id] INT IDENTITY NOT NULL, 
    [Name] NVARCHAR(255) NOT NULL,    
	[Address] NVARCHAR(1024) NOT NULL,
    [CreatedAt] DATETIMEOFFSET NOT NULL, 
    [UpdatedAt] DATETIMEOFFSET NULL, 
    [Deleted] BIT NOT NULL CONSTRAINT [DF_Stores_Deleted] DEFAULT 0, 
    CONSTRAINT [PK_Stores] PRIMARY KEY ([Id])
)

GO

CREATE TRIGGER [dbo].[TR_Stores_InsertUpdateDelete]
    ON [dbo].[Stores]
    AFTER INSERT, UPDATE, DELETE 
	AS BEGIN 
	UPDATE [dbo].[Stores] 
	SET [dbo].[Stores].[UpdatedAt] = CONVERT(DATETIMEOFFSET, SYSUTCDATETIME()) 
	FROM INSERTED WHERE inserted.[Id] = [dbo].[Stores].[Id] 
END
GO