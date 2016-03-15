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
            WHERE SalesLT.CustomerAddress.CustomerID = @customerID
            ";
            cmd.Parameters.AddWithValue("@customerID", customerID);

            try
            {
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                if (reader.Read())
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

        public List<Product> SearchProduct(string query)
        {
            //Variable
            List<Product> colProducts = new List<Product>();
            //int x;
            //if (Int32.TryParse(query, out x)) { };


            //Connection
            SqlCommand cmd = GetDbCommand();
            //SELECT (TQL)
            cmd.CommandText = @"
                SELECT *
                FROM SalesLT.Product
                WHERE Name LIKE '%' + @query + '%'
                ";

            cmd.Parameters.AddWithValue("@query", query);
            //cmd.Parameters.AddWithValue("@id", x);

            //DataReader
            try
            {
                //Open connection
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                //Loop thru rows, and create Product objects
                while (reader.Read())
                {
                    Product newProduct = BuildProduct(reader);
                    colProducts.Add(newProduct);
                }
                //close connection
                reader.Close();
            }


            catch (Exception ex)
            {
                throw;
            }

            return colProducts;
        }

        public Product GetProduct(int Id)
        {
            Product productToRetun = null;

            SqlCommand cmd = GetDbCommand();
            cmd.CommandText = "SELECT * FROM SalesLT.Product WHERE CustomerId = @Id";
            cmd.Parameters.AddWithValue("@Id", Id);

            try
            {
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                if (reader.Read())
                {
                    productToRetun = BuildProduct(reader);
                }
                reader.Close();

            }

            catch (Exception ex)
            {
                throw;
            }


            return productToRetun;
        }

        public Product AddProduct(Product newProduct)
        {
            //Declarations
            Product productToReturn;

            //get Sql cmd
            SqlCommand cmd = GetDbCommand();

            //Set command parameters
            cmd.CommandText = @"
                INSERT INTO Product
                (Name, ProductNumber, Color, StandardCost, ListPrice, Size, Weight, ProductCategoryID, ProductModelID, SellStartDate, SellEndDate, DiscontinuedDate, ThumbNailPhoto, ThumbnailPhotoFileName)
                VALUES
                (@Name, @ProductNumber, @Color, @StandardCost, @ListPrice, @Size, @Weight, @ProductCategoryID, @ProductModelID, @SellStartDate, @SellEndDate, @DiscontinuedDate, @ThumbNailPhoto, @ThumbnailPhotoFileName);

                SELECT @@Identity from Product
                ";

            cmd.Parameters.AddWithValue("@Name", newProduct.ProductName);
            cmd.Parameters.AddWithValue("@ProductNumber", newProduct.ProductNumber);
            cmd.Parameters.AddWithValue("@Color", newProduct.Color);
            cmd.Parameters.AddWithValue("@StandardCost", newProduct.StandardCost);
            cmd.Parameters.AddWithValue("@ListPrice", newProduct.ListPrice);
            cmd.Parameters.AddWithValue("@Size", newProduct.Size);
            cmd.Parameters.AddWithValue("@Weight", newProduct.Weight);
            cmd.Parameters.AddWithValue("@ProductCategoryID", newProduct.ProductCategoryID);
            cmd.Parameters.AddWithValue("@ProductModelID", newProduct.ProductModelID);
            cmd.Parameters.AddWithValue("@SellStartDate", newProduct.SellStartDate);
            cmd.Parameters.AddWithValue("@SellEndDate", newProduct.SellEndDate);
            cmd.Parameters.AddWithValue("@DiscontinuedDate", newProduct.DiscontinuedDate);
            cmd.Parameters.AddWithValue("@ThumbNailPhoto", newProduct.ThumbNailPhoto);
            cmd.Parameters.AddWithValue("@ThumbnailPhotoFileName", newProduct.ThumbNailFileName);

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

            //Get new product
            //Build new product
            productToReturn = GetProduct((int)objNewProductId);

            //Return new product
            return productToReturn;
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

        private static Address BuildAddress(SqlDataReader reader)
        {
            Address AddressDTO = new Address
            {
                AddressLine1 = (string)reader["AddressLine1"],
                City = (string)reader["City"],
                StateProvince = (string)reader["StateProvince"],
                CountryRegion = (string)reader["CountryRegion"],
                PostalCode = (string)reader["PostalCode"],
                RowGuid = (Guid)reader["RowGuid"],
                ModifiedDate = (DateTime)reader["ModifiedDate"]
            };

            if (!(reader["AddressLine2"] is System.DBNull))
            {
                AddressDTO.AddressLine2 = (string)reader["AddressLine2"];
            }
            return AddressDTO;
        }

        private static Product BuildProduct(SqlDataReader reader)
        {
            var ProductDTO = new Product
            {
                ProductID = (int)reader["ProductID"],
                ProductName = (string)reader["Name"],
                ProductNumber = (string)reader["ProductNumber"],
                StandardCost =(decimal)reader["StandardCost"],
                ListPrice = (decimal)reader["ListPrice"],
                SellStartDate = (DateTime)reader["SellStartDate"],
                RowGuid = (Guid)reader["RowGuid"],
                ModifiedDate = (DateTime)reader["ModifiedDate"]
            };

            if (!(reader["Color"] is DBNull))
            {
                ProductDTO.Color = (string)reader["Color"];
            }
            if (!(reader["Size"] is DBNull))
            {
                ProductDTO.Size = (string)reader["Size"];
            }
            if (!(reader["Weight"] is DBNull))
            {
                ProductDTO.Weight = (decimal)reader["Weight"];
            }
            if (!(reader["ProductCategoryID"] is DBNull))
            {
                ProductDTO.ProductCategoryID = (int)reader["ProductCategoryID"];
            }
            if (!(reader["ProductModelID"] is DBNull))
            {
                ProductDTO.ProductModelID = (int)reader["ProductModelID"];
            }
            if (!(reader["SellEndDate"] is DBNull))
            {
                ProductDTO.SellEndDate = (DateTime)reader["SellEndDate"];
            }
            if (!(reader["DiscontinuedDate"] is DBNull))
            {
                ProductDTO.DiscontinuedDate = (DateTime)reader["DiscontinuedDate"];
            } 
            if (!(reader["ThumbNailPhoto"] is DBNull))
            {
                ProductDTO.ThumbNailPhoto = (byte[])reader["ThumbNailPhoto"];
            }
            if (!(reader["ThumbnailPhotoFileName"] is DBNull))
            {
                ProductDTO.ThumbNailFileName = (string)reader["ThumbnailPhotoFileName"];
            }

            return ProductDTO;

        }

        
    }
}
