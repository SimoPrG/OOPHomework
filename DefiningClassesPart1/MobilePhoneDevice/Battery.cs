namespace MobilePhoneDevice
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;

    [Serializable] //this attribute is needed in order to make deep copies of the instances.
    public class Battery
    {
        //Problem 1. battery characteristics (model, hours idle and hours talk)
        private string model = null;
        private double? hoursIdle = null;
        private double? hoursTalk = null;
        private BatteryTypes? batteryType = null;

        //Problem 2. Define several constructors for the defined classes that take different sets of arguments
        //(the full information for the class or part of it). All unknown data fill with null.
        #region Constructors
        public Battery(string model, double? hoursIdle, double? hoursTalk, BatteryTypes? batteryType)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.BatteryType = batteryType;
        }

        public Battery(string model, double? hoursIdle, double? hoursTalk)
            : this(model, hoursIdle, hoursTalk, null)
        {
        }

        public Battery(string model, double? hoursIdle)
            : this(model, hoursIdle, null)
        {
        }

        public Battery(string model)
            : this(model, null)
        {
        }

        public Battery()
            : this(null)
        {
        }
        #endregion

        //Problem 3. Add an enumeration BatteryType (Li-Ion, NiMH, NiCd, …) and use it as a new field for the batteries.
        public enum BatteryTypes
        {
            LiIon,
            NiMH,
            NiCd
        }

        //Problem 5. Use properties to encapsulate the data fields inside the Battery class.
        //Ensure all fields hold correct data at any given time.
        #region Properties
        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                this.model = value;
            }
        }

        public double? HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("HoursIdle cannot be negative!");
                this.hoursIdle = value;
            }
        }

        public double? HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("HoursTalk cannot be negative!");
                this.hoursTalk = value;
            }
        }

        public BatteryTypes? BatteryType
        {
            get
            {
                return this.batteryType;
            }
            private set
            {
                this.batteryType = value;
            }
        }
        #endregion


        //Problem 4. Add a method in the class for displaying all information about it. Try to override ToString().
        public override string ToString()
        {
            return string.Format("[Model: {0}; HoursIdle: {1}; HoursTalk: {2}; BatteryType: {3}]",
                Model, HoursIdle, HoursTalk, BatteryType);
        }
    }
}
