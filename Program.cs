using System;
using System.Linq;
using System.Collections.Generic;

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
        public static string ReverseRecursive(string str, string rev = "", int i = 1)
        {
            if (i > str.Length)
                return rev;
            rev += str[str.Length - i];
            return ReverseRecursive(str, rev, i + 1);
        }
        public static string ReverseUsingArrayMethod(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
    static class Palindromes
    {
        public static bool IsPalindromeUsingReverse(string str)
        {
            if (StringReversal.ReverseUsingArrayMethod(str) == str)
                return true;
            else
                return false;
        }
        public static bool IsPalindromCharComparison(string str)
        {
            static IEnumerable<bool> CharEqulity(string str)
            {
                for (int i = 0; i <= str.Length / 2; i++)
                {
                    yield return str[i] == str[str.Length - (1 + i)];
                }
            }

            List<bool> charEq = CharEqulity(str).ToList();

            if (!charEq.Contains(false))
                return true;
            else
                return false;
        }
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
            Console.WriteLine(Palindromes.IsPalindromCharComparison("aasssaa  "));
        }
    }
}
