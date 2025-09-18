using System;
using System.Globalization;
using System.Threading;


public interface IAccount
{
    void CheckBalancer();
    void Transfer(decimal amountVnd);
}
public interface ICurrencyFormatter
{
    string Vnd(decimal amount);
}
public interface IExchangeCalculator
{
    decimal ToVnd(decimal foreignAmount, decimal exchangeRate);
}



public sealed class ViVnCurrencyFormatter : ICurrencyFormatter
{
    private static readonly CultureInfo Vi = new("vi-VN");
    public string Vnd(decimal amount) => $"{amount.ToString("N0", Vi)} đ";
}
public sealed class SimpleExchangeCalculator : IExchangeCalculator
{
    public decimal ToVnd(decimal foreignAmount, decimal exchangeRate)
        => foreignAmount * exchangeRate; 
}



public abstract class Account : IAccount
{
    protected decimal Balancer; 
    protected readonly ICurrencyFormatter Formatter;

    protected Account(decimal initialVnd, ICurrencyFormatter formatter)
    {
        Balancer = initialVnd;
        Formatter = formatter;
    }

    public virtual void CheckBalancer()
    {
        Console.WriteLine($"Your balancer: {Formatter.Vnd(Balancer)}");
    }

    public virtual void Transfer(decimal amountVnd)
    {
        if (amountVnd <= 0)
        {
            Console.WriteLine("Amount must be greater than 0.");
            return;
        }
        if (amountVnd > Balancer)
        {
            Console.WriteLine("Insufficient balancer!");
            return;
        }
        Balancer -= amountVnd;
        
        Console.WriteLine($"Your transferred {Formatter.Vnd(amountVnd)}, Your balancer : {Formatter.Vnd(Balancer)}");
    }
}

public sealed class NormalAccount : Account
{
    public NormalAccount(decimal initialVnd, ICurrencyFormatter f) : base(initialVnd, f) { }
}

public sealed class ExchangeAccount : Account
{
    public ExchangeAccount(decimal foreignAmount, decimal rate, ICurrencyFormatter f, IExchangeCalculator ex)
        : base(ex.ToVnd(foreignAmount, rate), f) { }
}



public static class Program
{
    public static void Main()
    {
        
        var vi = new CultureInfo("vi-VN");
        Thread.CurrentThread.CurrentCulture = vi;
        Thread.CurrentThread.CurrentUICulture = vi;

        var formatter = new ViVnCurrencyFormatter();
        var exchanger = new SimpleExchangeCalculator();

        Console.WriteLine("=== BANK ACCOUNT SYSTEM ===");
        Console.WriteLine("1) Normal Account (VND)");
        Console.WriteLine("2) Exchange Account (foreign → VND)");
        Console.Write("Choose account type (1/2): ");
        var choice = (Console.ReadLine() ?? "").Trim();

        IAccount account;
        if (choice == "1")
        {
            var vnd = ReadMoney("Enter VND amount (e.g., 25000000): ");
            account = new NormalAccount(vnd, formatter);
        }
        else
        {
            var rate = ReadMoney("Enter today exchange rate USD→VND (e.g., 25000): ");
            var usd  = ReadMoney("Enter your amount in USD (e.g., 1000): ");
            account  = new ExchangeAccount(usd, rate, formatter, exchanger);
        }

        Console.WriteLine();
        
        account.CheckBalancer();

        Console.WriteLine();
        
        var transferAmt = ReadMoney("Enter amount to transfer (VND): ");
        account.Transfer(transferAmt);

        Console.WriteLine("\nDone. Press any key to exit...");
        Console.ReadKey();
    }

    private static decimal ReadMoney(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var s = (Console.ReadLine() ?? "").Trim();

            
            if (decimal.TryParse(s, NumberStyles.Any, CultureInfo.CurrentCulture, out var v) ||
                decimal.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out v))
            {
                if (v >= 0) return decimal.Round(v, 0); 
            }
            Console.WriteLine("Invalid number, try again.");
        }
    }
}

