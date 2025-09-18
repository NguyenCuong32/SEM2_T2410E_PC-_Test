public interface IAccount
{
    decimal GetBalance();
    void BankTransfer(decimal transferAmount);
    void Balance();
}