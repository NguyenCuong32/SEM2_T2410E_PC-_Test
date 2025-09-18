using System;
public class BankProgram
{
    public static void Main(string[] args)
    {
        Console.WriteLine("## Bank Account System Demo ##\n");
        IAccount myExchangeAccount = new Exchange(1000m, 25000m);
        Console.WriteLine("--- Exchange Account Actions ---");
        myExchangeAccount.Balance();
        myExchangeAccount.BankTransfer(1000000m);
        myExchangeAccount.Balance();
    }
}