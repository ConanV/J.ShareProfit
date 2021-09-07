using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ShareProfit
{
    public class ProfitCalculator_Sale : AbstractProfitCalculator
    {

        public ProfitCalculator_Sale(PayoffEnum payoffPeriodStatus)
        {
            PayoffPeriodStatus = payoffPeriodStatus;
        }



        /// <summary>
        /// 得到分润金额
        /// </summary>
        /// <returns></returns>
        public override decimal CalculateShareProfit(decimal income)
        {
            return income;
        }
    }
}
