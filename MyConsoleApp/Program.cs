using System;

namespace MyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Chọn loại tài khoản (1 - Thường, 2 - Trao đổi): ");
            int choice = int.Parse(Console.ReadLine());

            BankAccount account;

            if (choice == 1)
                account = new NormalAccount();
            else
                account = new ExchangeAccount();

            account.CheckBalance();

            Console.Write("Nhập số tiền muốn chuyển (VND): ");
            decimal transferAmount = decimal.Parse(Console.ReadLine());

            account.Transfer(transferAmount);

            Console.ReadLine();
        }
    }
}
