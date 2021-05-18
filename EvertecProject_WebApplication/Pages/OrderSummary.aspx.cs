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
	public partial class OrderSummary : System.Web.UI.Page
	{
		public string OrdersApiBaseUrl { get { return ConfigurationManager.AppSettings["OrdersApiBaseUrl"]; } }
		public string OrderSummaryEndpointUrl { get { return string.Concat(OrdersApiBaseUrl, "OrderSummary"); } }
		public string OrderId { get { return Request.QueryString["orderId"] ?? "0"; } }
		public Order CurrentOrder { get; set; }
		protected void Page_Load(object sender, EventArgs e)
		{
			CurrentOrder = OrdersApiClient.CallApiService<Order>(Constants.OrderSummary_EndpointUrl, "orderId", OrderId);
		}

	}
}