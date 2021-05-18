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

RETURN 0
