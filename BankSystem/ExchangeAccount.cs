using System;

namespace BankSystem
{
    public class ExchangeAccount : NormalAccount
    {
        private decimal exchangeRate; 

        public ExchangeAccount(decimal amountInUsd, decimal exchangeRate)
            : base(amountInUsd * exchangeRate)
        {
            this.exchangeRate = exchangeRate;
        }

        public override void CheckBalance()
        {
            Console.WriteLine($"Your balance (converted): {balance:n0} đ");
        }
    }
}