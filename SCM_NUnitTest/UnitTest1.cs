using NUnit.Framework;
using SCM_Problem_1.Model;
using SCM_Problem_1.Services.InterFace;
using SCM_Problem_1.Services.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCM_NUnitTest
{
    public class Tests
    {
        private IOrderValueCalc orderValueCalc;

        
        public  Tests()
        {
            IUnitPrice unitPrice = new UnitPriceService();
            IGetPromote promotion = new GetPromotionsService();
            orderValueCalc = new CalculateOrderValueService(unitPrice, promotion);
        }

        [Test]
        public async Task Calculate_Order_Senario_1_Excepted_Return_Value_100()
        {
            int exceptedOrderValue = 100;

            List<SkuOrder> skuOrders = new List<SkuOrder>()
            {
                new SkuOrder(){SkuOrderId = SKU.A,Quantity =1},
                new SkuOrder(){SkuOrderId = SKU.B,Quantity =1},
                new SkuOrder(){SkuOrderId= SKU.C,Quantity =1}
            };

            var resutl = await this.orderValueCalc.CalculateTheVlue(skuOrders);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(exceptedOrderValue, resutl);
        }

    }
}