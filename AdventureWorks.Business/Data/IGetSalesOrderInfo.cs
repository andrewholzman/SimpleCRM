using AdventureWorks.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Data
{
    public interface IGetSalesOrderInfo //interface for accessing sales order info
    {
        List<SalesOrder> SearchSalesOrder(string query);
        SalesOrder GetSalesOrder(int SalesOrderID);
        SalesOrderDates GetDates(int SalesOrderID);
        List<SalesOrderDetail> GetSalesOrderDetails(int salesOrderID);

        int AddSalesOrderHeader(SalesOrderHeader soHeader);
        void AddSalesOrderDetail(SalesOrderDetail soDetail);
    }
}
