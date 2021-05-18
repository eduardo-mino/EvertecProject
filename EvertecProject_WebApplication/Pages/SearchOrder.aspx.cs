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
	public partial class SearchOrder : System.Web.UI.Page
	{
		public string OrdersApiBaseUrl { get { return ConfigurationManager.AppSettings["OrdersApiBaseUrl"]; } }
		public string GetOrdersEndpointUrl { get { return string.Concat(OrdersApiBaseUrl, Constants.GetOrders_EndpointUrl ); } }
		List<Order> CurrentOrders { get; set; }
		protected void Page_Load(object sender, EventArgs e)
		{
			divResults.Visible = !string.IsNullOrWhiteSpace(txtName.Value) || !string.IsNullOrWhiteSpace(txtEmail.Value) || !string.IsNullOrWhiteSpace(txtMobile.Value);
		}

		protected void btnCreateNewOrder_Click(object sender, EventArgs e)
		{
			Order newOrder = new Order()
			{
				CustomerName = txtName.Value,
				CustomerEmail = txtEmail.Value,
				CustomerMobile = txtMobile.Value
			};
			CurrentOrders = OrdersApiClient.CallApiService_GetOrders(newOrder);
			if(CurrentOrders!=null && CurrentOrders.Count > 0)
			{
				mvResults.SetActiveView(viewResults);
				rptOrders.DataSource = CurrentOrders;
				rptOrders.DataBind();
			}
			else
			{
				mvResults.SetActiveView(viewEpmty);
			}
		}

	}
}