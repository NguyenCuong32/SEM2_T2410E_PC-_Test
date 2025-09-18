using System;

namespace MyConsoleApp
{
    abstract class BankAccount
    {
        protected decimal balance = 25000000; 

        public virtual void CheckBalance()
        {
            Console.WriteLine($"Số dư của bạn: {balance:N0} đ");
        }

        public virtual void Transfer(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Số tiền chuyển phải lớn hơn 0!");
                return;
            }

            if (amount > balance)
            {
                Console.WriteLine(" Số dư không đủ để thực hiện giao dịch!");
            }
            else
            {
                balance -= amount;
                Console.WriteLine($" Số tiền của bạn đã chuyển {amount:N0} đ, Số dư của bạn: {balance:N0} đ");
            }
        }
    }
}
