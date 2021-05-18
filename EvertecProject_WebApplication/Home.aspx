<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="EvertecProject_WebApplication.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
	<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-+0n0xVW2eSR5OomGNYDnhzAbDsOXxcvSN1TPprVMTNDbiYZCxYbOOl7+AMvyTG2x" crossorigin="anonymous">
	<link href="App_Themes/Styles/SiteStyles.css" rel="stylesheet" />
</head>
<body>
	<div class="div-container div-center">
		<h2>What do you want to do?</h2>
		<ul class="list-group">
			<li class="list-group-item">
				<a href="Pages/NewOrder.aspx">Create a new order</a>
			</li>
			<li class="list-group-item">
				<a href="Pages/AllOrders.aspx">View all orders</a>
			</li>
			<li class="list-group-item">
				<a href="Pages/SearchOrder.aspx">Search order</a>
			</li>
		</ul>
	</div>
</body>
</html>
