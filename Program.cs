using System;

namespace AlgoCasts_Solution
{
    static class StringReversal
    {
        public static string ReverseIterative(string str)
        {
            string rev = "";
            for (int i = str.Length - 1; i >= 0; i--)
            {
                rev += str[i];
            }
            return rev;
        }
    }
    static class Palindromes
    {
    }
    static class IntegerReversal
    {

    }
    static class MaxChars
    {

    }
    static class FizzBuzz
    {

    }

    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(StringReversal.ReverseIterative("sck my ass"));
        }
    }
}
