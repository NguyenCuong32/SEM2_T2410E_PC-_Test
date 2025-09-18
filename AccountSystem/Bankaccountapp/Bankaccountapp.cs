using System;

namespace BankAccountApp
{
    // Interface chung
    public interface IAccount
    {
        void Deposit(decimal amount);
        void Transfer(decimal amount);
        void ShowBalance();
    }

    // Abstract class chung
    public abstract class Account : IAccount
    {
        protected decimal balance;

        protected Account(decimal initialAmount)
        {
            balance = initialAmount;
        }

        public abstract void Deposit(decimal amount);
        public abstract void Transfer(decimal amount);

        public virtual void ShowBalance()
        {
            Console.WriteLine($"Current balance: {balance:n0} đ");
        }
    }

    // Tài khoản thường
    public class NormalAccount : Account
    {
        public NormalAccount(decimal initialAmount) : base(initialAmount) { }

        public override void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"Deposited {amount:n0} đ successfully!");
            }
            else
            {
                Console.WriteLine("Deposit amount must be positive!");
            }
        }

        public override void Transfer(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Transfer amount must be positive!");
                return;
            }

            if (balance >= amount)
            {
                balance -= amount;
                Console.WriteLine($"Transferred {amount:n0} đ successfully!");
            }
            else
            {
                Console.WriteLine("Not enough balance!");
            }
        }
    }

    // Tài khoản quy đổi
    public class ExchangeAccount : Account
    {
        private readonly decimal exchangeRate;

        public ExchangeAccount(decimal initialAmount, decimal rate) : base(initialAmount * rate)
        {
            exchangeRate = rate;
        }

        public override void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount * exchangeRate;
                Console.WriteLine($"Deposited {amount:n0} (x{exchangeRate}) = {amount * exchangeRate:n0} đ successfully!");
            }
            else
            {
                Console.WriteLine("Deposit amount must be positive!");
            }
        }

        public override void Transfer(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Transfer amount must be positive!");
                return;
            }

            if (balance >= amount)
            {
                balance -= amount;
                Console.WriteLine($"Transferred {amount:n0} đ successfully!");
            }
            else
            {
                Console.WriteLine("Not enough balance!");
            }
        }
    }

    // Chương trình chính
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose account type: 1. Normal  2. Exchange");
            if (!int.TryParse(Console.ReadLine(), out int choice) || (choice != 1 && choice != 2))
            {
                Console.WriteLine("Invalid choice!");
                return;
            }

            Console.Write("Enter your initial amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount < 0)
            {
                Console.WriteLine("Invalid amount!");
                return;
            }

            IAccount account;

            if (choice == 1)
            {
                account = new NormalAccount(amount);
            }
            else
            {
                Console.Write("Enter exchange rate: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal rate) || rate <= 0)
                {
                    Console.WriteLine("Invalid exchange rate!");
                    return;
                }
                account = new ExchangeAccount(amount, rate);
            }

            account.ShowBalance();

            Console.Write("Enter transfer amount: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal transferAmount))
            {
                account.Transfer(transferAmount);
            }
            else
            {
                Console.WriteLine("Invalid transfer amount!");
            }

            account.ShowBalance();
        }
    }
}
