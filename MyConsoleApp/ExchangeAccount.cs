using System;

namespace MyConsoleApp
{
    class ExchangeAccount : BankAccount
    {
        public decimal ExchangeRate { get; set; } = 25000; 

        public override void CheckBalance()
        {
            Console.WriteLine($"Số dư của bạn: {balance:N0} đ (Tỷ giá hiện tại: {ExchangeRate:N0} VND/USD)");
        }
    }
}
