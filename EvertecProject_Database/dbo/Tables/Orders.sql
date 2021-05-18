CREATE TABLE [dbo].[Orders]
(
	[Id] INT IDENTITY (1, 1) NOT NULL, 
    [customer_name] VARCHAR(80) NOT NULL, 
    [customer_email] VARCHAR(120) NOT NULL, 
    [customer_mobile] VARCHAR(40) NOT NULL, 
    [status] VARCHAR(20) NOT NULL, 
    [created_at] DATETIME NOT NULL, 
    [updated_at] DATETIME NULL, 
    [paymentId] VARCHAR(100) NULL
)
