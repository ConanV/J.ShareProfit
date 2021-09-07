using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ShareProfit
{
    public class ProfitCalculatorService
    {
        public List<AbstractStore> CalculateProfit_Sale()
        {
            List<AbstractStore> storeList = new List<AbstractStore>();

            storeList.Add(new Store_Platform("平台"));
            storeList.Add(new Store_Merchant("商户"));
            storeList.Add(new Store_Device("设备商"));
            storeList.Add(new Store_Service("服务商"));
            return CalculateProfitHasPayoffPeriod(storeList, PayoffEnum.PayoffPeriod);
        }

        public List<AbstractStore> CalculateProfit_Sale2()
        {
            List<AbstractStore> storeList = new List<AbstractStore>();

            storeList.Add(new Store_Platform("平台"));
            storeList.Add(new Store_Merchant("商户"));
            storeList.Add(new Store_Device("设备商"));


            AbstractStore serviceL1 = new Store_Service("1级服务商", null, null, 1);
            AbstractStore serviceL2 = new Store_Service("2级服务商", null, null, 2);
            var serivceList = new List<AbstractStore>();
            serivceList.Add(serviceL1);
            serivceList.Add(serviceL2);
            AbstractStore service = new Store_Service("服务商", null, serivceList);
            storeList.Add(service);



            return CalculateProfitHasPayoffPeriod(storeList, PayoffEnum.PayoffPeriodOfEnd);
        }

        public List<AbstractStore> CalculateProfit_Sale3()
        {
            List<AbstractStore> storeList = new List<AbstractStore>();

            AbstractStore serviceL1 = new Store_Service("1级服务商", null, null, 1);
            AbstractStore serviceL2 = new Store_Service("2级服务商", null, null, 2);
            var serivceList = new List<AbstractStore>();
            serivceList.Add(serviceL1);
            serivceList.Add(serviceL2);
            AbstractStore service = new Store_Service("服务商", null, serivceList);

            AbstractStore platform = new Store_Platform("平台", null, new List<AbstractStore>() { service });
            storeList.Add(platform);

            storeList.Add(new Store_Merchant("商户"));

            return CalculateProfitNoPayoffPeriod(storeList);
        }



        private static List<AbstractStore> CalculateProfitHasPayoffPeriod(List<AbstractStore> storeList, PayoffEnum payoffStatus)
        {
            AbstractProfitCalculator calculator = new ProfitCalculator_Sale(payoffStatus);
            //1.平台分润
            var platform = storeList.Where(x => x is Store_Platform).FirstOrDefault();
            calculator = new DecoratorProfitCalculator_Platform(calculator, platform);
            //2.其他商户分润
            var others = storeList.Where(x => !(x is Store_Platform));
            foreach (var item in others)
            {
                calculator = new DecoratorProfitCalculatorPayoff_Others(calculator, item);
                if (item.StoreChildren != null)
                {
                    foreach (var item2 in item.StoreChildren)
                    {//3.下级分润
                        calculator = new DecoratorProfitCalculatorPayoff_OthersLevel(calculator, item2);
                    }
                }
            }

            calculator.CalculateShareProfit(100m);
            return storeList;
        }

        private static List<AbstractStore> CalculateProfitNoPayoffPeriod(List<AbstractStore> storeList)
        {
            AbstractProfitCalculator calculator = new ProfitCalculator_Sale(PayoffEnum.NoPayoffPeriod);
            //1.平台分润加入
            var platform = storeList.Where(x => x is Store_Platform).FirstOrDefault();
            calculator = new DecoratorProfitCalculator_Platform(calculator, platform);
            
            //2.与平台平行级别的分润
            var others = storeList.Where(x => !(x is Store_Platform));
            foreach (var item in others)
            {
                calculator = new DecoratorProfitCalculatorNoPayoff_Others(calculator, item);
            }

            if (platform.StoreChildren != null)
            {
                foreach (var item2 in platform.StoreChildren)
                {//3.平台下级分润
                    calculator = new DecoratorProfitCalculatorNoPayoff_AfterPlatform(calculator, item2);
                    if (item2.StoreChildren != null)
                    {
                        foreach (var item3 in item2.StoreChildren)
                        {//4.再下级分润
                            calculator = new DecoratorProfitCalculatorPayoff_OthersLevel(calculator, item3);
                        }
                    }
                }
            }

            calculator.CalculateShareProfit(100m);
            return storeList;
        }
    }
}
