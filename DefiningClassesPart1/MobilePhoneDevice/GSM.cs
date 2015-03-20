namespace MobilePhoneDevice
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class GSM
    {
        //Problem 6. Add a static field and a property IPhone4S in the GSM class to hold the information about iPhone 4S.
        private static readonly GSM iPhone4S = new GSM("iPhone 4S", "Apple", 499.00m, "iVan", new Display(3.5, 16000000),
            new Battery("Non-removable Li-Po 1432 mAh battery (5.3 Wh)", 200.0, 8.0, Battery.BatteryTypes.LiIon));

        //Problem 1. information about a mobile phone device: model, manufacturer, price, owner,
        //battery characteristics and display characteristics.
        private string model = null;
        private string manufacturer = null;
        private decimal? price = null;
        private string owner = null;
        private Battery battery = null;
        private Display display = null;

        //Problem 2. Define several constructors for the defined classes that take different sets of arguments
        //(the full information for the class or part of it).
        //Assume that model and manufacturer are mandatory (the others are optional). All unknown data fill with null.
        #region Constructors
        public GSM(string model, string manufacturer, decimal? price, string owner, Display display, Battery battery)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Display = display;
            this.Battery = battery;
            this.CallHistory = new List<Call>();
        }

        public GSM(string model, string manufacturer, decimal? price, string owner, Display display)
            : this(model, manufacturer, price, owner, display, null)
        {
        }

        public GSM(string model, string manufacturer, decimal? price, string owner)
            : this(model, manufacturer, price, owner, null)
        {
        }

        public GSM(string model, string manufacturer, decimal? price)
            : this(model, manufacturer, price, null)
        {
        }

        public GSM(string model, string manufacturer)
            : this(model, manufacturer, null)
        {
        }
        #endregion

        //Problem 5. Use properties to encapsulate the data fields inside the GSM class.
        //Ensure all fields hold correct data at any given time.
        #region Properties
        //Problem 6. Add a static field and a property IPhone4S in the GSM class to hold the information about iPhone 4S.
        public static GSM IPhone4S
        {
            get
            {
                return iPhone4S;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new FormatException("The Model cannot be null, empty or white spaces!");
                this.model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new FormatException("The Manufacturer cannot be null, empty or white spaces!");
                this.manufacturer = value;
            }
        }

        public decimal? Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Price cannot be negative!");
                this.price = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }
            private set
            {
                this.owner = value;
            }
        }

        public Battery Battery
        {
            get
            {
                return ObjectCopier.Clone(this.battery); //we return a deep copy of a reference type
            }
            private set
            {
                this.battery = value;
            }
        }

        public Display Display
        {
            get
            {
                return ObjectCopier.Clone(this.display); //we return a deep copy of a reference type
            }
            private set
            {
                this.display = value;
            }
        }

        //Problem 9. Call history. Add a property CallHistory in the GSM class to hold a list of the performed calls.
        //Try to use the system class List<Call>.
        private List<Call> CallHistory { get; set; }
        #endregion

        //Problem 4. ToString
        //Add a method in the GSM class for displaying all information about it. Try to override ToString().
        #region Methods
        public override string ToString()
        {
            return string.Format(CultureInfo.CreateSpecificCulture("en-US"), "[Model: {0}; Manufacturer: {1}; Price: {2:C}; Owner: {3}; Battery: {4}; Display: {5}]",
                Model, Manufacturer, Price, Owner, Battery.ToString(), Display.ToString());
        }

        //Problem 10. Add/Delete calls
        //Add methods in the GSM class for adding and deleting calls from the calls history. Add a method to clear the call history.
        public void AddCall(Call call)
        {
            this.CallHistory.Add(call);
        }

        public Call DeleteCall(int index)
        {
            if (this.CallHistory.Count == 0)
                throw new Exception("The CallHistory does not contain any calls!");
            //if the index is out of the bounderies of the CallHistory, the generic list will throw exception

            Call call = this.CallHistory[index];

            this.CallHistory.RemoveAt(index);

            return call;
        }

        public Call[] ClearCallHistory()
        {
            if (this.CallHistory.Count == 0)
                throw new Exception("The CallHistory does not contain any calls!");

            Call[] allCalls = this.CallHistory.ToArray();

            this.CallHistory.Clear();

            return allCalls;
        }

        public void ShowCallHistory()
        {
            foreach (Call call in CallHistory)
            {
                Console.WriteLine(call);
            }
        }

        //Problem 11. Call price. Add a method that calculates the total price of the calls in the call history.
        //Assume the price per minute is fixed and is provided as a parameter.
        public decimal CalculateTotalPriceOfCalls(decimal pricePerMinute)
        {
            double totalSeconds = 0;
            foreach (Call call in this.CallHistory)
            {
                totalSeconds += call.Duration;
            }

            return pricePerMinute * (decimal)totalSeconds / 60;
        }
        #endregion
    }
}
