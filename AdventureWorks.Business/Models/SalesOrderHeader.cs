using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Models
{
    public class SalesOrderHeader
    {
        public int SalesOrderID { get; set; }
        public int RevisionNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ShipDate { get; set; }
        public int Status { get; set; }
        public byte OrderOnlineFlag { get; set; }
        //This one has no Data Type in SQL Server
        public string SalesOrderNumber { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string AccountNumber { get; set; }
        public int CustomerID { get; set; }
        public int ShipToAddressID { get; set; }
        public int BillToAddressID { get; set; }
        public string ShipMethod { get; set; }
        public string CreditCardApprovalCode { get; set; }
        public float SubTotal { get; set; }
        public float TaxAmt { get; set; }
        public float Freight { get; set; }
        //This one has no Data Type in SQL Server
        public float TotalDue { get; set; }
        public string Comment { get; set; }
        public Guid RowGuid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
