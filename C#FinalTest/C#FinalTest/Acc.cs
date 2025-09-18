using System;
using System.Globalization;
public abstract class Acc : IAccount
{
protected decimal Amount { get; set; }
public Acc(decimal initialAmount)
    {
        Amount = initialAmount >= 0 ? initialAmount : 0;
    }

public abstract decimal GetBalance();
public virtual void BankTransfer(decimal transferAmount)
    {
        if (transferAmount <= 0)
        {
            Console.WriteLine("Transfer amount must be positive.");
            return;
        }

        decimal amountToDeduct = transferAmount;
        if (this is Exchange exchangeAccount)
        {
            amountToDeduct /= exchangeAccount.ExchangeRate;
        }

        if (Amount >= amountToDeduct)
        {
            Amount -= amountToDeduct;
            Console.WriteLine($"Successfully transferred {FormatCurrency(transferAmount)}.");
        }
        else
        {
            Console.WriteLine("Insufficient funds for this transfer.");
        }
    }

public void Balance()
    {
        Console.WriteLine($"Your balancer: {FormatCurrency(GetBalance())}");
    }

    private string FormatCurrency(decimal value)
    {
        return $"{value.ToString("N0", CultureInfo.InvariantCulture).Replace(',', '.')} d";
    }
}