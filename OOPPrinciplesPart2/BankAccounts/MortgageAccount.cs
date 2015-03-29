using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts
{
    class MortgageAccount : Account
    {
        private const int IndividualGratisPeriod = 6;
        private const int CompanyGratisPeriod = 12;
        private const decimal CompanyDiscountPrice = 0.5m;

        public MortgageAccount(Customer customer, decimal balance, decimal monthlyInterestRate)
            : base(customer, balance, monthlyInterestRate)
        {
            if (balance > 0)
            {
                throw new ArgumentException("Mortgage account balance cannot be positive.");
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
                return (
                    (months <= CompanyGratisPeriod) ? (this.MonthlyInterestRate * months * CompanyDiscountPrice)
                    : (this.MonthlyInterestRate*(months + CompanyGratisPeriod*(CompanyDiscountPrice - 1))));
            }
        }
    }
}
