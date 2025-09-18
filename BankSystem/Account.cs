using System;
using System.Globalization;

namespace BankSystem
{
    public abstract class Account : IAccount
    {
        protected decimal balance;
        public decimal Balance => balance;
        public Account(decimal initialBalance)
        {
            balance = initialBalance;
        }

        protected string FormatVND(decimal value)
        {
            return value.ToString("N0", CultureInfo.GetCultureInfo("vi-VN")) + " đ";
        }

        public virtual void CheckBalance()
        {
            
            Console.WriteLine($"Your balancer: {FormatVND(balance)}");
        }

        public virtual void Transfer(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Transfer amount must be positive.");
                return;
            }

            if (amount > balance)
            {
                Console.WriteLine("Not enough balance!");
                return;
            }

            balance -= amount;
            Console.WriteLine($"Your transferred {FormatVND(amount)}, Your balancer : {FormatVND(balance)}");
        }
    }
}
