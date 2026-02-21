using System.Globalization;
using System.Text;

namespace ConditionalConstructionsDiscountIfElse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) 
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.InputEncoding = Encoding.UTF8;

                Console.WriteLine("Введіть суму покупок");
                string inputSumm = Console.ReadLine();

                if (inputSumm.Equals("q", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Вихід з програми");
                        break;
                    }

                if (inputSumm == null || string.IsNullOrEmpty(inputSumm))
                    {
                        Console.WriteLine("Невалідне введене значення");
                    }

                else if (inputSumm == "0") { Console.WriteLine("Сума покупки не може бути рівна 0"); }

                else
                {
                    var style = NumberStyles.Number;
                    var culture = CultureInfo.InvariantCulture;

                    decimal discount = 0;
                    decimal.TryParse(inputSumm, style, culture, out var purchaseAmount);
                    if (purchaseAmount < 0) {Console.WriteLine("Сума покупки не може бути менша за нуль"); }
                    else if(purchaseAmount >= 1000) { discount = 0.25m; }
                    else if (purchaseAmount < 100) { discount = 0.1m; }
                    else if (purchaseAmount < 500) { discount = 0.15m; }
                    else { discount = 0.2m; }

                    decimal discountedSumm = Math.Round(purchaseAmount * (1 - discount), 2);

                    Console.WriteLine($"Сума покупок без знижки: {purchaseAmount:C}, сума покупок зі знижкою: {discountedSumm:C}, знижка: {discount:P0}");
                }
            }

            

            //якби нарахування знижки вираховував окремий метод
            //private decimal discountCalculate(string inputSumm)
            //{
            //decimal discount = 0;
            //decimal.TryParse(inputSumm, out var purchaseAmount);
            //if (purchaseAmount > 1000) { discount = 0.25m; return discount; }
            //if (purchaseAmount < 100) { discount = 0.01m; return discount; }
            //if (purchaseAmount < 500) { discount = 0.15m; return discount; }
            //if (purchaseAmount > 499) { discount = 0.2m; return discount; }
            //}
        }
    }
}
