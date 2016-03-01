using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.Business.Models;
using System.Data.SqlClient;

namespace AdventureWorks.Business.Data
{
    public class CustomerUtility : IGetCustomerInfo
    {
        public List<Customer> GetCustomer()
        {
            List<Customer> colCustomers = new List<Customer>();

            //Connection
            SqlConnection conn = new SqlConnection();

            //Connection String
            conn.ConnectionString = "Server=ANDYHOLZMAN;Database=AdventureWorks2012LT;Trusted_Connection=True;";

            //Command
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM SalesLT.Customer";

            //Data Reader
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while(reader.Read())
                {
                    Customer newCustomer = new Customer
                    {
                        CustomerID = (int)reader["CustomerID"],
                        NameStyle = (byte)reader["NameStyle"],
                        Title = (string)reader["Title"],
                        FirstName = (string)reader["FirstName"],
                        MiddleName = (string)reader["MiddleName"],
                        LastName = (string)reader["LastName"],
                        Suffix = (string)reader["Suffix"],
                        CompanyName = (string)reader["CompanyName"],
                        SalesPerson = (string)reader["SalesPerson"],
                        Email = (string)reader["EmailAddress"],
                        Phone = (string)reader["Phone"],
                        PasswordHash = (string)reader["PasswordHash"],
                        PasswordSalt = (string)reader["PasswordSalt"],
                        RowGuid = (Guid)reader["rowguid"],
                        ModifiedDate = (DateTime)reader["ModifiedDate"]
                    };
                    colCustomers.Add(newCustomer);
                }
                reader.Close();
            }

            catch(Exception ex)
            {
                throw;
            }

            return colCustomers;
        }
    }
}
