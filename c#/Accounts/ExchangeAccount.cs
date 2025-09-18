namespace BankAndMusicApp.Accounts
{
    public class ExchangeAccount : Account
    {
        public ExchangeAccount(decimal amount, decimal exchangeRate)
            : base(amount * exchangeRate) { }
    }
}
