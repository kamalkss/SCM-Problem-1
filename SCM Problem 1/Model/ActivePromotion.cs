using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM_Problem_1.Model
{
    public class ActivePromotion
    {
        public Guid ActivePromotionId { get; set; }
        public IEnumerable<SKU> SkuUnit { get; set; }
        public int Quantity { get; set; }
        public int Value { get; set; }
        public bool ActiveMulti { get; set; }
    }
}
