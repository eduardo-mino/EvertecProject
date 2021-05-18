CREATE PROCEDURE [dbo].[Update_Order]
	@orderId INT NULL,
	@status VARCHAR(20),
	@updateTime DATETIME,
	@paymentId VARCHAR(100) NULL
AS
	UPDATE Orders 
	SET [status] = @status,
		[updated_at] = @updateTime,
		[paymentId] = @paymentId

	WHERE [Id] = @orderId
RETURN 0
