using System;
using System.Collections.Generic;
using System.Text;

namespace DepositFinalHomeWork
{
    public class DepositData
    {
        public int NumberOfMonths { get; set; }

        public byte Year { get; set; }
        public double InitialAmount { get; set; }
        public DateOnly OpenDate { get; set; }

        public double ProfitForMonth { get; set; }

        public double ProfitForPeriod { get; set; }

        public byte DurationInMonths { get; set; } = 4;

        //залишила цю властивість тільки як приклад computed властивості.в коді не використовується
        public byte DurationInYears
        {
            get
            { return (byte)(DurationInMonths / 12); } //це computed властивість. Вона не зберігає значення, а обчислює його на основі DurationInMonths щоразу,
                                              //коли до неї звертаються. Це дозволяє завжди отримувати актуальне значення тривалості в роках, навіть
                                              //якщо DurationInMonths змінюється.
                                              //Для computed властивісті Сеттер  не потрібен
        }

        public string BillingMonth { get; set; } = string.Empty;

        public double BillingDepositSum { get; set; }
    }
}
