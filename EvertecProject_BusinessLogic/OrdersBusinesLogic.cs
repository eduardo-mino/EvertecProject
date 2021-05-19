using EvertecProject_Common;
using EvertecProject_Common.Entities;
using EvertecProject_DataAccess;
using EvertecProject_ServiceLogic;
using PlacetoPay.Integrations.Library.CSharp.Message;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EvertecProject_BusinessLogic
{
	public class OrdersBusinesLogic
	{
		public int NewOrder(string customer_name, string customer_email, string customer_mobile)
		{
			try
			{
				return new OrdersDataAccess().NewOrder(customer_name, customer_email, customer_mobile);
			}
			catch (Exception ex)
			{
				EventLog.WriteEntry("Evertec - Orders API", ex.StackTrace, EventLogEntryType.Error);
				throw ex;
			}
		}

		public Order OrderSummary(int orderId)
		{
			try
			{
				return new OrdersDataAccess().OrderSummary(orderId);
			}
			catch (Exception ex)
			{
				EventLog.WriteEntry("Evertec - Orders API", ex.StackTrace, EventLogEntryType.Error);
				throw ex;
			}
		}

		public void UpdateOrder(int orderId, string status, DateTime updateTime, string paymentId)
		{
			try
			{
				new OrdersDataAccess().UpdateOrder(orderId, status, updateTime, paymentId);
			}
			catch (Exception ex)
			{
				EventLog.WriteEntry("Evertec - Orders API", ex.StackTrace, EventLogEntryType.Error);
				throw ex;
			}
		}

		public void UpdateOrder(string status, DateTime updateTime, string paymentId)
		{
			try
			{
				new OrdersDataAccess().UpdateOrder(status, updateTime, paymentId);
			}
			catch (Exception ex)
			{
				EventLog.WriteEntry("Evertec - Orders API", ex.StackTrace, EventLogEntryType.Error);
				throw ex;
			}
		}

		public List<Order> AllOrders()
		{
			try
			{
				return new OrdersDataAccess().AllOrders();
			}
			catch (Exception ex)
			{
				EventLog.WriteEntry("Evertec - Orders API", ex.StackTrace, EventLogEntryType.Error);
				throw ex;
			}
		}

		public List<Order> GetOrders(string customer_name, string customer_email, string customer_mobile)
		{
			try
			{
				return new OrdersDataAccess().GetOrders(customer_name, customer_email, customer_mobile);
			}
			catch (Exception ex)
			{
				EventLog.WriteEntry("Evertec - Orders API", ex.StackTrace, EventLogEntryType.Error);
				throw ex;
			}
		}

		public string WebCheckoutCreateRequest(string orderId, string ipAddress, string userAgent)
		{
			try
			{
				System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				var result = new WebCheckOutHelper().CreateRequest(orderId, ipAddress, userAgent);
				int orderIdInt = 0;
				if (Int32.TryParse(orderId, out orderIdInt))
				{
					if (result.IsSuccessful())
					{
						new OrdersDataAccess().UpdateOrder(orderIdInt, "CREATED", DateTime.Now, result.RequestId);
						return result.ProcessUrl;
					}
				}
				return string.Empty;
			}
			catch (Exception ex)
			{
				EventLog.WriteEntry("Evertec - Orders API", ex.StackTrace, EventLogEntryType.Error);
				throw ex;
			}
		}

		public string GetWebCheckoutPaymentStatus(string paymentId)
		{
			try
			{
				System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				RedirectInformation result = new WebCheckOutHelper().GetRequestInfo(paymentId);
				if (result.IsSuccessful())
				{
					if (result.IsApproved())
					{
						return Constants.PAYED;
					}
					if (result.IsRejected())
					{
						return Constants.REJECTED;
					}
				}
				return Constants.CREATED;
			}
			catch (Exception ex)
			{
				EventLog.WriteEntry("Evertec - Orders API", ex.StackTrace, EventLogEntryType.Error);
				throw ex;
			}
		}

		public void GetWebCheckoutNotification(string data)
		{
			try
			{
				WebCheckOutHelper wcoHelper = new WebCheckOutHelper();
				Notification notification = wcoHelper.ReadNotification(data);

				var bl = new OrdersBusinesLogic();
				var dateNow = DateTime.Now;
				if (notification.IsValidNotification())
				{
					if (notification.IsApproved())
					{
						bl.UpdateOrder(Constants.PAYED, dateNow, notification.RequestId.ToString());
					}
					else if (notification.IsRejected())
					{
						bl.UpdateOrder(Constants.REJECTED, dateNow, notification.RequestId.ToString());
					}
				}
			}
			catch (Exception ex)
			{
				EventLog.WriteEntry("Evertec - Orders API", ex.StackTrace, EventLogEntryType.Error);
				throw ex;
			}
		}

	}
}
