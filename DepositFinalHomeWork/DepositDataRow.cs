using System;
using System.Collections.Generic;
using System.Text;

namespace DepositFinalHomeWork
{
    public record DepositDataRow(
        int NumberOfMonthsByDigit, 
        string Year,
        double CurrentDepositAmount, 
        double ProfitForMonth, 
        double ProfitForPeriod, 
        string CurrentDepositMonthByWords, 
        double TotalDepositSum);
}