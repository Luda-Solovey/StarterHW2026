using System.Globalization;
using System.Text;

namespace _5СonditionalСonstructions
{
    public class Program
    {
        private static bool IsValueParsed(string normalizedValue, Type type, out object outValue)
        {
            bool result = false;

            switch (type.Name)
            {
                case "decimal":
                    result = decimal.TryParse(normalizedValue, CultureInfo.InvariantCulture, out decimal decimalValue);
                    outValue = decimalValue;
                    break;
                case "float":
                    result = float.TryParse(normalizedValue, CultureInfo.InvariantCulture, out float floatValue);
                    outValue = floatValue;
                    break;
                default: 
                    result = false;
                    outValue = null;
                    break;
            }

            return result;  
        }         

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
            decimal experience = 0;
            bool hasGoodFeedbacks = false;

            bool isExpirienceParced;
            bool isSalaryParced;
            bool isResultParced;

            bool isWrongInput = false;
            bool isExitRequired = false;


            while (true)
            {
                do
                {
                   isWrongInput = false;

                   experience = GetUserInputResult(
                        "Введіть стаж роботи або exit, якщо бажаєте вийти з програми",
                        out isResultParced,
                        out isExitRequired) ?? 0;

                    if (!isResultParced || experience < 0)
                    {
                        Console.WriteLine("Невалідне значення для стажу роботи.");
                        isWrongInput = true;
                    }
                }
                while (isWrongInput);

                if (isExitRequired)
                {
                    break;
                }

                do
                {
                    isWrongInput = false;
                    salary = GetUserInputResult(
                        "Введіть поточну заробітню плату",
                        out isResultParced,
                        out isExitRequired) ?? 0;

                    if (!isResultParced || salary < 0)
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
                    var answer = GetUserInputResult(
                     "Ви маєте гарні відгуки? Введіть 1 якщо так чи 2 якщо Ні. Якщо бажаєте вийти з програми введіть exit",
                     out isResultParced,
                     out isExitRequired);
              
                    isWrongInput = false;
                   
                    if (!(answer == 1 || answer == 2))
                    {
                        Console.WriteLine("Ви ввели неправильне значення.");
                        isWrongInput = true;
                    }
                    else 
                    {
                        hasGoodFeedbacks = (answer == 1);
                    }
                }
                while (isWrongInput);

                if (isExitRequired)
                {
                    Console.WriteLine("Вихід з програми");
                    break;
                }

                if ((hasGoodFeedbacks && salary < 10_000m) || 
                    experience > 10m || 
                    salary < 5000m)
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
            while (isWrongInput);
        }

        private static decimal? GetUserInputResult(string requestMessage, out bool isResultParced, out bool isExitRequired)
        {
            isExitRequired = false;
            isResultParced = false;

            Console.WriteLine(requestMessage); 
            string response = Console.ReadLine() ?? string.Empty; 
            if (response.ToUpper() == "EXIT") 
            {
                isExitRequired = true;
                return null;
            }
            string normalizedInput = (response ?? string.Empty).Replace(',', '.');

            isResultParced = decimal.TryParse(normalizedInput, out decimal res);        

            return res;
        }
    }
}







