using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

/// <summary>
/// This project is dedicated to answering common interview questions and to practice for coding interviews
/// </summary>
namespace InterviewPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ask user what question they want to see answered
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select a question: \r\n1: Is Unique\r\n2: Permutation\r\n3: Palindrome\r\n4: Palindrome Permutation\r\n");
                char choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    case '1':
                        StringSolver.isUnique();
                        break;
                    case '2':
                        StringSolver.isPermutation();
                        break;
                    case '3':
                        StringSolver.isPalindrome();
                        break;
                    case '4':
                        StringSolver.isPalindromePerm();
                        break;
                }
            }
        }
    }
}
