using System;
using System.Collections.Generic;
using System.Text;

namespace DepositFinalHomeWork
{
    public class DepositDataRow
    {
        public int NumberOfMonthsByDigit { get; set; }
        public short Year { get; set; }
        public double CurrentDepositAmount { get; set; }
        public double ProfitForMonth { get; set; }
        public double ProfitForPeriod { get; set; }
        public string CurrentDepositMonth { get; set; } = string.Empty;
        public double TotalDepositSum { get; set; }
    }
}
