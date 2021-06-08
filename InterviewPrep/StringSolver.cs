using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InterviewPrep
{
    static class StringSolver
    {
        private static readonly Regex cleaner = new Regex(@"\s+");

        /// <summary>
        /// Determine if a string has all unique charecters
        /// </summary>
        /// <param name="testString">String to test</param>
        /// <returns>true if string contains all unique charecters</returns>
        public static void isUnique()
        {
            // asdf should return true
            // asdfee should return false
            // Create hashtable with char 
            // Remove unwanted charecters from string using regex
            // Check each char if it exists in table return false (we found a duplicate) else add to table
            // if foreach completes return true (no duplicates found)

            Console.Clear();
            Console.WriteLine("Please enter a string to test whether it is unique or not");
            string testString = Console.ReadLine();

            string cleanString = cleaner.Replace(testString, "").ToLower();

            Hashtable foundChars = new Hashtable();

            foreach (char c in cleanString)
            {
                if (foundChars.Contains(c))
                {
                    Console.WriteLine("The entered string was not unique! (press any key to continue)");
                    Console.ReadKey();
                    return;
                }
                foundChars.Add(c, true);
            }

            Console.WriteLine("The entered string was unique! (press any key to continue)");
            Console.ReadKey();
        }

        /// <summary>
        /// Checks if the given strings are permutations of each other
        /// </summary>
        public static void isPermutation()
        {
            Console.Clear();
            //First solution order both strings and compare (O(n^2))
            //string orderedS1 = String.Concat(s1.OrderBy(c => c));
            //string orderedS2 = String.Concat(s2.OrderBy(c => c));
            //if (orderedS1 == orderedS2)
            //    return true;
            //return false;

            Console.Write("Please enter the first string: ");
            string s1 = Console.ReadLine();
            Console.Write("Please enter the second string: ");
            string s2 = Console.ReadLine();

            //Second solution store chars in table and check for existence on second string
            //They are different lengths can't be permutations
            if (s1.Length != s2.Length)
            {
                Console.WriteLine("The strings were two different lengths and therefor cannot be permutations of eachother (press any key to continue)");
                Console.ReadKey();
                return;
            }

            Dictionary<char, int> s1Dict = new Dictionary<char, int>();

            //Initialize dictionary from s1 
            foreach (char c in s1)
            {
                if (s1Dict.ContainsKey(c))
                    s1Dict[c]++;
                else
                    s1Dict.Add(c, 1);
            }

            foreach (char c in s2)
            {
                //found a char in s2 that is not in s1
                if (!s1Dict.ContainsKey(c))
                {
                    Console.WriteLine("The two strings are NOT permutations of eachother (press any key to continue)");
                    Console.ReadKey();
                    return;
                }
                //found a char that appears more in s2 than s1
                else if (--s1Dict[c] < 0)
                {
                    Console.WriteLine("The two strings are NOT permutations of eachother (press any key to continue)");
                    Console.ReadKey();
                    return;
                }
            }

            Console.WriteLine("The two strings are permutations of eachother! (press any key to continue)");
            Console.ReadKey();
        }

        /// <summary>
        /// Check if given string is a palindrome meaning it is the same forwards and backwards (we can do this two ways)
        /// </summary>
        public static void isPalindrome()
        {
            Console.Clear();
            Console.Write("Please enter the string to be tested: ");
            string s1 = Console.ReadLine();
            string cleanString = cleaner.Replace(s1, "").ToLower();
            //The first solution is to simply reverse the string and see if it is the same
            //char[] charArray = cleanString.ToCharArray();
            //Array.Reverse(array: charArray);
            //string reversedString = new string(charArray);

            //if (cleanString == reversedString)
            //{
            //    Console.WriteLine("The given string is a palindrome! (press any key to continue)");
            //    Console.ReadKey();
            //    return;
            //}
            //else
            //{
            //    Console.WriteLine("The given string is NOT a palindrome! (press any key to continue)");
            //    Console.ReadKey();
            //    return;
            //}

            //The second solution is to have two pointers that start at the ends and compare to eachother until they meet
            for(int i = 0; i <= cleanString.Length/2; i++)
            {
                //found middle break!
                if (i == cleanString.Length - (i + 1))
                    break;

                if (cleanString[i] != cleanString[cleanString.Length-(i+1)])
                {
                    Console.WriteLine("The given string is NOT a palindrome! (press any key to continue)");
                    Console.ReadKey();
                    return;
                }
            }

            Console.WriteLine("The given string is a palindrome! (press any key to continue)");
            Console.ReadKey();
            return;
        }

        //Check if given string is a permutation of a palindrome
        //Palindrome means that the word/sentence is the same forward as it is backwards
        //Permutation means it does not have to be in the right order
        //Palindrome example = WoW, Taco cat
        //Permutation example = tatoca (taco cat)
        public static void isPalindromePerm()
        {
            //Check if all charecters appear an even amount of times (except 1 in case of odd length string)
            //Probably use a hashmap to count
            //Solution 1 store in hash map then read through hashmap again
            //Dictionary<char, int> foundChars = new Dictionary<char, int>();
            //foreach(char c in s1)
            //{
            //    if (foundChars.ContainsKey(c))
            //        foundChars[c]++;
            //    else
            //        foundChars.Add(c, 1);
            //}

            //bool foundOdd = false;

            //foreach(KeyValuePair<char,int> kvp in foundChars)
            //{
            //    if (kvp.Value % 2 != 0)
            //        if (foundOdd)
            //            return false;
            //        else
            //        {
            //            foundOdd = true;
            //        }
            //}

            //Solution 2 order first prevents having final loop
            Console.Clear();
            Console.Write("Please enter the string to be tested: ");
            string s1 = Console.ReadLine();

            string orderedString = String.Concat(s1.OrderBy(c => c));

            bool foundOdd = false;
            int charCount = 0;
            char currentChar = orderedString[0];
            for (int i = 0; i < orderedString.Length; i++)
            {
                if (orderedString[i] == currentChar)
                {
                    charCount++;
                }
                else
                {
                    if (charCount % 2 != 0)
                        if (foundOdd)
                        {
                            Console.WriteLine("The given string is NOT a permutation of a palindrome! (press any key to continue)");
                            Console.ReadKey();
                            return;
                        }
                        else
                            foundOdd = true;
                    charCount = 1;
                    currentChar = orderedString[i];
                }
            }

            Console.WriteLine("The given string is a permutation of a palindrome! (press any key to continue)");
            Console.ReadKey();
            return;
        }

        public static bool isUniqueNoAddDataStruct(string testString)
        {
            //Order string
            //Check indexes to see if i = i+1
            string cleanString = cleaner.Replace(testString, "").ToLower();
            string orderedString = String.Concat(cleanString.OrderBy(c => c));
            for (int i = 0; i < orderedString.Length - 1; i++)
            {
                if (orderedString[i] == orderedString[i + 1])
                    return false;
            }
            return true;
        }
    }
}
