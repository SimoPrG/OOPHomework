/*Problem 12. Call history test

    Write a class GSMCallHistoryTest to test the call history functionality of the GSM class.
        Create an instance of the GSM class.
        Add few calls.
        Display the information about the calls.
        Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
        Remove the longest call from the history and calculate the total price again.
        Finally clear the call history and print it.
*/
namespace MobilePhoneDevice
{
    using System;
    public static class CallHistoryTester
    {
        private static GSM gsm = new GSM("One M9", "HTC", 1399, "Pesho", new Display(5, 16000000),
            new Battery("Non-removable Li-Po 2840 mAh battery", 402, 21.83, Battery.BatteryTypes.LiIon));

        public static void TestCallHistory()
        {
            Call call0 = new Call("31.3.2015 9:08:33", "00359 888888", 60);
            Call call1 = new Call("01.4.2015 22:19:04", "+44 123123", 578);
            Call call2 = new Call("02.05.2016 02:16:00", "02 967 2323", 134);

            gsm.AddCall(call0);
            gsm.AddCall(call1);
            gsm.AddCall(call2);

            gsm.ShowCallHistory();

            decimal pricePerMinute = 0.37m;

            Console.WriteLine("Total price: {0:C}", gsm.CalculateTotalPriceOfCalls(pricePerMinute));

            gsm.DeleteCall(1);

            Console.WriteLine("Total price: {0:C}", gsm.CalculateTotalPriceOfCalls(pricePerMinute));

            gsm.ClearCallHistory();

            gsm.ShowCallHistory();
        }
    }
}
