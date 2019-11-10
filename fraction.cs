using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fraction
{
    class Program
    {
        static void Main()
        {
            int x = 3;
            int y = 5;
            fraction fr1 = new fraction();
            fr1.numerator = x;
            fr1.denominator = y;
            fr1.Write();
            (fr1 + fr1).Write();
        }
        struct fraction
        {
            public int numerator;
            public int denominator;

            public void Write()
            {
                Console.WriteLine(numerator + "/" + denominator);
            }
            public static fraction operator +(fraction fr1, fraction fr2)
            {
                int NumSum;
                int CommonDenom;
                if (fr1.denominator != fr2.denominator)
                {
                    CommonDenom = CommonValue(fr1.denominator, fr2.denominator);
                    NumSum = fr1.numerator * fr2.denominator + fr2.numerator * fr1.denominator;
                }
                else
                {
                    CommonDenom = fr1.denominator;
                    NumSum = fr1.numerator + fr2.numerator;
                }

                fraction f;
                f.numerator = NumSum;
                f.denominator = CommonDenom;
                return f;
            }
            public static fraction operator -(fraction fr1, fraction fr2)
            {
                int NumDifference;
                int CommonDenom;
                if (fr1.denominator != fr2.denominator)
                {
                    CommonDenom = CommonValue(fr1.denominator, fr2.denominator);
                    NumDifference = fr1.numerator * fr2.denominator - fr2.numerator * fr1.denominator;
                }
                else
                {
                    CommonDenom = fr1.denominator;
                    NumDifference = fr1.numerator - fr2.numerator;
                }
                fraction f;
                f.numerator = NumDifference;
                f.denominator = CommonDenom;
                return f;
            }
            public static fraction operator *(fraction fr1, fraction fr2)
            {
                int MultNum = fr1.numerator * fr2.numerator;
                int MultDenom = fr1.denominator * fr2.denominator;
                fraction f;
                f.numerator = MultNum;
                f.denominator = MultDenom;
                return f;
            }
            public static fraction operator /(fraction fr1, fraction fr2)
            {
                int DivNum = fr1.numerator * fr2.denominator;
                int DivDenom = fr1.denominator * fr2.numerator;
                fraction f;
                f.numerator = DivNum;
                f.denominator = DivDenom;
                return f;
            }
            public static fraction operator !(fraction f1)
            {
                fraction f;
                f.numerator = f1.numerator;
                f.denominator = f1.denominator;
                if (CanReduce(f1))
                {
                    f = Reduce(f1);
                }
                return f;
            }
            public static fraction Reduce(fraction f1)
            {
                int value = FindCommonValue(f1.numerator, f1.denominator);
                fraction f;
                f.numerator = f1.numerator / value;
                f.denominator = f1.denominator / value;
                return f;
            }
        }







        static int CommonValue(int a, int b)
        {
            int CommonValue = 0;
            CommonValue = a * b;
            return CommonValue;
        }
        static bool CanReduce(fraction f1)
        {
            if (HaveCommonValue(f1.numerator, f1.denominator)) return true;
            else return false;
        }
        static bool HaveCommonValue(int a, int b)
        {
            if (a > b)
            {
                for (int i = 1; i < a / 2; i++)
                {
                    if (a % i == 0 && b % b == 0)
                    {
                        return true;
                    }
                }
            }
            else
            {
                for (int i = 1; i < b / 2; i++)
                {
                    if (a % i == 0 && b % b == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static int FindCommonValue(int a, int b)
        {
            int commonvalue = 0;
            for (int i = 1; i < a / 2; i++)
            {
                if (a % i == 0 && b % i == 0) commonvalue = i;
            }
            return commonvalue;
        }

    }
}