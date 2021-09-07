using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ShareProfit
{
    public class DecoratorProfitCalculator_Platform : DecoratorProfitCalculator
    {
        public DecoratorProfitCalculator_Platform(AbstractProfitCalculator decorator, AbstractStore store) : base(decorator, store)
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
            base.CalculateShareProfit(income);
            Store.Payoff = income * Convert.ToDecimal(Store.GetShareProfitRate());
            return income - Store.Payoff;
        }
    }
}
