using AdventureWorks.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Data
{
    public interface IGetCustomerInfo //interface to accessing customer info
    {
        List<Customer> SearchCustomer(string query);
        Customer GetCustomer(int Id);
        int GetCustomerID(int salesOrderID);
        int GetCustomerID();
        Address GetAddress(int customerID);
        int GetAddressID();
        CustomerAddress GetCustomerAddress(int customerID);
        void UpdateCustomer(Customer custToUpdate);
        void AddCustomer(Customer custToAdd);
        void UpdateAddress(Address addressToUpdate);
        void AddAddress(Address addressToAdd);
        void AddCustomerAddress(CustomerAddress custAddress);


    }
}
