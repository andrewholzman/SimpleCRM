using AdventureWorks.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.ViewModels
{
    public class ProductViewModel
    {

        public ProductViewModel(SalesOrderDetail soDetail)
        {
            ProductID = soDetail.ProductID;
            OrderQty = soDetail.OrderQty;
            UnitPrice = soDetail.UnitPrice;
            UnitePriceDiscount = soDetail.UnitPriceDiscount;
            LineTotal = soDetail.LineTotal;
        }

        public int ProductID { get; set; }
        public Int16 OrderQty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitePriceDiscount { get; set; }
        public decimal LineTotal { get; set; }
    }
}
