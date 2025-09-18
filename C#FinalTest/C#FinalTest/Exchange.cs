public class Exchange : Acc
{
public decimal ExchangeRate { get; private set; }
public Exchange(decimal initialBaseAmount, decimal exchangeRate)
        : base(initialBaseAmount)
    {
        ExchangeRate = exchangeRate;
    }

    public override decimal GetBalance()
    {
        return Amount * ExchangeRate;
    }
}
