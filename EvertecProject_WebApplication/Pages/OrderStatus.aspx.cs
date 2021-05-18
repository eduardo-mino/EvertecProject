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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvertecProject_WebApplication.Pages
{
	public partial class OrderStatus : System.Web.UI.Page
	{
		public string OrderId { get { return Request.QueryString["orderId"] ?? "0"; } }
		public Order CurrentOrder { get; set; } 
		protected void Page_Load(object sender, EventArgs e)
		{
			CurrentOrder = OrdersApiClient.CallApiService<Order>(Constants.OrderSummary_EndpointUrl, "orderId", OrderId);

			if (!string.IsNullOrEmpty(CurrentOrder.PaymentId) && CurrentOrder.OrderStatus == Constants.CREATED)
			{
				string currentStatus = OrdersApiClient.CallApiService<string>(Constants.GetPaymentStatus_EndpointUrl, "paymentId",CurrentOrder.PaymentId);

				//si el status luego de consutar es diferente, quiere decir que se debe actualizar en la base de datos.
				if (currentStatus != CurrentOrder.OrderStatus)
				{
					CurrentOrder.OrderStatus = currentStatus;
					CurrentOrder.UpdatedAt = DateTime.Now;
					OrdersApiClient.CallApiService_CreateOrUpdateOrder(CurrentOrder, Constants.UpdateOrder_EndpointUrl);
				}
			}

			//se muestra el botón si el pago de la órden todavía está pendiente.
			btnNewPayment.Visible = CurrentOrder.OrderStatus != Constants.PAYED;
		}

		protected void btnNewPayment_Click(object sender, EventArgs e)
		{
			//vuelvo a chequear si no se realizo el pago antes de iniciar el flujo.
			if (!CurrentOrder.OrderStatus.Equals("PAYED"))
			{
				string paymentUrl = OrdersApiClient.CallApiService<string>(Constants.GetPaymentUrl_EndpointUrl, "orderId", OrderId);
				if (!string.IsNullOrEmpty(paymentUrl))
				{
					Response.Redirect(string.Concat(paymentUrl));
				}
			}
		}
	}
}