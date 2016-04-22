using AdventureWorks.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.ViewModels
{
    class SalesOrderProductViewModel
    {
        public SalesOrderProductViewModel(SalesOrderDetail soDetail)
        {
            ProductID = soDetail.ProductID;
            OrderQty = soDetail.OrderQty;
            UnitPrice = soDetail.UnitPrice;
            UnitPriceDiscount = soDetail.UnitPriceDiscount;
            LineTotal = soDetail.LineTotal;

        }
        public int ProductID { get; set; }
        public short OrderQty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitPriceDiscount { get; set; }
        public decimal LineTotal { get; set; }
    }
}

