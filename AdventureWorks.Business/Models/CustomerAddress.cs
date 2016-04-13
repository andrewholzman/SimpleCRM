using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Models
{
    public class CustomerAddress
    {
        public int? CustomerId { get; set; }
        public int? AddressID { get; set; }
        public string AddressType { get; set; }

        public Guid RowGuid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
