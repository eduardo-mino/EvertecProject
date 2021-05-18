CREATE PROCEDURE [dbo].[Get_FilteredOrders]
    @customer_name VARCHAR(80), 
    @customer_email VARCHAR(120), 
    @customer_mobile VARCHAR(40)
AS
	SELECT [Id] , 
		[customer_name], 
		[customer_email], 
		[customer_mobile], 
		[status], 
		[created_at], 
		[updated_at]
	FROM Orders
	WHERE [customer_name] = @customer_name
	AND [customer_email] = @customer_email
	AND [customer_mobile] = @customer_mobile
	
	ORDER BY Id DESC

RETURN 0
