using System;
using System.Text;
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
        // --- Directions
        // Write a program that console logs the numbers
        // from 1 to n. But for multiples of three print
        // “fizz” instead of the number and for the multiples
        // of five print “buzz”. For numbers which are multiples
        // of both three and five print “fizzbuzz”.
        // --- Example
        //   fizzBuzz(5);
        //   1
        //   2
        //   fizz
        //   4
        //   buzz
        public static string Iterative(int length)
        {
            var sb = new StringBuilder();

            for (int i = 1; i <= length; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    sb.AppendLine("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    sb.AppendLine("Fizz");
                }
                else if (i % 5 == 0)
                {
                    sb.AppendLine("Buzz");
                }
                else
                {
                    sb.AppendLine(i.ToString());
                }
            }

            return sb.ToString();
        }
    }
    static class ArrayChunking
    {
        // --- Directions
        // Given an array and chunk size, divide the array into many subarrays
        // where each subarray is of length size
        // --- Examples
        // chunk([1, 2, 3, 4], 2) --> [[ 1, 2], [3, 4]]
        // chunk([1, 2, 3, 4, 5], 2) --> [[ 1, 2], [3, 4], [5]]
        // chunk([1, 2, 3, 4, 5, 6, 7, 8], 3) --> [[ 1, 2, 3], [4, 5, 6], [7, 8]]
        // chunk([1, 2, 3, 4, 5], 4) --> [[ 1, 2, 3, 4], [5]]
        // chunk([1, 2, 3, 4, 5], 10) --> [[ 1, 2, 3, 4, 5]]

        public static Array ChunkArrayWithBoxing(Array sourceArray, int chunkSize)
        {
            int nestedArraySize = (int)Math.Ceiling((decimal)sourceArray.Length / (decimal)chunkSize);
            Array nestedArray = Array.CreateInstance(typeof(Array), nestedArraySize);

            var nestedIndex = 0;
            var tailLength = sourceArray.Length % chunkSize;

            for (int i = 0; i + chunkSize <= sourceArray.Length; i += chunkSize)
            {
                object[] chunk = new object[chunkSize];
                Array.Copy(sourceArray, i, chunk, 0, chunkSize);

                nestedArray.SetValue(chunk, nestedIndex);
                nestedIndex++;
            }

            if (tailLength != 0)
            {
                object[] tail = new object[tailLength];
                Array.Copy(sourceArray, sourceArray.Length - tailLength, tail, 0, tailLength);

                nestedArray.SetValue(tail, nestedIndex);
            }

            return nestedArray;
        }
    }
    static class Anagrams
    {
        // --- Directions
        // Check to see if two provided strings are anagrams of eachother.
        // One string is an anagram of another if it uses the same characters
        // in the same quantity. Only consider characters, not spaces
        // or punctuation.  Consider capital letters to be the same as lower case
        // --- Examples
        //   anagrams('rail safety', 'fairy tales') --> True
        //   anagrams('RAIL! SAFETY!', 'fairy tales') --> True
        //   anagrams('Hi there', 'Bye there') --> False


    }
    static class SentenceCapitalization
    {
        // --- Directions
        // Write a function that accepts a string.  The function should
        // capitalize the first letter of each word in the string then
        // return the capitalized string.
        // --- Examples
        //   capitalize('a short sentence') --> 'A Short Sentence'
        //   capitalize('a lazy fox') --> 'A Lazy Fox'
        //   capitalize('look, it is working!') --> 'Look, It Is Working!'


    }
    static class PrintingSteps
    {
        // --- Directions
        // Write a function that accepts a positive number N.
        // The function should console log a step shape
        // with N levels using the # character.  Make sure the
        // step has spaces on the right hand side!
        // --- Examples
        //   steps(2)
        //       '# '
        //       '##'
        //   steps(3)
        //       '#  '
        //       '## '
        //       '###'
        //   steps(4)
        //       '#   '
        //       '##  '
        //       '### '
        //       '####'


    }
    static class Pyramid
    {
        // --- Directions
        // Write a function that accepts a positive number N.
        // The function should console log a pyramid shape
        // with N levels using the # character.  Make sure the
        // pyramid has spaces on both the left *and* right hand sides
        // --- Examples
        //   pyramid(1)
        //       '#'
        //   pyramid(2)
        //       ' # '
        //       '###'
        //   pyramid(3)
        //       '  #  '
        //       ' ### '
        //       '#####'


    }
    static class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            Console.WriteLine(ArrayChunking.ChunkArrayWithBoxing(arr, 3).ToString());
        }
    }
}
