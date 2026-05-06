using System;
using System.Collections.Generic;
using System.Text;

namespace DepositFinalHomeWork
{
    public record DepositDataRow(
        int NumberOfMonth, 
        string Year,
        double CurrentDepositAmount, 
        double ProfitForMonth, 
        double ProfitForPeriod, 
        string CurrentDepositMonth, 
        double TotalDepositSum);
}