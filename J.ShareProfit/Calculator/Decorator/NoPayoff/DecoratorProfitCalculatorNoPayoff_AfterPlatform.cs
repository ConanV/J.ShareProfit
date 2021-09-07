using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ShareProfit
{
    public class DecoratorProfitCalculatorNoPayoff_AfterPlatform : DecoratorProfitCalculator
    {
        public DecoratorProfitCalculatorNoPayoff_AfterPlatform(AbstractProfitCalculator decorator, AbstractStore store) : base(decorator, store)
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
            var platformIncome = income - base.CalculateShareProfit(income);
            Store.Payoff = platformIncome * Convert.ToDecimal(Store.GetShareProfitRate());
            if (Store.StoreChildren == null)
            {
                return platformIncome;
            }
            else
            {
                return Store.Payoff;
            }
        }
    }
}
