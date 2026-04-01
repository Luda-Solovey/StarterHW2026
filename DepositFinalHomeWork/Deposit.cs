using System;
using System.Collections.Generic;
using System.Text;

namespace DepositFinalHomeWork
{
    public class Deposit
    {
        private int durationInYears;
        public double DepositSum { get; set; }
        public DateOnly DepositOpenDate { get; set; }

        public int DurationInMonths { get; set; } = 4;

        public int DurationInYears
        {
            get
            { return durationInYears; }
            set 
            { durationInYears = DurationInMonths / 12; }
        }



        public double CalculateDepositProfit(double depositSum, int years)
        {
            double profit = 0;

             return profit = depositSum * (1 + 0.15 * years);
            //if (years <= 1)
            //{
            //    profit = depositSum * ( 1 + 0.15 * years);
            //}
            //else 
            //{
            //    profit = DepositSum * 0.20;
            //}
            //return profit;
        
        }
    }
}
