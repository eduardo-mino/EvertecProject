<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllOrders.aspx.cs" Inherits="EvertecProject_WebApplication.Pages.AllOrders" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Orders' List</title>
	<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-+0n0xVW2eSR5OomGNYDnhzAbDsOXxcvSN1TPprVMTNDbiYZCxYbOOl7+AMvyTG2x" crossorigin="anonymous">
	<link href="../App_Themes/Styles/SiteStyles.css" rel="stylesheet" />
</head>
<body>	
	<div class="div-container div-center">
		<a href="../Home.aspx" class="left">Home</a>
		<h2>Orders' List</h2>
		<table class="table">
			<asp:Repeater runat="server" ID="rptOrders">
				<HeaderTemplate>
					<thead>
						<tr>
							<th class="col">#Order</th>
							<th class="col">Order's date</th>
							<th class="col">Customer Name</th>
							<th class="col">Email</th>
							<th class="col">Mobile</th>
							<th class="col">Payment Status</th>					
						</tr>
					</thead>
				</HeaderTemplate>
				<ItemTemplate>
					<tbody>
						<tr>
							<td><%#Eval("OrderId") %></td>
							<td><%#Eval("GetCreatedAtDateString") %></td>
							<td><%#Eval("CustomerName") %></td>
							<td><%#Eval("CustomerEmail") %></td>
							<td><%#Eval("CustomerMobile") %></td>
							<td><a href="OrderStatus.aspx?OrderId=<%#Eval("OrderId") %>"><%#Eval("OrderStatus")%></a></td>
						</tr>
					</tbody>
				</ItemTemplate>
			</asp:Repeater>
		</table>
	</div>
</body>
</html>
