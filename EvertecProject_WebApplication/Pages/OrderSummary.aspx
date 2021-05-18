<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderSummary.aspx.cs" Inherits="EvertecProject_WebApplication.Pages.OrderSummary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-+0n0xVW2eSR5OomGNYDnhzAbDsOXxcvSN1TPprVMTNDbiYZCxYbOOl7+AMvyTG2x" crossorigin="anonymous">
	<link href="../App_Themes/Styles/SiteStyles.css" rel="stylesheet" />
    <title>Order Summary</title>
</head>
<body>
	<div class="div-container div-center">
		<a href="../Home.aspx" class="left">Home</a>
		<h2>Order #<%=OrderId %> Summary</h2>
		<table class="table">
			<tr>
				<td>Customer name</td>
				<td><%=CurrentOrder.CustomerName%></td>
			</tr>
			<tr>
				<td>Customer Email</td>
				<td><%=CurrentOrder.CustomerEmail%></td>
			</tr>
			<tr>
				<td>Customer Mobile</td>
				<td><%=CurrentOrder.CustomerMobile%></td>
			</tr>
			<tr>
				<td>Date of the order</td>
				<td><%=CurrentOrder.CreatedAt.ToString("dd/MM/yyyy")%></td>
			</tr>
			<tr>
				<td>Order status</td>
				<td><%=CurrentOrder.OrderStatus%></td>
			</tr>
		</table>

		<a href="OrderStatus.aspx?orderId=<%=OrderId %>" >See payment options</a>
	</div>

</body>
</html>
