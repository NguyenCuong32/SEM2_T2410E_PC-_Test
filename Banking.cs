using System;

interface IAccount
{
    void CheckBalance();
    void Transfer(decimal amount);
}

abstract class Account : IAccount
{
    protected decimal Amount;
    public Account(decimal amount) { Amount = amount; }

    public abstract void CheckBalance();
    public virtual void Transfer(decimal transferAmount)
    {
        Amount -= transferAmount;
        Console.WriteLine($"Your transferred {transferAmount} đ, Your balancer : {Amount} đ");
    }
}

class NormalAccount : Account
{
    public NormalAccount(decimal amount) : base(amount) { }
    public override void CheckBalance()
    {
        Console.WriteLine($"Your balancer: {Amount} đ");
    }
}

class ExchangeAccount : Account
{
    private decimal _exchangeRate;
    public ExchangeAccount(decimal amount, decimal exchangeRate) : base(amount)
    {
        _exchangeRate = exchangeRate;
    }
    public override void CheckBalance()
    {
        decimal balancer = Amount * _exchangeRate;
        Console.WriteLine($"Your balancer: {balancer} đ");
    }
    public override void Transfer(decimal transferAmount)
    {
        decimal balancer = Amount * _exchangeRate - transferAmount;
        Console.WriteLine($"Your transferred {transferAmount} đ, Your balancer : {balancer} đ");
    }
}
