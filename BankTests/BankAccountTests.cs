using BankAccountNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalances()
        {
            //Arrange
            double begginingBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Peter Wallace", begginingBalance);

            //Act
            account.Debit(debitAmount);

            //Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account Not Debited Correctly.");
        }

        [TestMethod]
        public void Debit_WhenTheAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            //Arrange
            double begginingBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Peter Wallace", begginingBalance);

            //Act and Assert
            try
            {
                Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
            }
        }

        [TestMethod]
        public void Debit_WhenTheAmountIsGreaterThanBalance_ShouldThrowArgumentOutOfRange()
        {
            //Arrange
            double begginingBalance = 11.99;
            double debitAmount = 500.00;
            BankAccount account = new BankAccount("Mr. Peter Wallace", begginingBalance);

            //Act and Assert
            try
            {
                Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
            }
        }
    }
}