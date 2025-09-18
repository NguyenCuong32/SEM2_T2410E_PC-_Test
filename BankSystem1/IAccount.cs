using System;

namespace BankSystem
{
    public interface IAccount
    {
        decimal Balance { get; }
        void CheckBalance();
        void Transfer(decimal amount);
    }
}
