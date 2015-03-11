namespace MobilePhoneDevice
{
    using System;

    [Serializable] //this attribute is needed in order to make deep copies of the instances.
    public class Display
    {
        //Problem 1. display characteristics (size and number of colors)
        private double? size = null;
        private int? colorsCount = null;

        //Problem 2. Define several constructors for the defined classes that take different sets of arguments
        //(the full information for the class or part of it). All unknown data fill with null.
        #region Constructors
        public Display(double? size, int? colorsCount)
        {
            this.Size = size;
            this.ColorsCount = colorsCount;
        }

        public Display(double? size) : this(size, null)
        {
        }

        public Display(int? colorsCount) : this(null, colorsCount)
        {
        }

        public Display() : this(null)
        {
        }
        #endregion

        //Problem 5. Use properties to encapsulate the data fields inside the Display class.
        //Ensure all fields hold correct data at any given time.
        #region Properties
        public double? Size
        {
            get
            {
                return this.size;
            }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Size cannot be negative!");
                this.size = value;
            }
        }

        public int? ColorsCount
        {
            get
            {
                return this.colorsCount;
            }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("ColorsCount cannot be negative!");
                this.colorsCount = value;
            }
        }
        #endregion

        //Problem 4. Add a method in the class for displaying all information about it. Try to override ToString().
        public override string ToString()
        {
            return string.Format("[Size: {0}; ColorsCount: {1}]", Size, ColorsCount);
        }
    }
}
