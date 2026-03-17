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
            float experience;
            string haveGoodFeedbacksInput = string.Empty;
            bool isExpirienceParced = false;
            bool isSalaryParced = false;
            bool isWrongInput = false;
            bool wishesGoOut = false;

            while (true)
            {
                do
                {
                    isWrongInput = false;
                    Console.WriteLine("Введіть стаж роботи:");
                    string? inputExperience = Console.ReadLine();
                    string normalizedExpirience = (inputExperience ?? string.Empty).Replace(',', '.');//замінюємо кому на крапку
                    isExpirienceParced = float.TryParse(normalizedExpirience, CultureInfo.InvariantCulture, out experience);
                    if (isExpirienceParced)
                    {
                        if (experience < 0)
                        {
                            Console.WriteLine("Стаж роботи не може бути від'ємним числом.");
                            isWrongInput = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ви ввели невалідне значення для стажу роботи.");
                        isWrongInput = true;
                    }
                }
                while (isWrongInput);

                do
                {
                    isWrongInput = false;
                    Console.WriteLine("Введіть вашу зарплату або exit, якщо бажаєте вийти з програми");
                    string? inputSalary = Console.ReadLine();
                    if (inputSalary == "exit")
                    {
                        wishesGoOut = true;
                        break;
                    }

                    string normalizedSalary = (inputSalary ?? string.Empty).Replace(',', '.');
                    isSalaryParced = Decimal.TryParse(normalizedSalary, CultureInfo.InvariantCulture, out salary);
                    if (isSalaryParced)
                    {
                        if (salary < 0)
                        {
                            Console.WriteLine("Зарплата не може мати від'ємне значення.");
                            isWrongInput = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Введене невалідне значення для заробітньої плати.");
                        isWrongInput = true;
                    }
                }

                while (isWrongInput);

                    if (wishesGoOut)
                    {
                        Console.WriteLine("Вихід з програми");
                        break;
                    }

                    do
                    {
                    isWrongInput = false;
                    Console.WriteLine("Ви маєте гарні відгуки? Напишіть Так чи Ні. Або exit, якщо бажаєте вийти з програми");
                        haveGoodFeedbacksInput = Console.ReadLine() ?? string.Empty;
                        if (haveGoodFeedbacksInput.ToUpper() == "EXIT")
                        {
                            wishesGoOut = true;
                            break;
                        }

                        if (!(haveGoodFeedbacksInput.ToUpper() == "ТАК" || haveGoodFeedbacksInput.ToUpper() == "НІ"))
                        {
                            Console.WriteLine("Ви ввели неправильне значення.");
                            isWrongInput = true;
                        }
                    }
                    while (isWrongInput);

                    if (wishesGoOut) {
                        Console.WriteLine("Вихід з програми");
                        break;
                    }

                    if ((haveGoodFeedbacksInput == "ТАК" && salary < 10_000) || experience > 10 || salary < 5000)
                    {
                        salary += salary * 0.2m;
                        Console.WriteLine($"Вітаємо! Ваша заробітня плата була збільшена на 20%. Нова заробітня плата - {salary:##.##}");
                        //Console.WriteLine("Вітаємо! Ваша заробітня плата була збільшена на 20%. Нова заробітня плата -" + salary.ToString("C"));
                    }
                    else
                    {
                        Console.WriteLine($"Ви не відповідаєте умовам для підвищення зарплати. Ваша заробітня плата - {salary:##.##}");
                    }

                    Console.WriteLine("Якщо бажаєте вийти з програми натисніть Esc, інакше - будь яку іншу клавішу");
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Escape)
                    {
                        Console.WriteLine("Вихід з програми");
                        break;
                    }
                }
            }
        }
    } 

