using SCM_Problem_1.Model;
using SCM_Problem_1.Services.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM_Problem_1.Services.Services
{
    public class GetPromotionsService : IGetPromote
    {
        public async Task<IEnumerable<ActivePromotion>> GetPromotions()
        {
            return new List<ActivePromotion>()
            {
                new ActivePromotion() { ActivePromotionId = Guid.NewGuid(), SkuUnit = new List<SKU> { SKU.A }, Quantity = 3, Value = 130, ActiveMulti = false },
                new ActivePromotion() { ActivePromotionId = Guid.NewGuid(), SkuUnit = new List<SKU> { SKU.B }, Quantity = 2, Value = 45, ActiveMulti = false },
                new ActivePromotion() { ActivePromotionId = Guid.NewGuid(), SkuUnit = new List<SKU> { SKU.C, SKU.D }, Quantity = 0, Value = 30, ActiveMulti = true }
            };
        }
    }
}
