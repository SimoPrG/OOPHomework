/*Problem 5. 64 Bit array

    Define a class BitArray64 to hold 64 bit values inside an ulong value.
    Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.
*/

namespace CommonTypeSystem.ProblemBitArray64
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class BitArray64 : IEnumerable<int>
    {
        private ulong bitArray;

        public BitArray64()
            : this(0)
        {
        }

        public BitArray64(ulong value)
        {
            this.BitArray = value;
        }

        public ulong BitArray
        {
            get { return this.bitArray; }
            private set { this.bitArray = value; }
        }

        public int this[int index]
        {
            get
            {
                CheckIndex(index);
                return (int)((this.bitArray >> index) & 1);
            }

            set
            {
                CheckIndex(index);
                CheckValue(value);

                // Clear the bit at position index.
                this.bitArray &= ~(1UL << index);

                // Set the bit at position index to value.
                this.bitArray |= (ulong)value << index;
            }
        }

        public static bool operator ==(BitArray64 a, BitArray64 b)
        {
            return object.Equals(a, b);
        }

        public static bool operator !=(BitArray64 a, BitArray64 b)
        {
            return !object.Equals(a, b);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 63; i >= 0; i--)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(64);
            for (int i = 63; i >= 0; i--)
            {
                builder.Append(this[i] == 1 ? '1' : '0');
            }

            return builder.ToString();
        }

        public override bool Equals(object obj)
        {
            var array = obj as BitArray64;
            if (array == null)
            {
                return false;
            }

            return this.BitArray == array.BitArray;
        }

        public override int GetHashCode()
        {
            return this.BitArray.GetHashCode();
        }

        private static void CheckValue(int value)
        {
            if (value != 0 && value != 1)
            {
                throw new ArgumentException("The bit value must be 0 or 1.");
            }
        }

        private static void CheckIndex(int index)
        {
            if (index < 0 || index > 63)
            {
                throw new IndexOutOfRangeException("The index must be between 0 and 63 including.");
            }
        }
    }
}
