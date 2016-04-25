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
    class ProductUtility : IGetProductInfo
    {
        public void AddProduct(Product newProduct)
        {
           

            //get Sql cmd
            SqlCommand cmd = GetDbCommand();

            //Set command parameters
            cmd.CommandText = @"

                INSERT INTO AdventureWorksLT2012.SalesLT.Product
                (Name, ProductNumber, Color, StandardCost, ListPrice, Size, Weight, ProductCategoryID, ProductModelID, SellStartDate, SellEndDate, DiscontinuedDate, ThumbNailPhoto, ThumbnailPhotoFileName)
                VALUES
                (@Name, @ProductNumber, @Color, @StandardCost, @ListPrice, @Size, @Weight, @ProductCategoryID, @ProductModelID, @SellStartDate, @SellEndDate, @DiscontinuedDate, @ThumbNailPhoto, @ThumbnailPhotoFileName);

                SELECT @@Identity from AdventureWorksLT2012.SalesLT.Product
                ";

            cmd.Parameters.AddWithValue("@Name", newProduct.ProductName);
            cmd.Parameters.AddWithValue("@ProductNumber", newProduct.ProductNumber);
            cmd.Parameters.AddWithValue("@StandardCost", newProduct.StandardCost);
            cmd.Parameters.AddWithValue("@ListPrice", newProduct.ListPrice);
            cmd.Parameters.AddWithValue("@SellStartDate", newProduct.SellStartDate);

            //Check for nulls, insert DBNull if property is null
            if (newProduct.Color == null) { cmd.Parameters.AddWithValue("@Color", DBNull.Value); }
            else { cmd.Parameters.AddWithValue("@Color", newProduct.Color); }

            if (newProduct.Size == null) { cmd.Parameters.AddWithValue("@Size", DBNull.Value); }
            else { cmd.Parameters.AddWithValue("@Size", newProduct.Size); }

            if (newProduct.Weight == null) { cmd.Parameters.AddWithValue("@Weight", DBNull.Value); }
            else { cmd.Parameters.AddWithValue("@Weight", newProduct.Weight); }

            if (newProduct.ProductCategoryID == null) { cmd.Parameters.AddWithValue("@ProductCategoryID", DBNull.Value); }
            else { cmd.Parameters.AddWithValue("@ProductCategoryId", newProduct.ProductCategoryID); }

            if (newProduct.ProductModelID == null) { cmd.Parameters.AddWithValue("@ProductModelID", DBNull.Value); }
            else { cmd.Parameters.AddWithValue("@ProductModelID", newProduct.ProductModelID); }

            if (newProduct.SellEndDate == null) { cmd.Parameters.AddWithValue("@SellEndDate", DBNull.Value); }
            else { cmd.Parameters.AddWithValue("@SellEndDate", newProduct.SellEndDate); }

            if (newProduct.DiscontinuedDate == null) { cmd.Parameters.AddWithValue("@DiscontinuedDate", DBNull.Value); }
            else { cmd.Parameters.AddWithValue("@DiscontinuedDate", newProduct.DiscontinuedDate); }

            if (newProduct.ThumbNailPhoto == null) { cmd.Parameters.AddWithValue("@ThumbNailPhoto", DBNull.Value); }
            else { cmd.Parameters.AddWithValue(@"ThumbNailPhoto", newProduct.ThumbNailPhoto); }

            if (newProduct.ThumbNailFileName == null) { cmd.Parameters.AddWithValue("@ThumbnailPhotoFileName", DBNull.Value); }
            else { cmd.Parameters.AddWithValue("@ThumbnailPhotoFileName", newProduct.ThumbNailFileName); }

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

        public Product GetProduct(int Id)
        {
            Product productToRetun = null;

            SqlCommand cmd = GetDbCommand();
            cmd.CommandText = "SELECT * FROM SalesLT.Product WHERE ProductID = @Id";
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

        public List<Product> SearchProduct(string query)
        {
            //Variable
            List<Product> colProducts = new List<Product>();
            int x;
            if (Int32.TryParse(query, out x)) { };


            //Connection
            SqlCommand cmd = GetDbCommand();
            //SELECT (TQL)
            cmd.CommandText = @"
                SELECT *
                FROM SalesLT.Product
                WHERE Name LIKE '%' + @query + '%'
                OR ProductID LIKE @id
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

        private SqlCommand GetDbCommand()
        {
            //Set up database connection
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["Utility"].ConnectionString;

            //Command
            SqlCommand cmd = conn.CreateCommand();

            return cmd;
        }

        private static Product BuildProduct(SqlDataReader reader)
        {
            var ProductDTO = new Product
            {
                ProductID = (int)reader["ProductID"],
                ProductName = (string)reader["Name"],
                ProductNumber = (string)reader["ProductNumber"],
                StandardCost = (decimal)reader["StandardCost"],
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
