/*Problem 5. Generic class

    Write a generic class GenericList<T> that keeps a list of elements of some parametric type T.
    Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor.
    Implement methods for adding element, accessing element by index, removing element by index, inserting element at given
    position, clearing the list, finding element by its value and ToString().
    Check all input parameters to avoid accessing elements at invalid positions.
*/
/*Problem 6. Auto-grow

    Implement auto-grow functionality: when the internal array is full, create a new array of double size and move all elements to it.
*/
/*Problem 7. Min and Max

    Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal element in the GenericList<T>.
    You may need to add a generic constraints for the type T.
*/

namespace Generic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class List<T>
    {
        private const int DefaultCapacity = 4;
        private int capacity;
        private T[] items;

        public List() : this(DefaultCapacity)
        {
        }

        public List(int capacity)
        {
            this.Count = 0;
            this.Capacity = capacity;
            this.items = new T[this.Capacity];
        }

        public int Count { get; private set; }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Capacity", value, "The Capacity cannot be negatibe!");
                }

                this.capacity = value;
            }
        }

        public T this[int index]
        {
            get
            {
                this.CheckIndexRange(index);
                return this.items[index];
            }

            set
            {
                this.CheckIndexRange(index);
                this.items[index] = value;
            }
        }

        public void Add(T element)
        {
            this.IncreaseCapacityIfNeeded();
            this.items[this.Count] = element;
            this.Count++;
        }

        public void RemoveAt(int index)
        {
            this.CheckIndexRange(index);
            Array.Copy(this.items, index + 1, this.items, index, --this.Count - index);
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > this.Count)
            {
                throw new IndexOutOfRangeException("Index was outside the bounds of the list!");
            }

            this.IncreaseCapacityIfNeeded();

            for (int i = this.Count++; i > index;)
            {
                this.items[i] = this.items[--i];
            }

            this.items[index] = item;
        }

        public void Clear()
        {
            this.Count = 0;
        }

        public int Find(T item)
        {
            return Array.IndexOf(this.items, item, 0, this.Count);
        }

        public T Min()
        {
            this.CheckIndexRange(0); // If zero indexed element exists, the list is not empty.
            T min = this.items[0];
            for (int i = 1; i < this.Count; i++)
            {
                if (Comparer<T>.Default.Compare(min, this.items[i]) > 0)
                {
                    min = this.items[i];
                }
            }

            return min;
        }

        public T Max()
        {
            this.CheckIndexRange(0); // If zero indexed element exists, the list is not empty.
            T max = this.items[0];
            for (int i = 1; i < this.Count; i++)
            {
                if (Comparer<T>.Default.Compare(max, this.items[i]) < 0)
                {
                    max = this.items[i];
                }
            }

            return max;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < this.Count; i++)
            {
                builder.Append(string.Format("item[{0}]: {1}", i, this.items[i]));
                if (i < this.Count - 1)
                {
                    builder.Append(", ");
                }
            }

            return builder.ToString();
        }

        private void CheckIndexRange(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Index was outside the bounds of the list!");
            }
        }

        // Problem 6. Auto-grow
        private void IncreaseCapacityIfNeeded()
        {
            if (this.Count == this.Capacity)
            {
                if (this.Capacity == 0)
                {
                    this.Capacity = DefaultCapacity;
                }
                else
                {
                    this.Capacity *= 2;
                }

                var oldItems = this.items;
                this.items = new T[this.Capacity];
                Array.Copy(oldItems, this.items, this.Count);
            }
        }
    }
}
