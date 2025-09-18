using System;
using System.Globalization;

namespace BankSystem
{
    public class ExchangeAccount : Account
    {
        public decimal ForeignAmount { get; private set; }
        public decimal ExchangeRate { get; private set; } 

        public ExchangeAccount(decimal foreignAmount, decimal exchangeRate)
            : base(foreignAmount * exchangeRate)
        {
            ForeignAmount = foreignAmount;
            ExchangeRate = exchangeRate;
        }
        public override void CheckBalance()
        {
            var culture = CultureInfo.GetCultureInfo("vi-VN");
            string vnd = Balance.ToString("N0", culture) + " đ";
            Console.WriteLine($"Your balancer: {vnd} ( = {ForeignAmount} × {ExchangeRate.ToString("N0", culture)})");
        }
    }
}
