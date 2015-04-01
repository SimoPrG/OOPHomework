namespace CommonTypeSystem.ProblemBitArray64
{
    using System;

    public class BitArray64Test
    {
        public static void Main()
        {
            var array = new BitArray64(15);
            Console.WriteLine(array);

            array[3] = 0;
            Console.WriteLine(array);

            array[63] = 1;
            Console.WriteLine(array);

            array[63] = 0;
            Console.WriteLine(array);

            Console.WriteLine();

            foreach (var bit in array)
            {
                Console.Write(bit);
            }

            Console.WriteLine("\r\n");

            var array7 = new BitArray64(7);
            Console.WriteLine(array7);

            Console.WriteLine(array == array7);
            Console.WriteLine(array.Equals(array7));
            array7[63] = 1;
            Console.WriteLine(array != array7);
            Console.WriteLine(array.Equals(array7));
        }
    }
}
