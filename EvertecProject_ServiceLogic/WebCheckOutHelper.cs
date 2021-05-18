using PlacetoPay.Integrations.Library.CSharp.Contracts;
using PlacetoPay.Integrations.Library.CSharp.Entities;
using PlacetoPay.Integrations.Library.CSharp.Message;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P2P = PlacetoPay.Integrations.Library.CSharp.PlacetoPay;

namespace EvertecProject_ServiceLogic
{
	public class WebCheckOutHelper
	{
		private static string Login { get { return ConfigurationManager.AppSettings["Login"]; } }
		private static string TranKey { get { return ConfigurationManager.AppSettings["TranKey"]; } }
		private static string WebCheckOutUrl { get { return ConfigurationManager.AppSettings["WebCheckOutUrl"]; } }
		private static string WebPortalUrl { get { return ConfigurationManager.AppSettings["WebPortalUrl"]; } }

		private Gateway gateway = new P2P(Login,
										  TranKey,
										  new Uri(WebCheckOutUrl),
										  Gateway.TP_REST);

		public RedirectResponse CreateRequest(string orderId, string ipAddress, string userAgent)
		{
			Amount amount = new Amount(1000);
			Payment payment = new Payment(orderId, "DESCRIPTION", amount, true);
			RedirectRequest request = new RedirectRequest(payment,
				string.Format(WebPortalUrl, orderId),
				ipAddress,
				userAgent,
				DateTime.Now.AddMinutes(30).ToString("yyyy-MM-ddTHH:mm:sszzz"));

			RedirectResponse response = gateway.Request(request);

			return response;
		}

		public RedirectInformation GetRequestInfo(string requestId)
		{
			RedirectInformation response = gateway.Query(requestId);

			return response;
		}

	}
}
