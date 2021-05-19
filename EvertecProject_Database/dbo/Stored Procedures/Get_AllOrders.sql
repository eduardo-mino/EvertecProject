CREATE PROCEDURE [dbo].[Get_AllOrders]
AS
	SELECT [Id] , 
		[customer_name], 
		[customer_email], 
		[customer_mobile], 
		[status], 
		[created_at], 
		[updated_at]
	FROM Orders
	ORDER BY Id DESC

RETURN 0
