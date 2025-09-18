using System;

namespace BankSystem
{
    public interface IAccount
    {
        void CheckBalance();
        void Transfer(decimal amount);
    }
    public abstract class BankAccount : IAccount
    {
        public decimal Balance { get; protected set; }

        public BankAccount(decimal initialBalance)
        {
            Balance = initialBalance;
        }

        public virtual void CheckBalance()
        {
            Console.WriteLine($"Your balance: {Balance:N0} đ");
        }

        public virtual void Transfer(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Your transferred {amount:N0} đ, Your balance: {Balance:N0} đ");
            }
            else
            {
                Console.WriteLine("Insufficient funds!");
            }
        }
    }
    public class NormalAccount : BankAccount
    {
        public NormalAccount(decimal initialBalance) : base(initialBalance) { }
    }
    public class ExchangeAccount : BankAccount
    {
        private decimal ExchangeRate;

        public ExchangeAccount(decimal amount, decimal exchangeRate)
            : base(amount * exchangeRate)
        {
            ExchangeRate = exchangeRate;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose account type: 1. Normal, 2. Exchange");
            int choice = int.Parse(Console.ReadLine());

            BankAccount account;
            if (choice == 1)
            {
                Console.Write("Enter initial amount (VND): ");
                decimal amount = decimal.Parse(Console.ReadLine());
                account = new NormalAccount(amount);
            }
            else
            {
                Console.Write("Enter amount in USD: ");
                decimal usd = decimal.Parse(Console.ReadLine());
                Console.Write("Enter exchange rate USD → VND: ");
                decimal rate = decimal.Parse(Console.ReadLine());
                account = new ExchangeAccount(usd, rate);
            }

            account.CheckBalance();

            Console.Write("Enter amount to transfer: ");
            decimal transferAmount = decimal.Parse(Console.ReadLine());
            account.Transfer(transferAmount);

            Console.ReadLine();
        }
    }
}
