using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts
{
    class LoanAccount : Account
    {
        private const int IndividualGratisPeriod = 3;
        private const int CompanyGratisPeriod = 2;

        public LoanAccount(Customer customer, decimal balance, decimal monthlyInterestRate)
            : base(customer, balance, monthlyInterestRate)
        {
            if (balance > 0)
            {
                throw new ArgumentException("Loan account balance cannot be positive.");
            }
        }

        public override decimal CalculateInterestAmount(int months)
        {
            if (months < 0)
            {
                throw new ArgumentNullException("months", "months cannot be negative.");
            }

            Type customerType = this.Customer.GetType();

            if (customerType == typeof(Individual))
            {
                return this.MonthlyInterestRate * (months <= IndividualGratisPeriod ? 0 : months - IndividualGratisPeriod); 
            }
            else
            {
                return this.MonthlyInterestRate * (months <= CompanyGratisPeriod ? 0 : months - CompanyGratisPeriod);
            }
        }
    }
}
