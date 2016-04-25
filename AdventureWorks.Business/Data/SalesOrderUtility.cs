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

        public List<SalesOrder> SearchSalesOrder(string query) //return a list of SalesOrders based upon a passed in query
        {
            //Variable
            List<SalesOrder> colSalesOrder = new List<SalesOrder>();


            //Connection
            SqlCommand cmd = GetDbCommand();
            //SELECT (TQL)
            cmd.CommandText = @"
                SELECT SalesOrderID, RevisionNumber, OrderDate, Status, OnlineOrderFlag, SalesOrderNumber, PurchaseOrderNumber, AccountNumber, ShipMethod, SubTotal, TotalDue
                FROM AdventureWorksLT2012.SalesLT.SalesOrderHeader
                WHERE CONVERT(varchar(200), SalesOrderID) like '%' + @query + '%'
                ";

            cmd.Parameters.AddWithValue("@query", query);

            //DataReader
            try
            {
                //Open connection
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                //Loop thru rows, and create SalesOrder objects
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

        public SalesOrder GetSalesOrder(int salesOrderID) //get SalesOrder based upon a passed in SalesOrderID
        {
            SalesOrder salesOrderToReturn = null; //create instance of SalesOrder

            //DB command stuff
            SqlCommand cmd = GetDbCommand(); 
            cmd.CommandText = @"
                SELECT SalesOrderID, RevisionNumber, OrderDate, Status, OnlineOrderFlag, SalesOrderNumber, PurchaseOrderNumber, AccountNumber, ShipMethod, SubTotal, TotalDue
                FROM SalesLT.SalesOrderHeader
                WHERE SalesOrderID LIKE @Id
                ";
            cmd.Parameters.AddWithValue("@Id", salesOrderID);

            try
            {
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                if (reader.Read())
                {
                    salesOrderToReturn = BuildSalesOrder(reader); //set properties of the new SalesOrdre based upon DB data
                }
                reader.Close();

            }

            catch (Exception ex)
            {
                throw;
            }


            return salesOrderToReturn;
        } 

        public SalesOrderDates GetDates(int salesOrderID) //get applicable dates to a SalesOrder based upon passed in SalesOrderID
        {
            SalesOrderDates soDatesToReturn = null;

            //db command stuff
            SqlCommand cmd = GetDbCommand();
            cmd.CommandText = @"
                SELECT SalesOrderID, OrderDate, DueDate, ShipDate
                FROM SalesLT.SalesOrderHeader
                WHERE SalesOrderID LIKE @Id
                ";
            cmd.Parameters.AddWithValue("@Id", salesOrderID);

            try
            {
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                if (reader.Read())
                {
                    soDatesToReturn = BuildSalesOrderDates(reader); //set date properties of the new SalesOrderDate based upon DB data
                }
                reader.Close();

            }

            catch (Exception ex)
            {
                throw;
            }


            return soDatesToReturn;
        }

        public List<SalesOrderDetail> GetSalesOrderDetails(int salesOrderID)
        {
            List<SalesOrderDetail> soDetailsToReturn = new List<SalesOrderDetail>(); //create instance of a list of SalesOrderDetail objects

            //DB command stuff
            SqlCommand cmd = GetDbCommand();
            cmd.CommandText = @"
                SELECT SalesOrderID, SalesOrderDetailID, OrderQty, ProductID, UnitPrice, UnitPriceDiscount, LineTotal, ModifiedDate
                FROM SalesLT.SalesOrderDetail
                WHERE SalesOrderID LIKE @Id
                ";
            cmd.Parameters.AddWithValue("@Id", salesOrderID);

            try
            {
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    SalesOrderDetail soDetail = new SalesOrderDetail();
                    
                    soDetail = BuildSalesOrderDetails(reader); //set properties of the new SalesOrderDetail object created above from DB data
                    soDetailsToReturn.Add(soDetail); //Add soDetail object to the list of SalesOrderDetail objects
                }
                reader.Close();

            }

            catch (Exception ex)
            {
                throw;
            }


            return soDetailsToReturn;
        }

        public int AddSalesOrderHeader(SalesOrderHeader soHeader)
        {
            //Declarations
            int salesOrderIDToReturn = 0;
            DateTime modifiedDate = DateTime.Now;

            //SQL Command
            SqlCommand cmd = GetDbCommand();
            SqlCommand cmd2 = GetDbCommand();

            cmd.CommandText = @"
                INSERT INTO AdventureWorksLT2012.SalesLT.SalesOrderHeader
                (RevisionNumber, OrderDate, DueDate, ShipDate, Status, OnlineOrderFlag, AccountNumber, PurchaseOrderNumber, CustomerID, ShipToAddressID, BillToAddressID, ShipMethod, CreditCardApprovalCode, SubTotal, TaxAmt, Freight, Comment, ModifiedDate)
                Values
                (@RevisionNumber, @OrderDate, @DueDate, @ShipDate, @Status, @OnlineOrderFlag, @AccountNumber, @PurchaseOrderNumber, @CustomerID, @ShipToAddressID, @BillToAddressID, @ShipMethod, @CreditCardApprovalCode, @SubTotal, @TaxAmt, @Freight, @Comment, @ModifiedDate);

                SELECT @@Identity from AdventureWorksLT2012.SalesLT.SalesOrderHeader
                ";

            cmd.Parameters.AddWithValue("@RevisionNumber", soHeader.RevisionNumber);
            cmd.Parameters.AddWithValue("@OrderDate", soHeader.OrderDate);
            cmd.Parameters.AddWithValue("@DueDate", soHeader.DueDate);
            cmd.Parameters.AddWithValue("@Status", soHeader.Status);
            cmd.Parameters.AddWithValue("@OnlineOrderFlag", soHeader.OrderOnlineFlag);
            cmd.Parameters.AddWithValue("@CustomerID", soHeader.CustomerID);
            cmd.Parameters.AddWithValue("@ShipMethod", soHeader.ShipMethod);
            cmd.Parameters.AddWithValue("@SubTotal", soHeader.SubTotal);
            cmd.Parameters.AddWithValue("@TaxAmt", soHeader.TaxAmt);
            cmd.Parameters.AddWithValue("@Freight", soHeader.Freight);
            cmd.Parameters.AddWithValue("@ModifiedDate", modifiedDate);

            //set parameters for nullable values
            if (soHeader.ShipDate == null) { cmd.Parameters.AddWithValue("@ShipDate", DBNull.Value); }
            else { cmd.Parameters.AddWithValue("@ShipDate", soHeader.ShipDate); }
            if (soHeader.AccountNumber == null) { cmd.Parameters.AddWithValue("@AccountNumber", DBNull.Value); }
            else { cmd.Parameters.AddWithValue("@AccountNumber", soHeader.AccountNumber); }
            if (soHeader.PurchaseOrderNumber == null) { cmd.Parameters.AddWithValue("@PurchaseOrderNumber", DBNull.Value); }
            else { cmd.Parameters.AddWithValue("@PurchaseOrderNumber", soHeader.PurchaseOrderNumber); }
            if (soHeader.ShipToAddressID == null) { cmd.Parameters.AddWithValue("@ShipToAddressID", DBNull.Value); }
            else { cmd.Parameters.AddWithValue("@ShipToAddressID", soHeader.ShipToAddressID); }
            if (soHeader.BillToAddressID == null) { cmd.Parameters.AddWithValue("@BillToAddressID", DBNull.Value); }
            else { cmd.Parameters.AddWithValue("@BillToAddressID", soHeader.BillToAddressID); }
            if (soHeader.CreditCardApprovalCode == null) { cmd.Parameters.AddWithValue("@CreditCardApprovalCode", DBNull.Value); }
            else { cmd.Parameters.AddWithValue("@CreditCardApprovalCode", soHeader.CreditCardApprovalCode); }
            if (soHeader.Comment == null) { cmd.Parameters.AddWithValue("@Comment", DBNull.Value); }
            else { cmd.Parameters.AddWithValue("@Comment", soHeader.Comment); }

            cmd2.CommandText = @" 
                SELECT TOP 1 SalesOrderID 
                FROM AdventureWorksLT2012.SalesLT.SalesOrderHeader
                ORDER BY SalesOrderID DESC;
                ";

            //Execute Query
            object objNewProductId;
            try
            {
                cmd.Connection.Open();
                objNewProductId = cmd.ExecuteScalar();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                throw;
            }

            try
            {
                cmd2.Connection.Open();
                SqlDataReader reader = cmd2.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                if (reader.Read())
                {
                    salesOrderIDToReturn = (int)reader["SalesOrderID"]; //set properties of the new SalesOrdre based upon DB data
                }
                reader.Close();

            }

            catch (Exception ex)
            {
                throw;
            }

            return salesOrderIDToReturn;
        }

        public void AddSalesOrderDetail(SalesOrderDetail soDetail)
        {
            //Declarations
            DateTime modifiedDate = DateTime.Now;

            //SQL Command
            SqlCommand cmd = GetDbCommand();

            cmd.CommandText = @"
                INSERT INTO AdventureWorksLT2012.SalesLT.SalesOrderDetail
                (SalesOrderID, OrderQty, ProductID, UnitPrice, UnitPriceDiscount, ModifiedDate)
                Values
                (@SalesOrderID, @OrderQty, @ProductID, @UnitPrice, @UnitPriceDiscount, @ModifiedDate);

                SELECT @@Identity from AdventureWorksLT2012.SalesLT.SalesOrderDetail
                ";

            cmd.Parameters.AddWithValue("@SalesOrderID", soDetail.SalesOrderID);
            cmd.Parameters.AddWithValue("@OrderQty", soDetail.OrderQty);
            cmd.Parameters.AddWithValue("@ProductID", soDetail.ProductID);
            cmd.Parameters.AddWithValue("@UnitPrice", soDetail.UnitPrice);
            cmd.Parameters.AddWithValue("@UnitPriceDiscount", soDetail.UnitPriceDiscount);
            cmd.Parameters.AddWithValue("@ModifiedDate", modifiedDate);



            

            //Execute Query
            object objNewProductId;
            try
            {
                cmd.Connection.Open();
                objNewProductId = cmd.ExecuteScalar();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                throw;
            }

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
        private static SalesOrder BuildSalesOrder(SqlDataReader reader) //set properties of a SalesOrder object based upon DB data
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

            //check for nullable values and handle
            if (!(reader["PurchaseOrderNumber"] is System.DBNull))
            {
                salesOrderDTO.PurchaseOrderNumber = (string)reader["PurchaseOrderNumber"];
            } else { salesOrderDTO.PurchaseOrderNumber = "N/A"; }
            if (!(reader["AccountNumber"] is System.DBNull))
            {
                salesOrderDTO.AccountNumber = (string)reader["AccountNumber"];
            } else { salesOrderDTO.AccountNumber = "N/A"; }

            return salesOrderDTO;
        }
        private static SalesOrderDates BuildSalesOrderDates(SqlDataReader reader) //set properties of a SalesOrderDate object based upon DB data
        {
            SalesOrderDates soDatesDTO = new SalesOrderDates
            {
                SalesOrderID = (int)reader["SalesOrderID"],
                OrderDate = (DateTime)reader["OrderDate"],
                DueDate = (DateTime)reader["DueDate"],

            };
            //check if ShipDate is null and handle
            if (!(reader["ShipDate"] is System.DBNull))
            {
                soDatesDTO.ShipDate = (DateTime)reader["ShipDate"];
            } else { soDatesDTO.ShipDate = null; }

            return soDatesDTO;
        }
        private static SalesOrderDetail BuildSalesOrderDetails(SqlDataReader reader) //set properties of a SalesORderDetails object based upon DB data
        {
            SalesOrderDetail soDetailToReturn = new SalesOrderDetail
            {
                SalesOrderID = (int)reader["SalesOrderID"],
                SalesOrderDetailID = (int)reader["SalesOrderDetailID"],
                OrderQty = (Int16)reader["OrderQty"],
                ProductID = (int)reader["ProductID"],
                UnitPrice = (decimal)reader["UnitPrice"],
                UnitPriceDiscount = (decimal)reader["UnitPriceDiscount"],
                LineTotal = (decimal)reader["LineTotal"],
                ModifiedDate = (DateTime)reader["ModifiedDate"]
            };

            return soDetailToReturn;
        }

    }
}
