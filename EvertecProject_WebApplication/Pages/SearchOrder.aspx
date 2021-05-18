<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchOrder.aspx.cs" Inherits="EvertecProject_WebApplication.Pages.SearchOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-+0n0xVW2eSR5OomGNYDnhzAbDsOXxcvSN1TPprVMTNDbiYZCxYbOOl7+AMvyTG2x" crossorigin="anonymous">
	<link href="../App_Themes/Styles/SiteStyles.css" rel="stylesheet" />
	<script src="../Scripts/jquery-3.5.1.min.js"></script>
	<script type="text/javascript">
		$(document).ready(function () {
		var prm = Sys.WebForms.PageRequestManager.getInstance();
			$('#spinner').hide();
			$('#<%=btnSearch.ClientID%>').click(function () {
				if (Page_ClientValidate("SearchOrder")) {
					$('#spinner').show();
				}
				else {
					return false;
				}
			})
			prm.add_endRequest(function () {
				$('#spinner').hide();
			});
		})
	</script>
    <title>Search Order</title>
</head>
<body>
	<div class="div-container">
		<a href="../Home.aspx" class="left">Home</a>
		<h2 class="div-center">Please fill the required data</h2>
		<form runat="server" id="newOrderForm">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
				<div class="form-group">
					<label for="txtName"><span class="required">*</span>Full name:</label>
					<input type="text" maxlength="80" id="txtName" runat="server" class="form-control" placeholder="Enter your name here..." aria-describedby="divNameValidator"/>
					<small id="divNameValidator">
						<asp:RequiredFieldValidator runat="server" ID="rfvName" ControlToValidate="txtName" ValidationGroup="SearchOrder" ErrorMessage="Required required" CssClass="right required"></asp:RequiredFieldValidator>
					</small>
				</div>
				<div class="form-group">
					<label for="txtEmail"><span class="required">*</span>Email address:</label>
					<input type="text" maxlength="120" id="txtEmail" runat="server" class="form-control" placeholder="Enter your email here..." aria-describedby="divEmailValidator"/>
					<small id="divEmailValidator">
						<asp:RequiredFieldValidator runat="server" ID="rfvEmail" ControlToValidate="txtEmail" ValidationGroup="SearchOrder" ErrorMessage="Required required" CssClass="right required"></asp:RequiredFieldValidator>
						<asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format" ValidationGroup="SearchOrder" CssClass="right required"></asp:RegularExpressionValidator>
					</small>
				</div>
				<div class="form-group">
					<label for="txtMobile"><span class="required">*</span>Mobile number:</label>
					<input type="text" maxlength="40" id="txtMobile" runat="server" class="form-control" placeholder="Enter your mobile number here..." aria-describedby="divMobileValidator"/>
					<small id="divMobileValidator">
						<asp:RequiredFieldValidator runat="server" ID="rfvMobile" ControlToValidate="txtMobile" ValidationGroup="SearchOrder" ErrorMessage="Required required" CssClass="right required"></asp:RequiredFieldValidator>
					</small>
				</div>
			<div class="clear"></div>
			<asp:Button runat="server" ID="btnSearch" OnClick="btnCreateNewOrder_Click" Text="Search" ValidationGroup="SearchOrder" CssClass="right" OnClientClick="ActivateSpinner"/>
			<div class="clear"></div>
			<div class="spinner-border" role="status" id="spinner">
			  <span class="sr-only"></span>
			</div>
			<div class="clear"></div>
			<asp:UpdatePanel runat="server" ID="upResults">
				<ContentTemplate>
					<div runat="server" id="divResults">
						<h3>Search results</h3>
						<asp:MultiView runat="server" ID="mvResults">
							<asp:View ID="viewResults" runat="server">
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
							</asp:View>
							<asp:View runat="server" ID="viewEpmty">
								<span>No records found...</span>
							</asp:View>
						</asp:MultiView>
					</div>
				</ContentTemplate>
				<Triggers>
					<asp:AsyncPostBackTrigger ControlID="btnSearch" />
				</Triggers>
			</asp:UpdatePanel>
		</form>
	</div>
</body>
</html>
