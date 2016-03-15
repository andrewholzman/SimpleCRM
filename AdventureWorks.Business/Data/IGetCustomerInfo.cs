using AdventureWorks.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Data
{
    public interface IGetCustomerInfo
    {
        List<Customer> SearchCustomer(string query);
        List<Product> SearchProduct(string query);
        Customer GetCustomer(int Id);
        Address GetAddress(int customerID);
        Product GetProduct(int Id);
        Product AddProduct(Product product);
    }
}
