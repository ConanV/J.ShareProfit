using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ShareProfit
{
    /// <summary>
    /// 商铺
    /// </summary>
    public abstract class AbstractStore
    {
        private PayoffEnum _payoffEnum;
        private readonly string _storeId;
 
        private readonly List<AbstractStore> _storeChildren;
        public AbstractStore(string storeId, List<AbstractStore> storeChildren)
        {
            _storeId = storeId;
            _storeChildren = storeChildren;
        }

        /// <summary>
        /// 分润率
        /// </summary>
        public abstract double GetShareProfitRate();

        /// <summary>
        /// 子商铺
        /// </summary>
        public List<AbstractStore> StoreChildren
        {
            get => _storeChildren;
        }


        public string StoreId
        {
            get => _storeId;
        }


        public PayoffEnum PayoffPeriodStatus
        {
            get => _payoffEnum;
            set => _payoffEnum = value;
        }

        public decimal Payoff { get; set; }
    }
}
