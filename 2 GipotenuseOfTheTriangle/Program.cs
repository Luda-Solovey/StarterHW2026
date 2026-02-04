using System.Globalization;
using System.Text;

namespace _2_GipotenuseOfTheTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;//встановлення кодування для коректного відображення українських символів
            Console.InputEncoding = Encoding.UTF8;

            //Задача: Обчислити гіпотенузу прямокутного трикутника за теоремою Піфагора
            Console.WriteLine("Введіть довжину катета a:");
            string inputA = Console.ReadLine() ?? string.Empty;
            bool isParsedA = double.TryParse(inputA, CultureInfo.InvariantCulture, out double a);
            Console.WriteLine("Введіть довжину катета b:");
            string inputB = Console.ReadLine() ?? string.Empty;
            bool isParsedB = double.TryParse(inputB, CultureInfo.InvariantCulture, out double b);
            
            if (isParsedA && isParsedB)
            {
                double c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));

                Console.WriteLine($"Довжина гіпотенузи c: {Math.Round(c,2)}");
            }
            else
            {
                Console.WriteLine("Введені некоректні значення для катетів.");
            }
        }
    }
}
