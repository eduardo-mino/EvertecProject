using System;
using System.Collections.Generic;
using System.Text;

namespace EvertecProject_Common.Entities
{
	public class Order
	{
		public int OrderId { get; set; }
		public string CustomerName { get; set; }
		public string CustomerEmail { get; set; }
		public string CustomerMobile { get; set; }
		public string OrderStatus { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public string PaymentId { get; set; }
		public string GetCreatedAtDateString { get { return CreatedAt.ToShortDateString(); } }
	}
}
