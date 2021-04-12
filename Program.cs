using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace AlgoCasts_Solution
{
    static class StringReversal
    {
        // --- Directions
        // Given a string, return a new string with the reversed
        // order of characters
        // --- Examples
        //   reverse('apple') === 'leppa'
        //   reverse('hello') === 'olleh'
        //   reverse('Greetings!') === '!sgniteerG'

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
        // --- Directions
        // Given a string, return true if the string is a palindrome
        // or false if it is not.  Palindromes are strings that
        // form the same word if it is reversed. *Do* include spaces
        // and punctuation in determining if the string is a palindrome.
        // --- Examples:
        //   palindrome("abba") === true
        //   palindrome("abcdefg") === false

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
        // --- Directions
        // Given an integer, return an integer that is the reverse
        // ordering of numbers.
        // --- Examples
        //   reverseInt(15) === 51
        //   reverseInt(981) === 189
        //   reverseInt(500) === 5
        //   reverseInt(-15) === -51
        //   reverseInt(-90) === -9

        public static int Reverse(int num)
        {
            string str = num.ToString().Trim('-');
            string revStr = StringReversal.ReverseUsingArrayMethod(str);
            return Int32.Parse(revStr) * Math.Sign(num);
        }
    }
    static class MaxChars
    {
        // --- Directions
        // Given a string, return the character that is most
        // commonly used in the string.
        // --- Examples
        // maxChar("abcccccccd") === "c"
        // maxChar("apple 1231111") === "1"
        //
        // No solution for equal amount of char case implemented

        public static char FindMaxChars(string str)
        {
            Dictionary<char, int> charAppearsTimes = new Dictionary<char, int>();

            foreach (char c in str)
            {
                if (charAppearsTimes.ContainsKey(c))
                    charAppearsTimes[c]++;
                else
                    charAppearsTimes.Add(c, 1);
            }

            var keys = charAppearsTimes.Keys.ToImmutableList();
            var values = charAppearsTimes.Values;
            int index = 0;
            int maxIndex = 0;
            int maxValue = 0;

            foreach (int value in values)
            {
                if (value > maxValue)
                    maxIndex = index;
                    maxValue = value;

                index++;
            }

            return keys[maxIndex];
        }
    }
    static class FizzBuzz
    {

    }
    static class ArrayChunking
    {

    }
    static class Anagrams
    {

    }
    static class SentenceCapitalization
    {

    }
    static class PrintingSteps
    {

    }
    static class Pyramid
    {

    }
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MaxChars.FindMaxChars("abbbbcccccdddd")); ;
        }
    }
}
