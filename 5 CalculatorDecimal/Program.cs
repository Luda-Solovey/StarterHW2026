using System.Globalization;
using System.Text;

namespace _5_CalculatorDecimal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            string value1;
            string value2;

            decimal operand1 = 0m;
            decimal operand2 = 0m;

            Console.WriteLine("Введіть перше число");
            value1 = Console.ReadLine();

            Console.WriteLine("Введіть друге число");
            value2 = Console.ReadLine();

            var style = NumberStyles.Number;
            var culture = CultureInfo.InvariantCulture;

            value1 = value1.Replace(',', '.');
            if (!decimal.TryParse(value1, style, culture, out operand1))
            {
                Console.WriteLine("Недопустиме значення для змінної 1");
            }

            value2 = value2.Replace(',', '.');
            if (!decimal.TryParse(value2, style, culture, out operand2))
            {
                Console.WriteLine("Недопустиме значення для змінної 2");
            }

            Console.WriteLine("Введіть знак дії");
            string sign = Console.ReadLine();
            decimal result = 0;

            switch (sign)
            {
                case "+":
                    {
                        result = operand1 + operand2;
                        Console.WriteLine($"Результат: {result}");
                        break;
                    }
                case "-":
                    {
                        result = operand1 - operand2;
                        Console.WriteLine($"Результат: {result}");
                        break;
                    }
                case "*":
                    {
                        result = operand1 * operand2;
                        Console.WriteLine($"Результат: {result}");
                        break;
                    }
                case "/":
                    {
                        if (operand2 == 0)
                        { Console.WriteLine("Недопустима операція. На нуль ділити не можна"); break; }


                        result = operand1 / operand2;
                        Console.WriteLine($"Результат: {result}");
                        break;
                    }
            }
        }
    }
}
