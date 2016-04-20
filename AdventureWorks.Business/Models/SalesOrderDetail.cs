using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Models
{
    public class SalesOrderDetail
    {
        public int SalesOrderID { get; set; }
        public int SalesOrderDetailID { get; set; }
        public Int16 OrderQty { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitPriceDiscount { get; set; }
        public decimal LineTotal { get; set; }
        public Guid RowGuid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
