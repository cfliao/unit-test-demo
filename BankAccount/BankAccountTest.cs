
namespace BankAccountTests
{
    public class BankAccountTest
    {
        [Fact]
        public void Constructor_SetsInitialBalance()
        {
            var account = new BankAccount(100m);
            Assert.Equal(100m, account.Balance);
        }

        [Fact]
        public void Deposit_AddsAmountToBalance()
        {
            var account = new BankAccount(50m);
            account.Deposit(25m);
            Assert.Equal(75m, account.Balance);
        }

        [Fact]
        public void Deposit_NonPositiveAmount_ThrowsArgumentException()
        {
            var account = new BankAccount(50m);
            Assert.Throws<ArgumentException>(() => account.Deposit(0m));
            Assert.Throws<ArgumentException>(() => account.Deposit(-10m));
        }

        [Fact]
        public void Withdraw_SubtractsAmountFromBalance()
        {
            var account = new BankAccount(100m);
            account.Withdraw(40m);
            Assert.Equal(60m, account.Balance);
        }

        [Fact]
        public void Withdraw_NonPositiveAmount_ThrowsArgumentException()
        {
            var account = new BankAccount(100m);
            Assert.Throws<ArgumentException>(() => account.Withdraw(0m));
            Assert.Throws<ArgumentException>(() => account.Withdraw(-5m));
        }

        [Fact]
        public void Withdraw_AmountGreaterThanBalance_ThrowsInvalidOperationException()
        {
            var account = new BankAccount(30m);
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(50m));
        }
    }
}