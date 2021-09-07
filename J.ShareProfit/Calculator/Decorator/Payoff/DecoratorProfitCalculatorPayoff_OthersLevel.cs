using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ShareProfit
{
    public class DecoratorProfitCalculatorPayoff_OthersLevel : DecoratorProfitCalculatorPayoff_Others
    {
        public DecoratorProfitCalculatorPayoff_OthersLevel(AbstractProfitCalculator decorator, AbstractStore store) : base(decorator, store)
        {
            Store.PayoffPeriodStatus = decorator.PayoffPeriodStatus;
            this.PayoffPeriodStatus = decorator.PayoffPeriodStatus;
        }

        /// <summary>
        /// 得到分润金额
        /// </summary>
        /// <returns></returns>
        public override decimal CalculateShareProfit(decimal income)
        {
            var leftIncome = base.CalculateShareProfit(income);
            Store.Payoff = leftIncome * Convert.ToDecimal(Store.GetShareProfitRate());
            return leftIncome;
        }
    }
}
