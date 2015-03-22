/*Problem 20.* Infinite convergent series

    By using delegates develop an universal static method to calculate the sum of infinite convergent series with given precision
    depending on a function of its term. By using proper functions for the term calculate with a 2-digit precision the sum of the
    infinite series:
        1 + 1/2 + 1/4 + 1/8 + 1/16 + …
        1 + 1/2! + 1/3! + 1/4! + 1/5! + …
        1 + 1/2 - 1/4 + 1/8 - 1/16 + …
*/

using System;

public class InfiniteConvergentSeries
{
    public static void Main()
    {
        const double Precision = 0.01;
        double result;

        result = CalcSumOfConvergentSeries(CalculateNthMemberOf1DividedBy2ToN, Precision);
        Console.WriteLine("1 + 1/2 + 1/4 + 1/8 + 1/16 + … + 1/2^n = {0:F2}", result);

        result = CalcSumOfConvergentSeries(CalculateNthMemberOf1DividedByNFactoriel, Precision);
        Console.WriteLine("1 + 1/2! + 1/3! + 1/4! + 1/5! + … + 1/n! = {0:F2}", result);

        result = CalcSumOfConvergentSeries(CalculateNthMemberOf1DividedBy2ToNAlternating, Precision);
        Console.WriteLine("1 + 1/2 - 1/4 + 1/8 - 1/16 + … +-1/2^n = {0:F2}", result);
    }

    public static double CalcSumOfConvergentSeries(Func<int, double> element, double precision)
    {
        double sum = 1;
        int n = 1;
        double currentElement;

        while (Math.Abs(currentElement = element(n++)) >= precision)
        {
            sum += currentElement;
        }

        return sum;
    }

    // 1 + 1/2 + 1/4 + 1/8 + 1/16 + …  1/2^n
    public static double CalculateNthMemberOf1DividedBy2ToN(int n)
    {
        return 1d / Math.Pow(2, n);
    }

    // 1 + 1/2! + 1/3! + 1/4! + 1/5! + … 1/n!
    public static double CalculateNthMemberOf1DividedByNFactoriel(int n)
    {
        decimal denominator = 1;
        for (int i = n + 1; i > 1; i--)
        {
            denominator *= i;
        }

        return (double)(1 / denominator);
    }

    // 1 + 1/2 - 1/4 + 1/8 - 1/16 + … +-1/2^n
    public static double CalculateNthMemberOf1DividedBy2ToNAlternating(int n)
    {
        if (n % 2 == 1)
        {
            return 1d / Math.Pow(2, n);
        }
        else
        {
            return -1d / Math.Pow(2, n);
        }
    }
}