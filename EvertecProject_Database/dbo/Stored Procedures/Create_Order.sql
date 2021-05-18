CREATE PROCEDURE [dbo].[Create_Order]
    @customer_name VARCHAR(80), 
    @customer_email VARCHAR(120), 
    @customer_mobile VARCHAR(40)
AS

INSERT INTO [Orders] ([customer_name], [customer_email], [customer_mobile], [status], [created_at])
VALUES(@customer_name, @customer_email, @customer_mobile, 'CREATED', GETDATE())


RETURN @@identity
