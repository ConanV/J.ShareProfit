using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ShareProfit
{
    public class Store_Service : AbstractStore
    {
        private readonly int _level;


        public Store_Service(string storeId, double? shareProfitRate = null, List<AbstractStore> storeChildren = null, int _level = 0) :
            base(storeId, storeChildren)
        {
            Level = _level;
        }


        public override double GetShareProfitRate()
        {
            if (Level == 0)
            {
                if (PayoffPeriodStatus == PayoffEnum.PayoffPeriod)
                {//回本中
                    return 0.05;
                }
                else if (PayoffPeriodStatus == PayoffEnum.PayoffPeriodOfEnd)
                {
                    return 0.1;
                }
                else
                {
                    return 0.5;
                }
            }
            else
            {
                if (Level == 1)
                {
                    return 0.2;
                }
                else
                {
                    return 0.8;
                }
            }
        }

        public int Level { get; }
    }
}
