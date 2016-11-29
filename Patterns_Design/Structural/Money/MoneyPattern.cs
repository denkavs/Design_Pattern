using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Structural.Money
{
    public static class MoneyPattern
    {
        public static void Start()
        {
            Console.WriteLine("--=== Money pattern start ===--");
            double val = 0.00;
            for(int i = 0; i < 10; i++)
            {
                val += 0.10;
            }

            Console.WriteLine(val == 1.00);
            decimal money = 5.00m;
            Console.WriteLine(money * 0.3m);
            Console.WriteLine(money * 0.7m);
            money = Decimal.Round(money, 2);
            Console.WriteLine(money);

            Console.WriteLine("--=== Money pattern end ===--");
        }
    }
}
