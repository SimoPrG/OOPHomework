using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts
{
    public class DepositAccount : Account
    {
        public DepositAccount(Customer customer, decimal balance, decimal monthlyInterestRate)
            : base(customer, balance, monthlyInterestRate)
        {
            if (balance < 0)
            {
                throw new ArgumentException("Deposit account balance cannot be negative.");
            }
        }

        public decimal WithdrawMoney(decimal amount)
        {
            if (amount > this.Balance)
            {
                throw new ArgumentException("Withdraw amount exceeds account balance.");
            }

            this.Balance -= amount;

            return this.Balance;
        }

        public override decimal CalculateInterestAmount(int months)
        {
            if (this.Balance < 1000)
            {
                return 0m;
            }

            return base.CalculateInterestAmount(months);
        }
    }
}
