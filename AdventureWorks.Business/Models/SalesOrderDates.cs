using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Models
{
    public class SalesOrderDates //model for SalesOrderDates
    {
        public int SalesOrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ShipDate { get; set; }  
    }
}
