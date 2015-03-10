/*Problem 7. GSM test

    Write a class GSMTest to test the GSM class:
        Create an array of few instances of the GSM class.
        Display the information about the GSMs in the array.
        Display the information about the static property IPhone4S.
*/
namespace MobilePhoneDevice
{
    using System;
    public static class GSMTester
    {
        private static GSM[] gsms =
        {
            new GSM("Galaxy S6", "Samsung"),
            new GSM("One M9", "HTC", 1399, "Pesho", new Display(5, 16000000),
                new Battery("Non-removable Li-Po 2840 mAh battery", 402, 21.83, Battery.BatteryTypes.LiIon)),
            new GSM("Xperia Z2", "Sony", null, "me", new Display(16000000))
        };

        public static void TestGSMs()
        {
            foreach (GSM gsm in gsms)
            {
                Console.WriteLine(gsm);
            }

            Console.WriteLine(GSM.IPhone4S);
        }
    }
}
