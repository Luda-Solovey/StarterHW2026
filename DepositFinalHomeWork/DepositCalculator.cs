using System;
using System.Collections.Generic;
using System.Text;

namespace DepositFinalHomeWork
{
    public class DepositCalculator
    {
        private int durationInYears;

        const int depositRate = 12;

        const int increaseForMonth = 1;

        public int NumberOfMonths { get; set; }

        public int Year { get; set; }
        public double InitialAmount { get; set; }
        public DateOnly OpenDate { get; set; }

        public double ProfitForMonth { get; set; }

        public double ProfitForPeriod { get; set; }

        public int DurationInMonths { get; set; } = 4;

        public string BillingMonth {  get; set; } = string.Empty;

        public double BillingDepositSum { get; set; }   

        public int DurationInYears
        {
            get
            { return DurationInMonths / 12; } //це computed властивість. Вона не зберігає значення, а обчислює його на основі DurationInMonths щоразу,
                                              //коли до неї звертаються. Це дозволяє завжди отримувати актуальне значення тривалості в роках, навіть
                                              //якщо DurationInMonths змінюється.
                                              //Для computed властивісті Сеттер  не потрібен
        }

        public DepositCalculator[] CalculateDepositProfit(double depositSum, int years, int month)
        {
            var depositResults = new DepositCalculator[month];
            double profitForPeriod = 0;

            for (int i = 0; i < month; i++)
            {
                string monthName = OpenDate.AddMonths(i + 1).ToString("MMMM"); // Назва місяця
                double profitForMonth = depositSum * depositRate /100/ 12; // прибуток за місяц
                double total = depositSum + profitForMonth; // нова загальна сума
                //double profitForPeriod = total - InitialAmount; // прибуток за весь період
                profitForPeriod = profitForPeriod + profitForMonth; // прибуток за весь період

                depositResults[i] = new DepositCalculator
                {
                    NumberOfMonths = i + 1,
                    BillingMonth = monthName,
                    Year = OpenDate.Year,
                    ProfitForMonth = Math.Round(profitForMonth, 2),
                    BillingDepositSum = Math.Round(total, 2),
                    ProfitForPeriod = Math.Round(profitForPeriod, 2)
                };

                depositSum = total;
            }
            return depositResults;
        }

   //     public List<DepositRow> CalculateDeposit(
   //decimal principal,    // початкова сума
   //decimal annualRate,   // річна ставка у %
   //int months,           // кількість місяців
   //DateTime startDate)   // стартовий місяць
   //     {
   //         var result = new List<DepositRow>();

   //         decimal monthlyRate = annualRate / 100 / 12;   // ставка на місяць
   //         decimal currentAmount = principal;

   //         for (int i = 0; i < months; i++)
   //         {
   //             string monthName = startDate.AddMonths(i).ToString("MMMM"); // Назва місяця

   //             decimal profit = currentAmount * monthlyRate;  // прибуток за місяць
   //             decimal total = currentAmount + profit;        // нова загальна сума

   //             // Додаємо рядок у таблицю
   //             result.Add(new DepositRow
   //             {
   //                 Month = monthName,
   //                 Profit = Math.Round(profit, 2),
   //                 TotalAmount = Math.Round(total, 2)
   //             });

   //             currentAmount = total; // капіталізація
   //         }

   //         return result;
   //     }

    }
}
