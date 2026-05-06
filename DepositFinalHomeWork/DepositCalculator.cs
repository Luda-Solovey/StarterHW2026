
namespace DepositFinalHomeWork
{
    public class DepositCalculator
    {
        public DepositDataRow[] GetDepositCalculationTable(DepositRequestData clientsRequest)
        {
            DepositDataRow[] depositResults = new DepositDataRow[clientsRequest.DurationInMonths];
            double profitForPeriod = 0;

            var currentDepositAmount = clientsRequest.InitialAmount; // локальна змінна для зберігання поточної суми депозиту, яка буде оновлюватися в циклі

            for (int i = 0; i < clientsRequest.DurationInMonths; i++)
            {
                string currentDepositMonthByWords = clientsRequest.OpenDate.AddMonths(i + 1).ToString("MMMM"); // Назва місяця
                string currentDepositYearByWords = clientsRequest.OpenDate.AddMonths(i + 1).ToString("yyyy"); // Рік
                double profitForMonth = currentDepositAmount * clientsRequest.DepositRate / 100 / 12; // прибуток за місяц
                double profitPerEachMonth = currentDepositAmount + profitForMonth; // нова загальна сума
                profitForPeriod = profitForPeriod + profitForMonth; // прибуток за весь період

                depositResults[i] = new DepositDataRow
                (
                    NumberOfMonth: i + 1,
                    CurrentDepositMonth: currentDepositMonthByWords,
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
