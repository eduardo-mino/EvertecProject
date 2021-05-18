using EvertecProject_ApiClient;
using EvertecProject_Common;
using EvertecProject_Common.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvertecProject_WebApplication.Pages
{
	public partial class NewOrder : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}


		protected void btnCreateNewOrder_Click(object sender, EventArgs e)
		{
			Order newOrder = new Order()
			{
				CustomerName = txtName.Value,
				CustomerEmail = txtEmail.Value,
				CustomerMobile = txtMobile.Value
			};
			string resultOrderId = OrdersApiClient.CallApiService_CreateOrUpdateOrder(newOrder, Constants.NewOrder_EndpointUrl);
			if(resultOrderId!="Error" || !string.IsNullOrEmpty(resultOrderId))
			{
				Response.Redirect(string.Concat("OrderSummary.aspx?orderId=", resultOrderId));
			}

		}
	}
}