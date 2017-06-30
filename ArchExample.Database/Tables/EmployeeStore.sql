CREATE TABLE [dbo].[EmployeeStore]
(
	[Id] INT NOT NULL,
    [EmployeeCI] NVARCHAR(12) NOT NULL,
	[StoreId] INT NOT NULL,	
    [CreatedAt] DATETIMEOFFSET NOT NULL, 
    [UpdatedAt] DATETIMEOFFSET NULL, 
    [Deleted] BIT NOT NULL CONSTRAINT [DF_EmployeeStore_Deleted] DEFAULT 0, 
    CONSTRAINT [PK_EmployeeStore] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_EmployeeStoreToEmployees] FOREIGN KEY ([EmployeeCI]) REFERENCES [dbo].[Employees]([CI]),
	CONSTRAINT [FK_EmployeeStoreToStores] FOREIGN KEY ([StoreId]) REFERENCES [dbo].[Stores]([Id])	
)
GO

CREATE TRIGGER [dbo].[TR_EmployeeStore_InsertUpdateDelete]
    ON [dbo].[EmployeeStore]
    AFTER INSERT, UPDATE, DELETE 
	AS BEGIN 
	UPDATE [dbo].[EmployeeStore] 
	SET [dbo].[EmployeeStore].[UpdatedAt] = CONVERT(DATETIMEOFFSET, SYSUTCDATETIME()) 
	FROM INSERTED WHERE inserted.[Id] = [dbo].[EmployeeStore].[Id] 
END
GO