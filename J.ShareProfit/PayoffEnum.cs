using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ShareProfit
{
    public enum PayoffEnum
    {
        /// <summary>
        /// 回本中
        /// </summary>
        PayoffPeriod = 1,
        /// <summary>
        /// 回本完成
        /// </summary>
        PayoffPeriodOfEnd = 5,
        /// <summary>
        /// 没有回本情况
        /// </summary>
        NoPayoffPeriod = 10
    }
}
