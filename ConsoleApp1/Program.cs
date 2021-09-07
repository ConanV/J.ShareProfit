using System;
using WindowsFormsApp1.ShareProfit;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string tmp = string.Empty;

            var servie = new ProfitCalculatorService();
            //var list = servie.CalculateProfit_Sale();
            //foreach (var item in list)
            //{
            //    tmp += $"{item.StoreId}：{item.Payoff}\r\n";
            //}


            //var list = servie.CalculateProfit_Sale2();
            //foreach (var item in list)
            //{
            //    tmp += $"{item.StoreId}：{item.Payoff}\r\n";
            //    if (item.StoreChildren != null)
            //    {
            //        foreach (var item2 in item.StoreChildren)
            //        {
            //            tmp += $"    {item2.StoreId}：{item2.Payoff}\r\n";
            //        }
            //    }
            //}

            var list = servie.CalculateProfit_Sale3();
            foreach (var item in list)
            {
                tmp += $"{item.StoreId}：{item.Payoff}\r\n";
                if (item.StoreChildren != null)
                {
                    foreach (var item2 in item.StoreChildren)
                    {
                        tmp += $"    {item2.StoreId}：{item2.Payoff}\r\n";

                        if (item2.StoreChildren != null)
                        {
                            foreach (var item3 in item2.StoreChildren)
                            {
                                tmp += $"          {item3.StoreId}：{item3.Payoff}\r\n";
                            }
                        }
                    }
                }
            }


            Console.WriteLine(tmp);
            Console.ReadLine();
        }
    }
}
