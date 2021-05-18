<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewOrder.aspx.cs" Inherits="EvertecProject_WebApplication.Pages.NewOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-+0n0xVW2eSR5OomGNYDnhzAbDsOXxcvSN1TPprVMTNDbiYZCxYbOOl7+AMvyTG2x" crossorigin="anonymous">
	<link href="../App_Themes/Styles/SiteStyles.css" rel="stylesheet" />
    <title>New Order</title>
</head>
<body>
	<div class="div-container">
		<a href="../Home.aspx" class="left">Home</a>
		<h2 class="div-center">Please fill the required data</h2>
		<form runat="server" id="newOrderForm">
				<div class="form-group">
					<label for="txtName"><span class="required">*</span>Full name:</label>
					<input type="text" maxlength="80" id="txtName" runat="server" class="form-control" placeholder="Enter your name here..." aria-describedby="divNameValidator"/>
					<small id="divNameValidator">
						<asp:RequiredFieldValidator runat="server" ID="rfvName" ControlToValidate="txtName" ValidationGroup="NewOrder" ErrorMessage="Required required" CssClass="right required"></asp:RequiredFieldValidator>
					</small>
				</div>
				<div class="form-group">
					<label for="txtEmail"><span class="required">*</span>Email address:</label>
					<input type="text" maxlength="120" id="txtEmail" runat="server" class="form-control" placeholder="Enter your email here..." aria-describedby="divEmailValidator"/>
					<small id="divEmailValidator">
						<asp:RequiredFieldValidator runat="server" ID="rfvEmail" ControlToValidate="txtEmail" ValidationGroup="NewOrder" ErrorMessage="Required required" CssClass="right required"></asp:RequiredFieldValidator>
						<asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format" ValidationGroup="NewOrder" CssClass="right required"></asp:RegularExpressionValidator>
					</small>
				</div>
				<div class="form-group">
					<label for="txtMobile"><span class="required">*</span>Mobile number:</label>
					<input type="text" maxlength="40" id="txtMobile" runat="server" class="form-control" placeholder="Enter your mobile number here..." aria-describedby="divMobileValidator"/>
					<small id="divMobileValidator">
						<asp:RequiredFieldValidator runat="server" ID="rfvMobile" ControlToValidate="txtMobile" ValidationGroup="NewOrder" ErrorMessage="Required required" CssClass="right required"></asp:RequiredFieldValidator>
					</small>
				</div>
			<div class="clear"></div>
			<asp:Button runat="server" ID="btnCreateNewOrder" OnClick="btnCreateNewOrder_Click" Text="Create Order" ValidationGroup="NewOrder" CssClass="right"/>
		</form>
	</div>
</body>
</html>
