﻿using SCM_Problem_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM_Problem_1.Services.InterFace
{
    public interface IOrderValueCalc
    {
        Task<int> CalculateTheVlue(List<SkuOrder> SkuUnit);
    }
}
