using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts
{
    public abstract class Account
    {
        private Customer customer;

        protected Account(Customer customer, decimal balance, decimal monthlyInterestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.MonthlyInterestRate = monthlyInterestRate;
        }

        public Customer Customer
        {
            get
            {
                return this.customer.Clone();
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Customer");
                }

                this.customer = value;
            }
        }

        public decimal Balance { get; protected set; }

        protected decimal MonthlyInterestRate { get; private set; }

        public void DepositMoney(decimal amount)
        {
            this.Balance += amount;
        }

        public virtual decimal CalculateInterestAmount(int months)
        {
            if (months < 0)
            {
                throw new ArgumentNullException("months", "months cannot be negative.");
            }

            return MonthlyInterestRate * months;
        }
    }
}
