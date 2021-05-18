using EvertecProject_Common;
using EvertecProject_Common.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvertecProject_DataAccess
{
	public class OrdersDataAccess
	{
		public int NewOrder(string customer_name, string customer_email, string customer_mobile)
		{
			int orderId = 0;
			using (SqlConnection connection = new SqlConnection(GetConnectionString("orders")))
			{
				connection.Open();

				SqlCommand sqlcom = new SqlCommand(Constants.StoredProcedure_CreateOrder, connection);
				sqlcom.CommandType = System.Data.CommandType.StoredProcedure;
				sqlcom.Parameters.AddWithValue("@customer_name", customer_name);
				sqlcom.Parameters.AddWithValue("@customer_email", customer_email);
				sqlcom.Parameters.AddWithValue("@customer_mobile", customer_mobile);
				
				var returnParameter = sqlcom.Parameters.Add("@ReturnVal", SqlDbType.Int);
				returnParameter.Direction = ParameterDirection.ReturnValue;

				sqlcom.ExecuteNonQuery();
				orderId = (int)returnParameter.Value;

				connection.Close();
			}
			return orderId;
		}

		public Order OrderSummary(int orderId)
		{
			Order result = null;
			using (SqlConnection connection = new SqlConnection(GetConnectionString("orders")))
			{
				connection.Open();

				SqlCommand sqlcom = new SqlCommand(Constants.StoredProcedure_GetOrder, connection);
				sqlcom.CommandType = System.Data.CommandType.StoredProcedure;
				sqlcom.Parameters.AddWithValue("@orderId", orderId);
				using (SqlDataReader reader = sqlcom.ExecuteReader())
				{
					//Add rows
					if (reader.Read())
					{
						result = new Order()
						{
							OrderId = (int)reader["Id"],
							CustomerName = reader["customer_name"] as string,
							CustomerEmail = reader["customer_email"] as string,
							CustomerMobile = reader["customer_mobile"] as string,
							OrderStatus = reader["status"] as string,
							CreatedAt = (DateTime)reader["created_at"],
							UpdatedAt = reader["updated_at"] as DateTime?,
							PaymentId = reader["paymentId"] as string
						};
					}
				}
				connection.Close();
			}

			return result;
		}

		public void UpdateOrder(int orderId, string status, DateTime updateTime, string paymentId)
		{
			using (SqlConnection connection = new SqlConnection(GetConnectionString("Orders")))
			{
				connection.Open();
				SqlCommand sqlcom = new SqlCommand(Constants.StoredProcedure_UpdateOrder, connection);
				sqlcom.CommandType = System.Data.CommandType.StoredProcedure;
				sqlcom.Parameters.AddWithValue("@orderId", orderId);
				sqlcom.Parameters.AddWithValue("@status", status);
				sqlcom.Parameters.AddWithValue("@updateTime", updateTime);
				sqlcom.Parameters.AddWithValue("@paymentId", paymentId);
				sqlcom.ExecuteNonQuery();
				connection.Close();
			}
		}

		public List<Order> AllOrders()
		{
			System.Collections.Generic.List<Order> result = new List<Order>();

			using (SqlConnection connection = new SqlConnection(GetConnectionString("Orders")))
			{
				connection.Open();
				SqlCommand sqlcom = new SqlCommand(Constants.StoredProcedure_GetAllOrders, connection);
				sqlcom.CommandType = System.Data.CommandType.StoredProcedure;
				using (SqlDataReader reader = sqlcom.ExecuteReader())
				{
					//Add rows
					while (reader.Read())
					{
						result.Add(new Order()
						{
							OrderId = (int)reader["Id"],
							CustomerName = reader["customer_name"] as string,
							CustomerEmail = reader["customer_email"] as string,
							CustomerMobile = reader["customer_mobile"] as string,
							OrderStatus = reader["status"] as string,
							CreatedAt = (DateTime)reader["created_at"],
							UpdatedAt = reader["updated_at"] as DateTime?
						});
					}
				}

				connection.Close();
			}
			return result;
		}

		public List<Order> GetOrders(string customer_name, string customer_email, string customer_mobile)
		{
			System.Collections.Generic.List<Order> result = new List<Order>();

			using (SqlConnection connection = new SqlConnection(GetConnectionString("Orders")))
			{
				connection.Open();
				SqlCommand sqlcom = new SqlCommand(Constants.StoredProcedure_GetAllOrders, connection);
				sqlcom.CommandType = System.Data.CommandType.StoredProcedure;
				sqlcom.Parameters.AddWithValue("@customer_name", customer_name);
				sqlcom.Parameters.AddWithValue("@customer_email", customer_email);
				sqlcom.Parameters.AddWithValue("@customer_mobile", customer_mobile);

				using (SqlDataReader reader = sqlcom.ExecuteReader())
				{
					//Add rows
					while (reader.Read())
					{
						result.Add(new Order()
						{
							OrderId = (int)reader["Id"],
							CustomerName = reader["customer_name"] as string,
							CustomerEmail = reader["customer_email"] as string,
							CustomerMobile = reader["customer_mobile"] as string,
							OrderStatus = reader["status"] as string,
							CreatedAt = (DateTime)reader["created_at"],
							UpdatedAt = reader["updated_at"] as DateTime?
						});
					}
				}

				connection.Close();
			}
			return result;
		}

		private string GetConnectionString(string key)
		{
			ConnectionStringSettingsCollection connectionStrings = ConfigurationManager.ConnectionStrings;

			if (connectionStrings == null)
				return string.Empty;

			if (connectionStrings[key] == null || string.IsNullOrEmpty(connectionStrings[key].ConnectionString))
				return string.Empty;

			return connectionStrings[key].ConnectionString;
		}
	}
}
