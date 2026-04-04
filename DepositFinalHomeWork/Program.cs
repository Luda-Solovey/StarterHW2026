using System.Text;

namespace DepositFinalHomeWork
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            DepositCalculator deposit1 = new DepositCalculator();

            //введення суми депозиту
            Console.WriteLine("Введіть суму депозита");

            string inputDepositSum = Console.ReadLine() ?? string.Empty;

            string normalizedInput = inputDepositSum.Replace(',', '.');

            bool isInputParsed = double.TryParse(normalizedInput, out double depositSum);

            if (isInputParsed && depositSum > 0)
            {
                deposit1.InitialAmount = depositSum;
            }
            else
            {
                Console.WriteLine("Некоректне введення суми депозиту. Будь ласка, введіть додатне число.");
                return;
            }


            //дата відкриття депозиту
            Console.WriteLine("Введіть дату відкриття депозиту у форматі ДД.ММ.РРРР");

            string inputDepositOpenDate = Console.ReadLine() ?? string.Empty;

            string normalizedDateInput = inputDepositOpenDate.Replace(',', '.');

            bool isDateParsed = DateOnly.TryParse(normalizedDateInput, out DateOnly depositOpenDate);

            if (isDateParsed)
            {
                deposit1.OpenDate = depositOpenDate;
            }
            else
            {
                Console.WriteLine("Некоректне введення дати відкриття депозиту. Будь ласка, введіть дату у форматі ДД.ММ.РРРР.");
                return;
            }


            //тривалість депозиту в місяцях
            Console.WriteLine("Вкажіть кількість місяців, на яку бажаєте відкрит депозит. Мінімальний термін - 4 місяці");

            string inputDepositDurationInMonths = Console.ReadLine() ?? string.Empty;

            string normalizedDurationInput = inputDepositDurationInMonths.Replace(',', '.');

            bool isDurationParsed = int.TryParse(normalizedDurationInput, out int depositDurationInMonths);

            if (isDurationParsed && depositDurationInMonths >= 4)
            {
                deposit1.DurationInMonths = depositDurationInMonths;
                deposit1.DurationInYears = depositDurationInMonths;
            }
            else
            {
                Console.WriteLine("Некоректне введення тривалості депозиту. Будь ласка, введіть ціле число, не менше 4.");
                return;
            }


            //розрахунок прибутку від депозиту
            DepositCalculator[] profit1 = deposit1.CalculateDepositProfit(deposit1.InitialAmount, deposit1.DurationInYears, deposit1.DurationInMonths);

            //виведення результату
            DisplayDepositProfit(profit1);


            static void DisplayDepositProfit(DepositCalculator[] profit)
            {
                Console.WriteLine($"{"№", -10} {"Month", -10} {"Year", -10} {"Profit", -10} {"DepositSum", -10}");
                Console.WriteLine(new string ('-', 50));
                foreach (var item in profit)
                {
                    Console.WriteLine($"{item.NumberOfMonths} {item.BillingMonth} {item.Year} {item.ProfitForMonth} {item.BillingDepositSum}");
                    Console.WriteLine(new string('-', 50));
                }
            }
        }
    }
}
