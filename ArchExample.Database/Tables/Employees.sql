CREATE TABLE [dbo].[Employees]
(
	[CI] NVARCHAR(12) NOT NULL,
    [FirstName] NVARCHAR(255) NOT NULL,
	[LastName] NVARCHAR(255) NOT NULL,    
	[HourlyPayment] DECIMAL(19, 4) NOT NULL,
    [CreatedAt] DATETIMEOFFSET NOT NULL, 
    [UpdatedAt] DATETIMEOFFSET NULL, 
    [Deleted] BIT NOT NULL CONSTRAINT [DF_Employees_Deleted] DEFAULT 0, 
    CONSTRAINT [PK_Employees] PRIMARY KEY ([CI])
)

GO

CREATE TRIGGER [dbo].[TR_Employees_InsertUpdateDelete]
    ON [dbo].[Employees]
    AFTER INSERT, UPDATE, DELETE 
	AS BEGIN 
	UPDATE [dbo].[Employees] 
	SET [dbo].[Employees].[UpdatedAt] = CONVERT(DATETIMEOFFSET, SYSUTCDATETIME()) 
	FROM INSERTED WHERE inserted.[CI] = [dbo].[Employees].[CI] 
END
GO