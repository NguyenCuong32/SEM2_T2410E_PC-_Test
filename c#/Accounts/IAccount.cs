namespace BankAndMusicApp.Accounts
{
    public interface IAccount
    {
        void ShowBalance();
        void Transfer(decimal amount);
    }
}
