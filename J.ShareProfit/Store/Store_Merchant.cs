using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ShareProfit
{
    public class Store_Merchant : AbstractStore
    {
        public Store_Merchant( string storeId, double? shareProfitRate = null, List<AbstractStore> storeChildren = null) :
            base( storeId, storeChildren)
        {
            
        }


        public override double GetShareProfitRate()
        {
            if (PayoffPeriodStatus == PayoffEnum.PayoffPeriod)
            {//回本中
                return 0.3;
            }
            else 
            {
                return 0.8;
            }
        }
    }
}
