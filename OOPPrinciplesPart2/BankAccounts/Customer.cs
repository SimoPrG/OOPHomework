namespace BankAccounts
{
    using System;

    [Serializable]
    public abstract class Customer
    {
        protected Customer(string name)
        {
            this.Name = name;
        }

        string Name { get; set; }
    }
}
