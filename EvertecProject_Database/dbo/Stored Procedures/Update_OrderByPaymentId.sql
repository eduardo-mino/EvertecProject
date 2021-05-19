CREATE PROCEDURE [dbo].[Update_OrderByPaymentId]
	@status VARCHAR(20),
	@updateTime DATETIME,
	@paymentId VARCHAR(100) NULL
AS
	UPDATE Orders 
	SET [status] = @status,
		[updated_at] = @updateTime,
		[paymentId] = @paymentId

	WHERE [PaymentId] IS NOT NULL 
	AND [PaymentId] = @paymentId
RETURN 0
