using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvertecProject_Common
{
	public class Constants
	{
		public const string StoredProcedure_CreateOrder = "Create_Order";
		public const string StoredProcedure_GetAllOrders = "Get_AllOrders";
		public const string StoredProcedure_GetFilteredOrders = "Get_FilteredOrders";
		public const string StoredProcedure_GetOrder = "Get_OrderById";
		public const string StoredProcedure_UpdateOrder = "Update_Order";

		public const string CREATED = "CREATED";
		public const string PAYED = "PAYED";
		public const string REJECTED = "REJECTED";


		public const string OrderSummary_EndpointUrl = "OrderSummary";
		public const string GetPaymentUrl_EndpointUrl = "GetPaymentUrl";
		public const string GetPaymentStatus_EndpointUrl = "GetPaymentStatus";
		public const string AllOrders_EndpointUrl = "AllOrders";
		public const string GetOrders_EndpointUrl = "GetOrders";
		public const string NewOrder_EndpointUrl = "NewOrder";
		public const string UpdateOrder_EndpointUrl = "UpdateOrder";
	}
}
