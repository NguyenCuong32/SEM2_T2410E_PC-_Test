using System;
using System.Globalization;

namespace BankAccountApp
{
    static class Money
    {
        static readonly CultureInfo Vi = new("vi-VN");
        public static string VND(decimal x) => x.ToString("#,0", Vi) + " đ";
    }

    static class Read
    {
        public static int Int(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write($"{prompt} ");
                var s = Console.ReadLine();
                if (int.TryParse(s, out var v) && v >= min && v <= max) return v;
                Console.WriteLine($"⚠️ Enter an integer in [{min}..{max}].");
            }
        }
        public static decimal Decimal(string prompt, decimal min = 0)
        {
            while (true)
            {
                Console.Write($"{prompt} ");
                var s = Console.ReadLine();

                if (decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out var v) && v >= min)
                    return v;

                // Cho phép kiểu "1.000.000"
                if (decimal.TryParse(s?.Replace(".", "").Replace(",", ""), out v) && v >= min)
                    return v;

                Console.WriteLine($"⚠️ Enter a number ≥ {min}.");
            }
        }
    }

    public interface IAccount
    {
        decimal Balance { get; }
        void CheckBalance();
        bool Transfer(decimal amountVND);
    }

    public interface IExchangeRateProvider
    {
        decimal GetRate(string fromCurrency, string toCurrency);
    }

    public class FixedExchangeRateProvider : IExchangeRateProvider
    {
        private readonly decimal _rate;
        public FixedExchangeRateProvider(decimal rate) => _rate = rate;
        public decimal GetRate(string fromCurrency, string toCurrency) => _rate;
    }

    public abstract class Account : IAccount
    {
        public decimal Balance { get; protected set; }
        protected Account(decimal initialVND) { Balance = initialVND; }

        public virtual void CheckBalance()
        {
            // Đúng format đề: “Your balancer: 25.000.000 đ”
            Console.WriteLine($"Your balancer: {Money.VND(Balance)}");
        }

        public virtual bool Transfer(decimal amountVND)
        {
            if (amountVND <= 0) { Console.WriteLine("⚠️ Amount must be > 0."); return false; }
            if (amountVND > Balance) { Console.WriteLine("⚠️ Insufficient funds."); return false; }

            Balance -= amountVND;
            // Đúng format đề: “Your transferred 1.000.000 đ, Your balancer : 24.000.000 đ”
            Console.WriteLine($"Your transferred {Money.VND(amountVND)}, Your balancer : {Money.VND(Balance)}");
            return true;
        }
    }

    public class NormalAccount : Account
    {
        public NormalAccount(decimal initialVND) : base(initialVND) { }
    }

    public class ExchangeAccount : Account
    {
        public string FromCurrency { get; }
        public string ToCurrency { get; }
        private readonly IExchangeRateProvider _rateProvider;

        // Nhập tiền ngoại tệ → quy đổi sang VND: balance = amount × rate (đúng đề)
        public ExchangeAccount(decimal foreignAmount, string from, string to, IExchangeRateProvider rateProvider)
            : base(foreignAmount * rateProvider.GetRate(from, to))
        {
            FromCurrency = from; ToCurrency = to; _rateProvider = rateProvider;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== BÀI 1: BANK ACCOUNT SYSTEM ===");
            Console.WriteLine("1) Normal Account (nhập VND)");
            Console.WriteLine("2) Exchange Account (nhập USD & tỷ giá → quy đổi VND)");
            int opt = Read.Int("Chọn (1-2):", 1, 2);

            IAccount account;
            if (opt == 1)
            {
                var vnd = Read.Decimal("Nhập số tiền ban đầu (VND):", 0);
                account = new NormalAccount(vnd);
            }
            else
            {
                var usd = Read.Decimal("Nhập số tiền ban đầu (USD):", 0);
                var rate = Read.Decimal("Nhập tỷ giá (VD: 25000):", 0);
                var provider = new FixedExchangeRateProvider(rate);
                account = new ExchangeAccount(usd, "USD", "VND", provider);
            }

            Console.WriteLine();
            account.CheckBalance();

            var transfer = Read.Decimal("Nhập số tiền muốn chuyển (VND):", 1);
            account.Transfer(transfer);
        }
    }
}
