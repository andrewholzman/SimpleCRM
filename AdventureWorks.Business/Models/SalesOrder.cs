using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Models
{
    public class SalesOrder
    {
        public int SalesOrderID { get; set; }
        public byte RevisionNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public byte Status { get; set; }
        public Boolean OrderOnlineFlag { get; set; }
        //This one has no Data Type in SQL Server
        public string SalesOrderNumber { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string AccountNumber { get; set; }
        public string ShipMethod { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalDue { get; set; }
    }
}
