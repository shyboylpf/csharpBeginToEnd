using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumTest2
{
    public enum AdjustmentMethods
    {
        None,
        SplitOnly,
        CashDividendOnly,
        All = SplitOnly | CashDividendOnly,
    }
}