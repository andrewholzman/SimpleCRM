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
            int x;
            if (Int32.TryParse(query, out x)) { };
           

            //Connection
            SqlCommand cmd = GetDbCommand();
            //SELECT (TQL)
            cmd.CommandText = @"
                SELECT *
                FROM SalesLT.Customer
                WHERE FirstName LIKE '%' + @query + '%' OR
                LastName LIKE '%' + @query + '%'  OR
                CustomerID = @id
                ";

            cmd.Parameters.AddWithValue("@query", query);
            cmd.Parameters.AddWithValue("@id", x);

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

        public Customer GetCustomer(int customerID)
        {
            Customer customerToReturn = null;

            SqlCommand cmd = GetDbCommand();
            cmd.CommandText = "SELECT * FROM SalesLT.Customer WHERE CustomerId = @Id";
            cmd.Parameters.AddWithValue("@Id", customerID);

            try
            {
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                if (reader.Read())
                {
                    customerToReturn = BuildCustomer(reader);
                }
                reader.Close();

            }

            catch(Exception ex)
            {
                throw;
            }


            return customerToReturn;
        }

        public Address GetAddress(int customerID)
        {
            Address addressToReturn = null;

            SqlCommand cmd = GetDbCommand();
            cmd.CommandText = @"
            SELECT *
            FROM SalesLT.Address 
            INNER JOIN SalesLT.CustomerAddress
            ON Address.AddressID=CustomerAddress.AddressID
            WHERE SalesLT.CustomerAddress.CustomerID = @customerID;

            SELECT AddressType
            FROM SalesLT.CustomerAddress
            WHERE CustomerID = @customerID;
            ";

            
            cmd.Parameters.AddWithValue("@customerID", customerID);

            try
            {
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    addressToReturn = BuildAddress(reader);
                }
                reader.Close();
            }

            catch(Exception ex)
            {
                throw;
            }

            return addressToReturn;
        }

        public CustomerAddress GetCustomerAddress(int customerID)
        {
            CustomerAddress customerAddressToReturn = null;

            SqlCommand cmd = GetDbCommand();
            cmd.CommandText = "SELECT * FROM SalesLT.CustomerAddress WHERE CustomerId = @CustomerId";
            cmd.Parameters.AddWithValue("@CustomerId", customerID);

            try
            {
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    customerAddressToReturn = BuildCustomerAddress(reader);
                }
                reader.Close();

            }

            catch (Exception ex)
            {
                throw;
            }

            return customerAddressToReturn;
        }

        public void UpdateCustomer(Customer custToUpdate)
        {
            // create instance of new Customer
            Customer newCustomer = new Customer();

            //Declarations

            //get Sql cmd
            SqlCommand cmd = GetDbCommand();

            //Set command parameters
            cmd.CommandText = @"
                UPDATE AdventureWorksLT2012.SalesLT.Customer
                SET Title = @Title,
                    FirstName = @FirstName,
                    MiddleName = @MiddleName,
                    LastName = @LastName,
                    Suffix = @Suffix,
                    CompanyName = @CompanyName,
                    SalesPerson = @SalesPerson,
                    EmailAddress = @EmailAddress,
                    Phone = @Phone,
                    ModifiedDate = @ModifiedDate
                WHERE CustomerID = @CustomerID
                ";



            DateTime lastModified = DateTime.Now;

            // Set parameters for non-null values
            cmd.Parameters.AddWithValue("@FirstName", custToUpdate.FirstName);
            cmd.Parameters.AddWithValue("@LastName", custToUpdate.LastName);
            cmd.Parameters.AddWithValue(@"ModifiedDate", lastModified);
            cmd.Parameters.AddWithValue(@"CustomerID", custToUpdate.CustomerID);

            //Check null values and set parameters
            if (custToUpdate.Title == null) { cmd.Parameters.AddWithValue("@Title", DBNull.Value); }
            else { cmd.Parameters.AddWithValue("@Title", custToUpdate.Title); }

            if (custToUpdate.MiddleName == null) { cmd.Parameters.AddWithValue("@MiddleName", DBNull.Value); }
            else { cmd.Parameters.AddWithValue("@MiddleName", custToUpdate.MiddleName); }

            if (custToUpdate.Suffix == null) { cmd.Parameters.AddWithValue("@Suffix", DBNull.Value); }
            else { cmd.Parameters.AddWithValue("@Suffix", custToUpdate.Suffix); }

            if (custToUpdate.CompanyName == null) { cmd.Parameters.AddWithValue("@CompanyName", DBNull.Value); }
            else { cmd.Parameters.AddWithValue("@CompanyName", custToUpdate.CompanyName); }

            if (custToUpdate.SalesPerson == null) { cmd.Parameters.AddWithValue("@SalesPerson", DBNull.Value); }
            else { cmd.Parameters.AddWithValue("@SalesPerson", custToUpdate.SalesPerson); }

            if (custToUpdate.EmailAddress == null) { cmd.Parameters.AddWithValue("@EmailAddress", DBNull.Value); }
            else { cmd.Parameters.AddWithValue("@EmailAddress", custToUpdate.EmailAddress); }

            if (custToUpdate.Phone == null) { cmd.Parameters.AddWithValue("@Phone", DBNull.Value); }
            else { cmd.Parameters.AddWithValue("@Phone", custToUpdate.Phone); }

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteScalar();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                throw;
            }

            //Update last modified date
            newCustomer.ModifiedDate = lastModified;
        }

        //public void UpdateAddress(Address addressToUpdate)
        //{
        //    //Create new Address object
        //    Address newAddress = new Address();

        //    //Declarations

        //    //get Sql cmd
        //    SqlCommand cmd = GetDbCommand();

        //    //Set command parameters
        //    cmd.CommandText = @"
        //        UPDATE AdventureWorksLT2012.SalesLT.Address
        //        SET AddressLine1 = @AddressLine1,
        //            AddressLine2 = @AddressLine2,
        //            City = @City,
        //            StateProvince = @StateProvince,
        //            CountryRegion = @CountryRegion,
        //            PostalCode = @PostalCode,
        //            ModifiedDate = @ModifiedDate
        //        INNER JOIN SalesLT.CustomerAddress
        //        ON Address.AddressID=CustomerAddress.AddressID
        //        WHERE SalesLT.CustomerAddress.CustomerID = @CustomerID
        //    ";

        //    DateTime lastModified = DateTime.Now;

        //    // Set parameters for non-null values
        //    cmd.Parameters.AddWithValue("@AddressLine1", addressToUpdate.AddressLine1);
        //    cmd.Parameters.AddWithValue("@City", addressToUpdate.City);
        //    cmd.Parameters.AddWithValue("@StateProvince", addressToUpdate.StateProvince);
        //    cmd.Parameters.AddWithValue("@CountryRegion", addressToUpdate.CountryRegion);
        //    cmd.Parameters.AddWithValue("@PostalCode", addressToUpdate.PostalCode);

        //    //Check null values and set parameter for AddressLine2
        //    if (addressToUpdate.AddressLine2 == null) { cmd.Parameters.AddWithValue("@AddressLine2", DBNull.Value); }
        //    else { cmd.Parameters.AddWithValue("@AddressLine2", addressToUpdate.AddressLine2); }

            
        //    try
        //    {
        //        cmd.Connection.Open();
        //        cmd.ExecuteScalar();
        //        cmd.Connection.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }

        //    //Update last modified date
        //    addressToUpdate.ModifiedDate = lastModified;

        //}


        //public void AddAddress(Address addressToAdd, CustomerAddress customerAddress)
        //{
        //    {
        //        //Create new Address object
        //        Address newAddress = new Address();
        //        CustomerAddress newCustomerAddress = new CustomerAddress();


        //        //Declarations

        //        //get Sql cmd
        //        SqlCommand cmd = GetDbCommand();

        //        //Set command parameters

        //        cmd.CommandText = @"
        //        INSERT INTO AdventureWorksLT2012.SalesLT.Address
        //            (AddressID, AddressLine1, AddressLine2, City, StateProvince, CountryRegion, PostalCode, ModifiedDate)
        //        VALUES
        //            (@AddressID, @AddressLine1, @AddressLine2, @City, @StateProvince, @CountryRegion, @PostalCode, @ModifiedDate);

        //        SELECT @@Identity from SalesLT.Address

        //        INSERT INTO AdventureWorksLT2012.SalesLT.CustomerAddress
        //            (CustomerID, AddressID, AddressType)
        //        VALUES 
        //            (@CustomerID, @AddressID, @AddressType)
                
        //        ";

        //        DateTime lastModified = DateTime.Now;

        //        // Set parameters for non-null values
        //        cmd.Parameters.AddWithValue("@AddressID", addressToAdd.AddressID);
        //        cmd.Parameters.AddWithValue("@AddressLine1", addressToAdd.AddressLine1);
        //        cmd.Parameters.AddWithValue("@City", addressToAdd.City);
        //        cmd.Parameters.AddWithValue("@StateProvince", addressToAdd.StateProvince);
        //        cmd.Parameters.AddWithValue("@CountryRegion", addressToAdd.CountryRegion);
        //        cmd.Parameters.AddWithValue("@PostalCode", addressToAdd.PostalCode);

        //        cmd.Parameters.AddWithValue("@CustomerID", customerAddress.CustomerId);

        //        //Check null values and set parameter for AddressLine2
        //        if (addressToAdd.AddressLine2 == null) { cmd.Parameters.AddWithValue("@AddressLine2", DBNull.Value); }
        //        else { cmd.Parameters.AddWithValue("@AddressLine2", addressToAdd.AddressLine2); }


        //        try
        //        {
        //            cmd.Connection.Open();
        //            cmd.ExecuteScalar();
        //            cmd.Connection.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw;
        //        }

        //        //Update last modified date
        //        addressToAdd.ModifiedDate = lastModified;

        //    }

        //}
        


        private SqlCommand GetDbCommand()
        {
            //Set up database connection
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["Utility"].ConnectionString;

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

        private static Address BuildAddress(SqlDataReader reader)
        {
            Address AddressDTO = new Address
            {
                AddressID = (int)reader["AddressID"],
                AddressLine1 = (string)reader["AddressLine1"],
                City = (string)reader["City"],
                StateProvince = (string)reader["StateProvince"],
                CountryRegion = (string)reader["CountryRegion"],
                PostalCode = (string)reader["PostalCode"],
                RowGuid = (Guid)reader["RowGuid"],
                ModifiedDate = (DateTime)reader["ModifiedDate"],
                AddressType = (string)reader["AddressType"]
            };

            if (!(reader["AddressLine2"] is System.DBNull))
            {
                AddressDTO.AddressLine2 = (string)reader["AddressLine2"];
            }
            return AddressDTO;
        }

        private static CustomerAddress BuildCustomerAddress(SqlDataReader reader)
        {
            CustomerAddress customerAddressDTO = new CustomerAddress
            {
                CustomerId = (int)reader["CustomerID"],
                AddressID = (int)reader["AddressID"],
                AddressType = (string)reader["AddressType"],
                RowGuid = (Guid)reader["RowGuid"],
                ModifiedDate = (DateTime)reader["ModifiedDate"]
            };
            return customerAddressDTO;
        }

        
    }
}
