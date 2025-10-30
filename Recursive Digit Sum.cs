using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'superDigit' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. STRING n
     *  2. INTEGER k
     */

    public static int superDigit(string n, int k)
    {
         // First, calculate the initial sum of digits
        long sum = 0;
        foreach (char c in n) {
            sum += (c - '0');
        }
        
        // Multiply by k for the concatenated string
        sum *= k;
        
        // Keep reducing until single digit
        while (sum > 9) {
            sum = DigitSum(sum);
        }
        
        return (int)sum;
    }
    
    private static long DigitSum(long num) {
        long sum = 0;
        while (num > 0) {
            sum += num % 10;
            num /= 10;
        }
        return sum;
    }

    // Alternative recursive approach
    public static int superDigitRecursive(string n, int k) {
        if (n.Length == 1 && k == 1) {
            return int.Parse(n);
        }
        
        long sum = 0;
        foreach (char c in n) {
            sum += (c - '0');
        }
        
        sum *= k;
        
        return superDigitRecursive(sum.ToString(), 1);
    }

    }

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        string n = firstMultipleInput[0];

        int k = Convert.ToInt32(firstMultipleInput[1]);

        int result = Result.superDigit(n, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
