/*Problem 2. Bank accounts

    A bank holds different types of accounts for its customers: deposit accounts, loan accounts and mortgage accounts.
    Customers could be individuals or companies.
    All accounts have customer, balance and interest rate (monthly based).
        Deposit accounts are allowed to deposit and withdraw money.
        Loan and mortgage accounts can only deposit money.
    All accounts can calculate their interest amount for a given period (in months). In the common case its is calculated as follows:
    number_of_months * interest_rate.
    Loan accounts have no interest for the first 3 months if are held by individuals
    and for the first 2 months if are held by a company.
    Deposit accounts have no interest if their balance is positive and less than 1000.
    Mortgage accounts have ½ interest for the first 12 months for companies and no interest for the first 6 months for individuals.
    Your task is to write a program to model the bank system by classes and interfaces.
    You should identify the classes, interfaces, base classes and abstract actions and
    implement the calculation of the interest functionality through overridden methods.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts
{
    class BankAccountsTester
    {
        static void Main()
        {
            IEnumerable<Account> accounts = new List<Account>()
            {
                new DepositAccount(new Individual("Ivan"), 500m, 1m),
                new DepositAccount(new Company("IT OOD"), 10000m, 1m),
                new LoanAccount(new Individual("Gosho"), -200m, 5m),
                new LoanAccount(new Company("Hardware AD"), -100000m, 5m),
                new MortgageAccount(new Individual("Maria"), -50000m, 5m),
                new MortgageAccount(new Company("Software EAD"), -100000m, 5m)
            };

            ShowInterestAmount(accounts, 3);
            Console.WriteLine();

            ShowInterestAmount(accounts, 13);
        }

        private static void ShowInterestAmount(IEnumerable<Account> accounts, int period)
        {
            foreach (var account in accounts)
            {
                Console.WriteLine(
                    "Account type: {0}\nCustomer: {1}\nmonths: {2}\nInterest amount: {3}\n",
                    account.GetType().Name,
                    account.Customer.GetType().Name,
                    period,
                    account.CalculateInterestAmount(period));
            }
        }
    }
}
