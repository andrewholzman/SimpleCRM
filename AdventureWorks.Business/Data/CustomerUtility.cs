using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.Business.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace AdventureWorks.Business.Data
{
    public class CustomerUtility : IGetCustomerInfo
    {

        public List<Customer> SearchCustomer(string query)
        {
            //Variable
            List<Customer> colCustomer = new List<Customer>();

            //Connection
            SqlCommand cmd = GetDbCommand();
            //SELECT (TQL)
            cmd.CommandText = @"
                SELECT *
                FROM SalesLT.Customer
                WHERE FirstName LIKE '%' + @query + '%' OR
                LastName LIKE '%' + @query + '%'
                ";

            cmd.Parameters.AddWithValue("@query", query);


            //DataReader
            try
            {
                //Open connection
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                //Loop thru rows, and create Product objects
                while (reader.Read())
                {
                    Customer newCust = new Customer();
                    newCust = BuildCustomer(reader);
                    colCustomer.Add(newCust);
                }
                //close connection
                reader.Close();
            }


            catch (Exception ex)
            {
                throw;
            }

            return colCustomer;
        }

        private SqlCommand GetDbCommand()
        {
            //Set up database connection
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["CustomerUtility"].ConnectionString;

            //Command
            SqlCommand cmd = conn.CreateCommand();

            return cmd;
        }

        private static Customer BuildCustomer(SqlDataReader reader)
        {
            return new Customer
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
        }
    }
}
