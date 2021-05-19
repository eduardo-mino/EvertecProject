using EvertecProject_BusinessLogic;
using EvertecProject_Common;
using PlacetoPay.Integrations.Library.CSharp.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EvertecProject_NotificationsHandlerAPI.Controllers
{
    public class NotificationsHandlerController : ApiController
    {
		[HttpPost]
		[Route("api/Notification")]
		public void Notification([FromBody]Notification notification)
		{
			var bl = new OrdersBusinesLogic();
			var dateNow = DateTime.Now;
			if (notification.IsValidNotification()) {
				if (notification.IsApproved())
				{
					bl.UpdateOrder(Constants.PAYED, dateNow, notification.RequestId.ToString());
				}
				else if(notification.IsRejected())
				{
					bl.UpdateOrder(Constants.REJECTED, dateNow, notification.RequestId.ToString());
				}
			}
		}

		[HttpPost]
		[Route("api/Notification2")]
		public void Notification2([FromBody]object data)
		{
			var bl = new OrdersBusinesLogic();
			bl.GetWebCheckoutNotification(data.ToString());
		}
    }
}
