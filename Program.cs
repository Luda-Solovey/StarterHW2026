using System.Globalization;
using System.Text;

namespace _1Variables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //НОТАТОК
            //Типи даних в C#, розмірність в байтах, позначення літералів
            //byte 1 B
            //short 2 B
            //int 4 B
            //long 8 B

            //float 4 B, f
            //double 8 B, d всі типи з крапкою сприймаються як double за замовчуванням
            //decimal 16 B, m   decimal розроблений спеціально для фінансових розрахунків

            //bool 1 B
            //char 2 B

            //найменша одиниця пам'яті, яку можна виділити - це 1 байт (8 біт)
            //зберігаються в оперативній пам'яті комп'ютера (RAM)

            //1-створити змінну для зберігання віку людини і присвоїти
            byte ageOfMan = default; // 0 to 255
            Console.WriteLine(ageOfMan);
            ageOfMan = 25;
            Console.WriteLine(ageOfMan);

            //2-створити змінну для збереженян температури тіла.
            float temperatureOfBody = default; // 4 bytes
            Console.WriteLine(temperatureOfBody);
            temperatureOfBody = 36.6f;
            Console.WriteLine(temperatureOfBody);

            //3-Створити змінну для збереження теператури повітря в цельсіях
            sbyte temperatureOfAir = default;
            Console.WriteLine(temperatureOfAir);
            temperatureOfAir = -21;
            Console.WriteLine(temperatureOfAir);

            //4-створити змінну яка буде зберігати максимально точне значення PI 
            decimal piValue = default; //16 bytes
            Console.WriteLine(piValue);
            piValue = 3.1415926535897932384626433833m;

            //5-Створити змінну яка буде ззберігати ціну товару
            double priceOfProduct = default;
            Console.WriteLine(priceOfProduct);
            priceOfProduct = 19.99d;

            Console.WriteLine("-------------------------------------");

            //7 - організуватти ввід і присвоєння значень цим змінним з консолі.
            Console.WriteLine("Введіть нове значення для ціни товару");
            string input = Console.ReadLine();

            double newPreiceOfProduct;

            if (Double.TryParse(input, CultureInfo.InvariantCulture, out newPreiceOfProduct))
            {
                Console.WriteLine($"Нова ціна - {newPreiceOfProduct} грн.");
            }
            else
            {
                Console.WriteLine("Введено некоректне значення");
            }


            Console.WriteLine("-------------------------------------");

            //Підрахувати і вивести скільки ви таким чином витратила пам'яті на всі ці змінні.
            int totalMemory = sizeof(byte) + 2*(sizeof(float)) + 2*(sizeof(decimal)) + sizeof(decimal);
            Console.WriteLine($"Витрачено пам'яті під зміні (без стрінги) - {totalMemory}");

            //Питання
            //char c = '\00E7'; // Значення у форматі unicode
            //як порахувати розмір виділеної пам'яті для змінної типу string, класу, структури
            //різниця між double, decimal

            //Типи даних в C#, розмірність в байтах, позначення літералів
            // byte 1 B
            // short 2 B
            //int 4 B
            //long 8 B

            //float 4 B, f
            //double 8 B, d всі типи з крапкою сприймаються як double за замовчуванням
            //decimal 16 B, m

            //bool 1 B
            //char 2 B


        }
    }
}
