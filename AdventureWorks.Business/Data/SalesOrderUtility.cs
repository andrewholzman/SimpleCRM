using AdventureWorks.Business.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Data
{
    public class SalesOrderUtility : IGetSalesOrderInfo
    {

        public List<SalesOrder> SearchSalesOrder(string query)
        {
            //Variable
            List<SalesOrder> colSalesOrder = new List<SalesOrder>();
            int x;
            if (Int32.TryParse(query, out x)) { };


            //Connection
            SqlCommand cmd = GetDbCommand();
            //SELECT (TQL)
            cmd.CommandText = @"
                SELECT SalesOrderID, RevisionNumber, OrderDate, Status, OnlineOrderFlag, SalesOrderNumber, PurchaseOrderNumber, AccountNumber, ShipMethod, SubTotal, TotalDue
                FROM SalesLT.SalesOrderHeader
                WHERE SalesOrderID LIKE @x
                ";

            cmd.Parameters.AddWithValue("@x", x);

            //DataReader
            try
            {
                //Open connection
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                //Loop thru rows, and create Product objects
                while (reader.Read())
                {
                    SalesOrder newSalesOrder = new SalesOrder();
                    newSalesOrder = BuildSalesOrder(reader);
                    colSalesOrder.Add(newSalesOrder);
                }
                //close connection
                reader.Close();
            }


            catch (Exception ex)
            {
                throw;
            }

            return colSalesOrder;
        }

        private SqlCommand GetDbCommand()
        {
            //Set up database connection
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["Utility"].ConnectionString;

            //Command
            SqlCommand cmd = conn.CreateCommand();

            return cmd;
        }
        private static SalesOrder BuildSalesOrder(SqlDataReader reader)
        {
            SalesOrder salesOrderDTO = new SalesOrder
            {
                SalesOrderID = (int)reader["SalesOrderID"],
                RevisionNumber = (byte)reader["RevisionNumber"],
                OrderDate = (DateTime)reader["OrderDate"],
                Status = (byte)reader["Status"],
                OrderOnlineFlag = (bool)reader["OnlineOrderFlag"],
                SalesOrderNumber = (string)reader["SalesOrderNumber"],
                ShipMethod = (string)reader["ShipMethod"],
                SubTotal = (decimal)reader["SubTotal"],
                TotalDue = (decimal)reader["TotalDue"]
            };

            if (!(reader["PurchaseOrderNumber"] is System.DBNull))
            {
                salesOrderDTO.PurchaseOrderNumber = (string)reader["PurchaseOrderNumber"];
            }
            if (!(reader["AccountNumber"] is System.DBNull))
            {
                salesOrderDTO.AccountNumber = (string)reader["AccountNumber"];
            }

            return salesOrderDTO;
        }
    }
}
