using SCM_Problem_1.Model;
using SCM_Problem_1.Services.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM_Problem_1.Services.Services
{
    public class UnitPriceService : IUnitPrice
    {
        public  async Task<IEnumerable<UnitPrice>> GetUnitPrice()
        {
            return new List<UnitPrice>()
            {
                new UnitPrice(){UnitPriceId = Guid.NewGuid(),Name=SKU.A,Value=50},
                new UnitPrice(){UnitPriceId = Guid.NewGuid(),Name=SKU.B,Value=30},
                new UnitPrice(){UnitPriceId = Guid.NewGuid(),Name=SKU.C,Value=20},
                new UnitPrice(){UnitPriceId = Guid.NewGuid(),Name=SKU.D,Value=10}
            }; 
        }
    }
}
