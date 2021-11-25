using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM_Problem_1.Model
{
    public class UnitPrice
    {
        public Guid UnitPriceId { get; set; }
        public SKU Name { get; set; }
        public int Value { get; set; }
    }
}
