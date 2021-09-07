using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ShareProfit
{
    public class DecoratorProfitCalculator : AbstractProfitCalculator
    {
        public AbstractProfitCalculator Decorator { get; }
        private readonly AbstractStore _store;

        public DecoratorProfitCalculator(AbstractProfitCalculator decorator, AbstractStore store)
        {
            Decorator = decorator;
            _store = store;
        }

        public AbstractStore Store
        {
            get => _store;
        }


        /// <summary>
        /// 得到分润金额
        /// </summary>
        /// <returns></returns>
        public override decimal CalculateShareProfit(decimal income)
        {
            return Decorator.CalculateShareProfit(income);
        }

    }
}
