﻿using AdventureWorks.Business.Models;
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
        Customer GetCustomer(int Id);
        Address GetAddress(int customerID);
    }
}
