using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCM_Problem_1.Model;
using SCM_Problem_1.Services.Extra;
using SCM_Problem_1.Services.InterFace;

namespace SCM_Problem_1.Services.Services
{
    public class CalculateOrderValueService : IOrderValueCalc
    {
        private readonly IUnitPrice _unitPrice;
        private readonly IGetPromote _getPromot;

        public CalculateOrderValueService(IUnitPrice unitPrice,IGetPromote getPromote)
        {
            _unitPrice = unitPrice;
            _getPromot = getPromote;
        }

        private int ApplyPromotion(SkuOrder skuOrder,int defaultPrice,ActivePromotion promotion)
        {
            return skuOrder.Calculate(defaultPrice, promotion);
        }

        /// <summary>
        /// Calculate Order value
        /// </summary>
        /// <param name="skuUnits">Sku order units</param>
        /// <returns>Total value of order</returns>
        public async Task<int> CalculateTheVlue(List<SkuOrder> SkuUnit)
        {
            var unitPrices = await _unitPrice.GetUnitPrice();
            var promotions = await _getPromot.GetPromotions();

            int orderValue = 0;

            var SKUs = new List<SKU>() { SKU.A, SKU.B };
            var SkuABIds = SkuUnit.Where(c => SKUs.Contains(c.SkuOrderId)).ToList();

            SkuABIds.ForEach(sku=>
            {
                var unitPrice = unitPrices.FirstOrDefault(c => c.Name == sku.SkuOrderId).Value;
                var Promotion = promotions.FirstOrDefault(c => !c.ActiveMulti && c.SkuUnit.Contains(sku.SkuOrderId));

                orderValue += ApplyPromotion(sku, unitPrice, Promotion);
            });

            var SkuCDIds = SkuUnit.Except(SkuABIds).ToList();

            if(SkuCDIds.Count ==2)
            {
                orderValue += promotions.FirstOrDefault(c => c.ActiveMulti).Value;
            }
            else
            {
                SkuCDIds.ForEach(SkuOrder =>
                {
                    var unitprice = unitPrices.FirstOrDefault(c=>c.Name == SkuOrder.SkuOrderId).Value;
                    orderValue += SkuOrder.Quantity * unitprice;
                });
            }

            return orderValue;
        }
    }
}
