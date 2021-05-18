using EvertecProject_BusinessLogic;
using EvertecProject_Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace EvertecProject_API.Controllers
{
    public class OrdersController : ApiController
    {
		[HttpPost]
		[Route("api/NewOrder")]
		public int NewOrder([FromBody] Order newOrder)
		{
			return new OrdersBusinesLogic().NewOrder(newOrder.CustomerName, newOrder.CustomerEmail, newOrder.CustomerMobile);
		}

		[HttpPost]
		[Route("api/UpdateOrder")]
		public int UpdateOrder([FromBody] Order order)
		{
			new OrdersBusinesLogic().UpdateOrder(order.OrderId, order.OrderStatus, order.UpdatedAt??DateTime.Now, order.PaymentId);
			return order.OrderId;
		}

		[HttpGet]
		[Route("api/OrderSummary")]
		public Order OrderSummary(int orderId)
		{
			return new OrdersBusinesLogic().OrderSummary(orderId);
		}

		[HttpGet]
		[Route("api/GetPaymentUrl")]
		public string GetPaymentUrl(string orderId)
		{
			var ipAddress = GetUserIP();
			var userAgent = HttpContext.Current.Request.UserAgent ?? "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36";
			return new OrdersBusinesLogic().WebCheckoutCreateRequest(orderId, ipAddress, userAgent);
		}

		[HttpGet]
		[Route("api/GetPaymentStatus")]
		public string GetPaymentStatus(string paymentId)
		{
			return new OrdersBusinesLogic().GetWebCheckoutPaymentStatus(paymentId);
		}

		//[HttpGet]
		//[Route("api/GetPaymentStatus")]
		//public string GetPaymentStatus(string paymentId)
		//{
		//	return new OrdersBusinesLogic().GetWebCheckoutPaymentStatus(paymentId);
		//}

		[HttpGet]
		[Route("api/AllOrders")]
		public IEnumerable<Order> AllOrders()
		{
			return new OrdersBusinesLogic().AllOrders();
		}	 

		[HttpGet]
		[Route("api/GetOrders")]
		public IEnumerable<Order> GetOrders(string customerName, string customerEmail, string customerMobile)
		{
			return new OrdersBusinesLogic().GetOrders(customerName, customerEmail, customerMobile);
		}

		public static string GetUserIP()
		{
			var ip = (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null
			&& HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != "")
			? HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]
			: HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
			if (ip.Contains(","))
				ip = ip.Split(',').First().Trim();
			return ip;
		}
	}
}
