using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ShareProfit
{
    public class Store_Platform : AbstractStore
    {
        public Store_Platform( string storeId, double? shareProfitRate = null, List<AbstractStore> storeChildren = null) :
            base(storeId, storeChildren)
        {
            
        }

        public override double GetShareProfitRate()
        {
            return 0.08;
        }
    }
}
