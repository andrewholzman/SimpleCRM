using AdventureWorks.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.ViewModels
{
    class SalesOrderSearchViewModel
    {
        public SalesOrderSearchViewModel(SalesOrder SOrder)
        {
            SalesOrderID = SOrder.SalesOrderID;
            RevisionNumber = SOrder.RevisionNumber;
            OrderDate = SOrder.OrderDate;
            Status = SOrder.Status;
            OrderOnlineFlag = SOrder.OrderOnlineFlag;
            SalesOrderNumber = SOrder.SalesOrderNumber;
            PurchaseOrderNumber = SOrder.PurchaseOrderNumber;
            AccountNumber = SOrder.AccountNumber;
            ShipMethod = SOrder.ShipMethod;
            SubTotal = SOrder.SubTotal;
            TotalDue = SOrder.TotalDue;

        }
        public int SalesOrderID { get; set; }
        public byte RevisionNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public byte Status { get; set; }
        public bool OrderOnlineFlag { get; set; }
        //This one has no Data Type in SQL Server
        public string SalesOrderNumber { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string AccountNumber { get; set; }
        public string ShipMethod { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalDue { get; set; }
    }
}

