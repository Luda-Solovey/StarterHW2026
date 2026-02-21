using System.Text;

namespace ConditionalConstructionsDiscount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("Введіть суму покупок");
            string inputSumm = Console.ReadLine();

            if (decimal.TryParse(inputSumm, out decimal parsedSumm))
            {
                decimal discount = parsedSumm switch
                {
                    < 0 => throw new ArgumentOutOfRangeException(nameof(inputSumm), "Сума покупок не може бути від'ємною"),
                    < 100 => 0.1m,
                    >= 100 and < 500 => 0.15m,
                    >= 500 and < 1000 => 0.2m,
                    >= 1000 => 0.25m,
                };

                decimal discountedSumm = parsedSumm * (1 - discount);
                Console.WriteLine($"Сума покупок без знижки: {parsedSumm:C}, сума покупок зі знижкою: {discountedSumm:C}, знижка: {discount}% ");
            }
            else
            {
                Console.WriteLine("Невірний формат суми покупок. Будь ласка, введіть числове значення.");
            }    
        }
    }
}
