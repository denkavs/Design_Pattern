using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Structural.Money
{
    public enum Currency
    {
        USD = 1,
        EURO = 2,
        RUB = 3,
        GRN = 4,
    }

    public static class CurrencyHelper
    {
        internal static int getDefaultFractionDigits(Currency currency)
        {
            if(Currency.USD == currency)
                return 1;
            return 1;
        }
    }

    public class Money
    {
        private long amount;
        private Currency currency;

        private static int[] cents = new int[] { 1, 10, 100, 1000 };

        public Money()
        {

        }
        public Money(double amount, Currency currency)
        {
            this.currency = currency;
            this.amount = (long)Math.Round(amount * centFactor());
        }
        public Money(long amount, Currency currency)
        {
            this.currency = currency;
            this.amount = amount * centFactor();
        }
        public Currency Currency {
            get
            {
                return this.currency;
            }
        }
        public static Money dollars(double amount)
        {
            return new Money(amount, Currency.USD);
        }

        // Operations
        public bool equals(Object other)
        {
            var res = other is Money;
            return (other is Money) && equals((Money)other);
        }
        public bool equals(Money other)
        {
            return currency == other.currency && (amount == other.amount);
        }
        public int hashCode()
        {
            return (int)(amount ^ (amount >> 32));
        }

        public Money add(Money other)
        {
            assertSameCurrencyAs(other);
            return newMoney(amount + other.amount);
        }
        public Money subtract(Money other)
        {
            assertSameCurrencyAs(other);
            return newMoney(amount - other.amount);
        }

        public int compareTo(Object other)
        {
            return compareTo((Money)other);
        }
        public int compareTo(Money other)
        {
            assertSameCurrencyAs(other);
            if (amount < other.amount) return -1;
            else if (amount == other.amount) return 0;
            else return 1;
        }

        public Money multiply(double amount)
        {
            return multiply(new Decimal(amount));
        }
        public Money multiply(Decimal amount)
        {
            return null;
        }
        public Money multiply(Decimal amount, int roundingMode)
        {
            return null;
        }
        // End Operation
        private void assertSameCurrencyAs(Money arg)
        {
            Debug.Assert(this.currency == arg.currency, "money math mismatch");
        }
        private Money newMoney(long amount)
        {
            Money money = new Money();
            money.currency = this.currency;
            money.amount = amount;
            return money;
        }

        private int centFactor()
        {
            return cents[CurrencyHelper.getDefaultFractionDigits(this.Currency)];
        }
        public decimal Amount()
        {
            return new Decimal(this.amount);//.valueOf(amount, currency.getDefaultFractionDigits());
        }
    }
}
