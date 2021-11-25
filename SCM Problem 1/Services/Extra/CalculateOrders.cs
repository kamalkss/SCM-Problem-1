using SCM_Problem_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace SCM_Problem_1.Services.Extra
{
    public static class CalculateOrders
    {
        public static int Calculate(this SkuOrder skuOrder, int defaultValue, ActivePromotion activePromotion)
        {
            int applyPromotionQuantity = 0;
            if (skuOrder.Quantity >= activePromotion.Quantity)
            {
                applyPromotionQuantity = skuOrder.Quantity / activePromotion.Quantity;
            }
            if (applyPromotionQuantity != 0)
            {
                return (applyPromotionQuantity * activePromotion.Value) + (skuOrder.Quantity - (activePromotion.Quantity * applyPromotionQuantity)) * defaultValue;
            }
            return skuOrder.Quantity * defaultValue;
        }
    }
}
