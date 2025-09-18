using System;

namespace BankSystem
{
    public class NormalAccount : IAccount
    {
        protected decimal balance;
        public NormalAccount(decimal initialBalance)
        {
            balance = initialBalance;
        }
        public virtual void CheckBalance()
        {
            Console.WriteLine($"Your balance: {balance:n0} đ");
        }
        public virtual void Transfer(decimal amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Your transferred {amount:n0} đ. Your balance: {balance:n0} đ");
            }
            else
            {
                Console.WriteLine("Not enough balance!");
            }
        }
    }
}