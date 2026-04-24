
namespace DepositFinalHomeWork
{
    public class DepositCalculator
    {
        private const int DepositRate = 12;
        public double InitialAmount { get; set; }
        public DateOnly OpenDate { get; set; }
        public byte DurationInMonths { get; set; } = 4;

        //ця властивість в коді не використовується. Залишила як приклад computed-властивості
        public byte DurationInYears
        {
            get
            { return (byte)(DurationInMonths / 12); } //це computed властивість. Вона не зберігає значення, а обчислює його на основі DurationInMonths щоразу,
                                                      //коли до неї звертаються. Це дозволяє завжди отримувати актуальне значення тривалості в роках, навіть
                                                      //якщо DurationInMonths змінюється.
                                                      //Для computed властивісті Сеттер  не потрібен
        }

        public DepositDataRow[] GetDepositCalculationTable(DepositCalculator clientsWishes)
        {
            DepositDataRow[] depositResults = new DepositDataRow[clientsWishes.DurationInMonths];
            double profitForPeriod = 0;

            DepositDataRow dataForDisplay = new DepositDataRow
            {
                CurrentDepositAmount = clientsWishes.InitialAmount
            };

            for (int i = 0; i < clientsWishes.DurationInMonths; i++)
            {
                string currentDepositMonthByWords = clientsWishes.OpenDate.AddMonths(i + 1).ToString("MMMM"); // Назва місяця
                double profitForMonth = dataForDisplay.CurrentDepositAmount * DepositRate /100/ 12; // прибуток за місяц
                double profitPerEachMonth = dataForDisplay.CurrentDepositAmount + profitForMonth; // нова загальна сума
                profitForPeriod = profitForPeriod + profitForMonth; // прибуток за весь період

                depositResults[i] = new DepositDataRow
                {
                    NumberOfMonthsByDigit = i + 1,
                    CurrentDepositMonth = currentDepositMonthByWords,
                    Year = (short)clientsWishes.OpenDate.Year,
                    ProfitForMonth = Math.Round(profitForMonth, 2),
                    TotalDepositSum = Math.Round(profitPerEachMonth, 2),
                    ProfitForPeriod = Math.Round(profitForPeriod, 2)
                };

                dataForDisplay.CurrentDepositAmount = profitPerEachMonth;
            }
            return depositResults;
        }

    }
}
