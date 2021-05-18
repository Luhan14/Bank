using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Bank;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance ()
        {
            // Arrange
            double beginningBalance = 11.99;//saldo inicial
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Sr. Wellington", beginningBalance);

            //Act
            
            account.Debit(debitAmount);

            //Assert 
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "conta não debitada corretamente");
         }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            //Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Sr. Wellington", beginningBalance);

            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            //Arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            BankAccount account = new BankAccount("Sr. Wellington", beginningBalance);

            //Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                //Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }

            Assert.Fail("A exceção esperada não foi lançada.");
        }
    }
}
