using System;
using System.Collections.Generic;
using System.Text;

namespace DepositFinalHomeWork
{
    public record DepositData
    (
        double InitialAmount,
        DateOnly OpenDate,
        byte DurationInMonths,
        byte DepositRate = 12
    );
}
