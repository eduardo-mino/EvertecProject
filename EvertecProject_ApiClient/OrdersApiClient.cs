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
using System.Threading.Tasks;

namespace EvertecProject_ApiClient
{
	public static class OrdersApiClient
	{
		public static string OrdersApiBaseUrl { get { return ConfigurationManager.AppSettings["OrdersApiBaseUrl"]; } }
		public static T CallApiService<T>(string endpoint, string parameterName, string parameterValue)
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(OrdersApiBaseUrl);


			client.DefaultRequestHeaders.Accept.Add(
			new MediaTypeWithQualityHeaderValue("application/json"));


			string url = string.Concat(OrdersApiBaseUrl, endpoint, "?", parameterName, "=", parameterValue);
			HttpResponseMessage response = client.GetAsync(url).Result;
			client.Dispose();

			if (response.IsSuccessStatusCode)
			{
				string apiResultString = response.Content.ReadAsStringAsync().Result;
				return JsonConvert.DeserializeObject<T>(apiResultString);
			}

			return default(T);
		}
		
		public static string CallApiService_CreateOrUpdateOrder(Order newOrder, string endpoint)
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(OrdersApiBaseUrl);


			client.DefaultRequestHeaders.Accept.Add(
			new MediaTypeWithQualityHeaderValue("application/json"));


			var json = JsonConvert.SerializeObject(newOrder);
			StringContent data = new StringContent(json, Encoding.UTF8, "application/json");

			string url = string.Concat(OrdersApiBaseUrl, endpoint);
			HttpResponseMessage response = client.PostAsync(url, data).Result;
			client.Dispose();
			string apiResult = string.Empty;

			if (response.IsSuccessStatusCode)
			{
				apiResult = response.Content.ReadAsStringAsync().Result; 
			}
			return apiResult;
		}
		
		public static List<Order> CallApiService_GetOrders(Order newOrder)
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(OrdersApiBaseUrl);


			client.DefaultRequestHeaders.Accept.Add(
			new MediaTypeWithQualityHeaderValue("application/json"));

			string url = string.Concat(OrdersApiBaseUrl, Constants.GetOrders_EndpointUrl, 
				"?", "customerName", "=", newOrder.CustomerName, 
				"&", "customerEmail", "=", newOrder.CustomerEmail, 
				"&", "customerMobile", "=", newOrder.CustomerMobile);

			HttpResponseMessage response = client.GetAsync(url).Result;
			client.Dispose();
			List<Order> apiResult = null;

			if (response.IsSuccessStatusCode)
			{
				string apiResultString = response.Content.ReadAsStringAsync().Result;
				apiResult = JsonConvert.DeserializeObject<List<Order>>(apiResultString);
			}

			return apiResult;
		}
	}
}
