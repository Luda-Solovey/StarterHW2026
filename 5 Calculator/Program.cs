using System.Globalization;
using System.Text;

namespace _5_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            string? value1;
            string? value2;

            double operand1 = 0d;
            double operand2 = 0d;

            Console.WriteLine("Введіть перше число");
            value1 = Console.ReadLine();

            Console.WriteLine("Введіть друге число");
            value2 = Console.ReadLine();

            if (string.IsNullOrEmpty(value1) || string.IsNullOrEmpty(value2))
            {
                Console.WriteLine("Введено не валідне значення");
            }

            var style = NumberStyles.Number;
            var culture = CultureInfo.InvariantCulture;

            value1 = value1!.Replace(',', '.');//без цього рядка нормально не парситься число, введене через кому (кома просто "викидується")
            if (!double.TryParse(value1, style, culture, out operand1)) //без параметрів style і culture число, введене через "крапку" не розпарсюється
            {
                Console.WriteLine("Недопустиме значення для змінної 1");
            }

            value2 = value2!.Replace(',', '.');//
            if (!double.TryParse(value2, style, culture, out operand2))
            {
                Console.WriteLine("Недопустиме значення для змінної 2");
            }

            Console.WriteLine("Введіть знак дії");
            string? sign = Console.ReadLine();
            double result = 0;
            bool isCalculeted = true;

            switch (sign)
            {
                case "+":
                    {
                        result = operand1 + operand2;
                        break;
                    }
                case "-":
                    {
                        result = operand1 - operand2;
                        break;
                    }
                case "*":
                    {
                        result = operand1 * operand2;
                        break;
                    }
                case "/":
                    {
                        if (operand2 == 0)
                        { Console.WriteLine("Недопустима операція. На нуль ділити не можна"); break; }


                        result = operand1 / operand2;
                        break;
                    }
                default:
                    {
                        isCalculeted = false;
                        break;
                    }
            }

            if (isCalculeted)
            {
                Console.WriteLine($"Результат: {result:##.##}");//вивести тільки два знаки після коми
                Console.WriteLine($"Результат: {result:F2}");
            }
            else
            {
                Console.WriteLine("Невірний ввід");
            }
        }
    }
}
