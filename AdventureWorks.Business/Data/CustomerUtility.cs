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
            Customer customerDTO = new Customer
            {
                CustomerID = (int)reader["CustomerID"],
                NameStyle = (bool)reader["NameStyle"],
                FirstName = (string)reader["FirstName"],
                LastName = (string)reader["LastName"],
                PasswordHash = (string)reader["PasswordHash"],
                PasswordSalt = (string)reader["PasswordSalt"],
                RowGuid = (Guid)reader["rowguid"],
                ModifiedDate = (DateTime)reader["ModifiedDate"]
            };

            if (!(reader["Title"] is System.DBNull))
            {
                customerDTO.Title = (string)reader["Title"];
            }
            if (!(reader["MiddleName"] is System.DBNull))
            {
                customerDTO.MiddleName = (string)reader["MiddleName"];
            }
            if (!(reader["Suffix"] is System.DBNull))
            {
                customerDTO.Suffix = (string)reader["Suffix"];
            }
            if (!(reader["CompanyName"] is System.DBNull))
            {
                customerDTO.CompanyName = (string)reader["CompanyName"];
            }
            if (!(reader["SalesPerson"] is System.DBNull))
            {
                customerDTO.SalesPerson = (string)reader["SalesPerson"];
            }
            if (!(reader["EmailAddress"] is System.DBNull))
            {
                customerDTO.EmailAddress = (string)reader["EmailAddress"];
            }
            if (!(reader["Phone"] is System.DBNull))
            {
                customerDTO.Phone = (string)reader["Phone"];
            }
          
            return customerDTO;
        }
    }
}
