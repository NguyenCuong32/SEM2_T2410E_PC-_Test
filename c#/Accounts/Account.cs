using System;

namespace BankAndMusicApp.Accounts
{
    public abstract class Account : IAccount
    {
        protected decimal Balance;

        public Account(decimal initialAmount)
        {
            Balance = initialAmount;
        }

        public virtual void ShowBalance()
        {
            Console.WriteLine($"Your balancer: {Balance:N0} đ");
        }

        public virtual void Transfer(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Your transferred {amount:N0} đ, Your balancer: {Balance:N0} đ");
            }
            else
            {
                Console.WriteLine("Insufficient funds!");
            }
        }
    }
}
