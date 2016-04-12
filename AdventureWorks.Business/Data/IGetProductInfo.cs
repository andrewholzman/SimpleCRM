using AdventureWorks.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Data
{
    public interface IGetProductInfo
    {
        List<Product> SearchProduct(string query);
        Product GetProduct(int Id);
        void AddProduct(Product newProduct);
    }
}
