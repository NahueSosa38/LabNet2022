using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CustomerOrders
    {
        public string CustomerName { get; set; }
        public string CustomerRegion { get; set; }
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
