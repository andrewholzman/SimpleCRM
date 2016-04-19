using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.Business.Models;

namespace AdventureWorks.Business.Data
{
    public static class DependencyInjectorUtility
    {
        public static IGetCustomerInfo GetCustomerInfo()
        {
            return new CustomerUtility();
        }

        public static IGetProductInfo GetProductInfo()
        {
            return new ProductUtility();
        }

        public static IGetSalesOrderInfo GetSalesInfo()
        {
            return new SalesOrderUtility();
        }
    }
}
