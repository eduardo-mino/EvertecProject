CREATE PROCEDURE [dbo].[Get_OrderById]
	@orderId INT NULL
AS
	SELECT [Id] , 
		[customer_name], 
		[customer_email], 
		[customer_mobile], 
		[status], 
		[created_at], 
		[updated_at],
		[paymentId]
	FROM Orders
	WHERE [Id] = @orderId

RETURN 0
