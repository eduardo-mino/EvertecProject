using EvertecProject_ApiClient;
using EvertecProject_Common;
using EvertecProject_Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvertecProject_WebApplication.Pages
{
	public partial class AllOrders : System.Web.UI.Page
	{
		private List<Order> CurrentOrders { get; set; }
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				CurrentOrders= OrdersApiClient.CallApiService<List<Order>>(Constants.AllOrders_EndpointUrl, "", "");
				rptOrders.DataSource = CurrentOrders;
				rptOrders.DataBind();
			}
		}
	}
}