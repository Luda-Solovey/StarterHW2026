using System;
using System.Collections.Generic;
using System.Text;

namespace DepositFinalHomeWork
{
    public class DepositCalculator
    {
        private const int DepositRate = 12;

        public DepositData[] GetDepositCalculationTable(DepositData clientsWishes)
        {
            DepositData[] depositResults = new DepositData[clientsWishes.DurationInMonths];
            double profitForPeriod = 0;

            for (int i = 0; i < clientsWishes.DurationInMonths; i++)
            {
                string monthName = clientsWishes.OpenDate.AddMonths(i + 1).ToString("MMMM"); // Назва місяця
                double profitForMonth = clientsWishes.InitialAmount * DepositRate /100/ 12; // прибуток за місяц
                double total = clientsWishes.InitialAmount + profitForMonth; // нова загальна сума
                profitForPeriod = profitForPeriod + profitForMonth; // прибуток за весь період

                depositResults[i] = new DepositData
                {
                    NumberOfMonths = i + 1,
                    BillingMonth = monthName,
                    Year = (byte)clientsWishes.OpenDate.Year,
                    ProfitForMonth = Math.Round(profitForMonth, 2),
                    BillingDepositSum = Math.Round(total, 2),
                    ProfitForPeriod = Math.Round(profitForPeriod, 2)
                };

                clientsWishes.InitialAmount = total;
            }
            return depositResults;
        }

    }
}
