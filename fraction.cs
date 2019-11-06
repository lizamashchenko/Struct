using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fraction
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        struct fraction
        {
            public int numerator;
            public int denominator;
            
            public int Write(int num, int denom)
            {
                return (num + '/' + denom);
            }
            public int Plus(int num1, int denom1,int num2,int denom2)
            {
                int NumSum;
                int CommonDenom;
                if(denom1!=denom2)
                {
                    CommonDenom = CommonValue(denom1, denom2);
                    NumSum = num1 * denom2 + num2 * denom1;
                }
                else
                {
                    CommonDenom = denom1;
                    NumSum = num1 + num2;
                }
                return NumSum + '/' + CommonDenom;
            }
            public int Minus(int num1, int denom1, int num2, int denom2)
            {
                int NumDifference;
                int CommonDenom;
                if (denom1 != denom2)
                {
                    CommonDenom = CommonValue(denom1, denom2);
                    NumDifference = num1 * denom2 - num2 * denom1;
                }
                else
                {
                    CommonDenom = denom1;
                    NumDifference = num1 - num2;
                }
                return NumDifference + '/' + CommonDenom;
            }
            public int Multiply(int num1, int denom1, int num2, int denom2)
            {
                int MultNum = num1 * num2;
                int MultDenom = denom1 * denom2;
                return MultNum + '/' + MultDenom;
            }
            public int Division(int num1, int denom1, int num2, int denom2)
            {
                int DivNum = num1 * denom2;
                int DivDenom = denom1 * num2;
                return DivNum + '/' + DivDenom;
            }
            static void Reduction()
            {
                if (CanReduce(numerator,denominator)) Reduce();
            }
        }
        static int CommonValue(int a, int b)
        {
            int CommonValue = 0;
            CommonValue = a * b;
            return CommonValue;
        }
        static bool CanReduce(int num, int denom)
        {
            if (HaveCommonValue(num,denom)) return true;
            else return false;
        }
        static bool HaveCommonValue(int a,int b)
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
        static int FindCommonValue(int a,int b)
        {
            int commonvalue = 0;
            for (int i=1;i<a/2;i++)
            {
                if (a % i == 0 && b % i == 0) commonvalue = i;
            }
            return commonvalue;
        }
        static void Reduce()
        {
            int value = FindCommonValue(numerator, denominator);
            numerator = numerator / value;
            denominator = denominator / value;
        }
    }
}
