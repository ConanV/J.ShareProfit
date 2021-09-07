using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ShareProfit
{
    public abstract class AbstractProfitCalculator
    {

        public AbstractProfitCalculator()
        {

        }

        private double? _profitRate;
        public double ProfitRate
        {
            get => _profitRate.Value;
            set
            {
                if (_profitRate == null)
                {
                    _profitRate = value;
                }
                else
                {
                    throw new Exception("不能重复设置分润率");
                }
            }
        }

        private PayoffEnum payoffPeriodStatus;
        public PayoffEnum PayoffPeriodStatus
        {
            get
            {
                return payoffPeriodStatus ;
            }
            protected set => payoffPeriodStatus = value;
        }


        /// <summary>
        /// 计算分润金额
        /// </summary>
        /// <returns></returns>
        public abstract decimal CalculateShareProfit(decimal income);
    }
}
