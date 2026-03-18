using System.Globalization;
using System.Text;

namespace _5СonditionalСonstructions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            var style = NumberStyles.Number;

            //do
            //{
            //    while (true)
            //    {
            //        // check 1th input
            //    }

            //    while (true)
            //    {
            //        // check 2th input
            //        if (exit)
            //            break;
            //    }

            //    while (true)
            //    {
            //        // check 3th input
            //    }
            //}
            //while (isBad)

            decimal salary = 0;
            float experience = 0;
            string haveGoodFeedbacks = string.Empty;
            bool isExpirienceParced = false;
            bool isSalaryParced = false;
            bool isWrongInput = false;
            bool isExitRequired = false;

            while (true)
            {
                do
                {
                    isWrongInput = false;
                    Console.WriteLine("Введіть стаж роботи або exit, якщо бажаєте вийти з програми");
                    string? inputExperience = Console.ReadLine() ?? string.Empty;
                    if (inputExperience.ToUpper() == "EXIT")
                    {
                        isExitRequired = true;
                        break;
                    }
                    string normalizedExpirience = (inputExperience ?? string.Empty).Replace(',', '.');//замінюємо кому на крапку
                    isExpirienceParced = float.TryParse(normalizedExpirience, CultureInfo.InvariantCulture, out experience);

                    if (!isExpirienceParced || experience < 0)
                    {
                        Console.WriteLine("Невалідне значення для стажу роботи.");
                        isWrongInput = true;
                    }
                }
                while (isWrongInput);

                if (isExitRequired == true)
                {
                    break;
                }

                do
                {
                    isWrongInput = false;
                    Console.WriteLine("Введіть вашу зарплату або exit, якщо бажаєте вийти з програми");
                    string? inputSalary = Console.ReadLine();
                    if (inputSalary == "exit")
                    {
                        isExitRequired = true;
                        break;
                    }

                    string normalizedSalary = (inputSalary ?? string.Empty).Replace(',', '.');
                    isSalaryParced = Decimal.TryParse(normalizedSalary, CultureInfo.InvariantCulture, out salary);
                    if (!isSalaryParced || salary < 0)
                    {
                        Console.WriteLine("Введене невалідне значення заробітньої плати.");
                        isWrongInput = true;
                    }
                }
                while (isWrongInput);

                if (isExitRequired)
                {
                    Console.WriteLine("Вихід з програми");
                    break;
                }

                do
                {
                    isWrongInput = false;
                    Console.WriteLine("Ви маєте гарні відгуки? Введіть Так чи Ні. Якщо бажаєте вийти з програми введіть exit");
                    haveGoodFeedbacks = Console.ReadLine() ?? string.Empty;
                    if (haveGoodFeedbacks.ToUpper() == "EXIT")
                    {
                        isExitRequired = true;
                        break;
                    }

                    if (!(haveGoodFeedbacks.ToUpper() == "ТАК" || haveGoodFeedbacks.ToUpper() == "НІ"))
                    {
                        Console.WriteLine("Ви ввели неправильне значення.");
                        isWrongInput = true;
                    }
                }
                while (isWrongInput);

                if (isExitRequired)
                {
                    Console.WriteLine("Вихід з програми");
                    break;
                }

                if ((haveGoodFeedbacks == "ТАК" && salary < 10_000m) || experience > 10f || salary < 5000m)
                {
                    salary += salary * 0.2m;
                    Console.WriteLine($"Вітаємо! Ваша заробітня плата була збільшена на 20%. Нова заробітня плата - {salary:##.##}");
                    //Console.WriteLine("Вітаємо! Ваша заробітня плата була збільшена на 20%. Нова заробітня плата -" + salary.ToString("C"));
                }
                else
                {
                    Console.WriteLine($"На жаль, Ви не відповідаєте умовам для підвищення зарплати.");
                }

            }
            while (isWrongInput) ;
        }
    }
}







