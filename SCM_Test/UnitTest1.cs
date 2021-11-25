
using SCM_Problem_1.Model;
using SCM_Problem_1.Services.InterFace;
using SCM_Problem_1.Services.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SCM_Test
{
    
    public class UnitTest1
    {
        private IOrderValueCalc orderValueCalc;

        public  UnitTest1()
        {
            IUnitPrice unitPrice = new UnitPriceService();
            IGetPromote promotion = new GetPromotionsService();
            orderValueCalc = new CalculateOrderValueService(unitPrice, promotion);
        }

        [Fact]
        public async Task Calculate_Order_Senario_1_Excepted_Return_Value_100()
        {
            int exceptedOrderValue = 100;

            List<SkuOrder> skuOrders = new List<SkuOrder>()
            {
                new SkuOrder(){SkuOrderId = SKU.A,Quantity =1},
                new SkuOrder(){SkuOrderId = SKU.B,Quantity =1},
                new SkuOrder(){SkuOrderId= SKU.C,Quantity =1}
            };

            var resutl = await orderValueCalc.CalculateTheVlue(skuOrders);

           Assert.Equal(exceptedOrderValue, resutl);
        }

        [Fact]
        public async Task Calculate_Order_Scenario2_Excepted_Retrun_Value_370()
        {
            int exceptedOrderValue = 370;

            List<SkuOrder> skuOrders = new List<SkuOrder>()
            {
                new SkuOrder(){SkuOrderId = SKU.A,Quantity =5},
                new SkuOrder(){SkuOrderId = SKU.B,Quantity =5},
                new SkuOrder(){SkuOrderId= SKU.C,Quantity =1}
            };

            var resutl = await orderValueCalc.CalculateTheVlue(skuOrders);

            Assert.Equal(exceptedOrderValue, resutl);
        }

        [Fact]
        public async Task Calculate_Order_Scenario3_Excepted_Retrun_Value_280()
        {
            int exceptedOrderValue = 280;

            List<SkuOrder> skuOrders = new List<SkuOrder>()
            {
                new SkuOrder(){SkuOrderId = SKU.A,Quantity =3},
                new SkuOrder(){SkuOrderId = SKU.B,Quantity =5},
                new SkuOrder(){SkuOrderId= SKU.C,Quantity =1},
                new SkuOrder(){SkuOrderId= SKU.D,Quantity =1},
            };

            var resutl = await orderValueCalc.CalculateTheVlue(skuOrders);

            Assert.Equal(exceptedOrderValue, resutl);
        }
    }
}