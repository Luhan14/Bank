using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class BankAccount
    {
        private readonly string m_customerName;// cliente
        private double m_balance;// saldo

        public BankAccount() { }
        public BankAccount( string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        public string CustomerName
        {
            get { return m_customerName; }
        }
        public double Balance
        {
            get { return m_balance; }
        }
        public void Debit(double amount)
        {
            if(amount > m_balance)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }
            if(amount < 0)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }
            m_balance -= amount;
        }
        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }
            m_balance += amount;
        }


        static void Main(string[] args)
        {
            BankAccount ba = new BankAccount("Camille França",11.99);
            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("O saldo atual é R${0}", ba.Balance);
        }

        public const string DebitAmountExceedsBalanceMessage = "O valor do débito excede o saldo";
        public const string DebitAmountLessThanZeroMessage = "O valor do débito é menor que zero";
    }
}
