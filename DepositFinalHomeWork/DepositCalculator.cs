
namespace DepositFinalHomeWork
{
    public class DepositCalculator
    {
        public DepositDataRow[] GetDepositCalculationTable(DepositData clientsWishes)
        {
            DepositDataRow[] depositResults = new DepositDataRow[clientsWishes.DurationInMonths];
            double profitForPeriod = 0;

            var currentDepositAmount = clientsWishes.InitialAmount; // локальна змінна для зберігання поточної суми депозиту, яка буде оновлюватися в циклі

            for (int i = 0; i < clientsWishes.DurationInMonths; i++)
            {
                string currentDepositMonthByWords = clientsWishes.OpenDate.AddMonths(i + 1).ToString("MMMM"); // Назва місяця
                string currentDepositYearByWords = clientsWishes.OpenDate.AddMonths(i + 1).ToString("yyyy"); // Рік
                double profitForMonth = currentDepositAmount * clientsWishes.DepositRate/100/12; // прибуток за місяц
                double profitPerEachMonth = currentDepositAmount + profitForMonth; // нова загальна сума
                profitForPeriod = profitForPeriod + profitForMonth; // прибуток за весь період

                depositResults[i] = new DepositDataRow
                (
                    NumberOfMonthsByDigit: i + 1,
                    CurrentDepositMonthByWords: currentDepositMonthByWords,
                    Year: currentDepositYearByWords,   
                    CurrentDepositAmount: currentDepositAmount,
                    ProfitForMonth: Math.Round(profitForMonth, 2),
                    ProfitForPeriod: Math.Round(profitForPeriod, 2),
                    TotalDepositSum: Math.Round(profitPerEachMonth, 2)
                );

                currentDepositAmount = profitPerEachMonth;
            }
            return depositResults;
        }

    }
}
