using System;
using System.Text;

namespace Ex01_04
{
    class Program
    {
        private const uint k_InputStringLen = 10;
        private const int k_Diviser = 4;

        public static void Main()
        {
            StringAnalysis();
        }
        public static void StringAnalysis()
        {
            string englishStringOrNumber = getEnglishStringOrNumber();

            printStringStatistics(englishStringOrNumber);
        }

        private static void printStringStatistics(string i_EnglishStringOrNumber)
        {
            string PalindromeAnalysis, divisibleBySpecificNumberAnalysis, numOfLowercaseLettersAnalysis,statistics;

            PalindromeAnalysis = getPalindromeAnalysis(i_EnglishStringOrNumber);
            divisibleBySpecificNumberAnalysis = getDivisionBySpecificNumberAnalysis(i_EnglishStringOrNumber);
            numOfLowercaseLettersAnalysis = getEnglishStrAnalysis(i_EnglishStringOrNumber);
            statistics = string.Format(
                @"
----- Statistics of the string you typed -----

Palindrome analysis: {0}.
Number analysis of the string: {1}.
English analysis of the string: {2}.
"
, PalindromeAnalysis, divisibleBySpecificNumberAnalysis, numOfLowercaseLettersAnalysis);
            Console.WriteLine(statistics);
        }

        private static string getEnglishStringOrNumber()
        {
            string userInputStr, welcomeMessage = $"Please enter a string with {k_InputStringLen} characters consisting solely of either English alphabet letters or digits.";

            Console.WriteLine(welcomeMessage);
            userInputStr = Console.ReadLine();
            while (!isUserInputInCorrectLenAndANumberOrInEnglish(userInputStr))
            {
                Console.Write("Invalid input ");
                Console.WriteLine(welcomeMessage);
                userInputStr = Console.ReadLine();
            }

            return userInputStr;
        }

        private static bool isUserInputInCorrectLenAndANumberOrInEnglish(string i_UserInput)
        {
            return (i_UserInput.Length == k_InputStringLen) && isInputNumberOrInEnglish(i_UserInput);
        }

        private static bool isInputNumberOrInEnglish(string i_UserInput)
        {
            bool isUserInputNumber, isUserInputInEnglish, isUserInputOnlyLowerCase, isUserInputOnlyUpperCase, isUserInputValid;

            isUserInputNumber = isStringANumber(i_UserInput);
            isUserInputInEnglish = isStringInEnglish(i_UserInput);
            isUserInputOnlyLowerCase = i_UserInput == i_UserInput.ToLower();
            isUserInputOnlyUpperCase = i_UserInput == i_UserInput.ToUpper();
            isUserInputValid = isUserInputNumber || (isUserInputInEnglish && (isUserInputOnlyLowerCase || isUserInputOnlyUpperCase));
         
            return isUserInputValid;
        }

        private static bool isStringANumber(string i_InputStr)
        {
            int numberValue;

            return int.TryParse(i_InputStr, out numberValue);
        }
        private static bool isStringInEnglish(string i_InputStr)
        {
            bool isInputInEnglish = true;
            char currentChar;

            for (int i = 0; i < i_InputStr.Length && isInputInEnglish; i++)
            {
                currentChar = i_InputStr[i];
                if ((currentChar < 'A' || currentChar > 'Z') && (currentChar < 'a' || currentChar > 'z'))
                {
                    isInputInEnglish = false;
                }
            }

            return isInputInEnglish;
        }

        private static string getPalindromeAnalysis(string i_EnglishStringOrNumber)
        {
            string palindromeAnalysis, palindromState;
            StringBuilder strBuilderCopy = new StringBuilder(i_EnglishStringOrNumber);

            palindromState = isPalindrome(strBuilderCopy) ? "" : " not";
            palindromeAnalysis = string.Format("The string is{0} a palindrome", palindromState);

            return palindromeAnalysis;
        }

        private static bool isPalindrome(StringBuilder i_StrBuilder)
        {
            bool result;

            if (i_StrBuilder.Length <= 1)
            {
                result = true;
            }
            else if (i_StrBuilder[0] != i_StrBuilder[i_StrBuilder.Length - 1])
            {
                result = false;
            }
            else
            {
                i_StrBuilder.Remove(0, 1);
                i_StrBuilder.Remove(i_StrBuilder.Length - 1, 1);
                result = isPalindrome(i_StrBuilder);
            }

            return result;
        }

        private static string getDivisionBySpecificNumberAnalysis(string i_StrOrNumberValue)
        {
            string divisionBySpecificNumberAnalysis, isDivisibleStr;
            int numberValue;

            if (isStringANumber(i_StrOrNumberValue))
            {
                numberValue = int.Parse(i_StrOrNumberValue);
                isDivisibleStr = numberValue % k_Diviser == 0 ? "" : " not";
                divisionBySpecificNumberAnalysis = string.Format("The string is a number and it is{0} divisible by {1}", isDivisibleStr, k_Diviser);
            }
            else
            {
                divisionBySpecificNumberAnalysis = "The string is not a number";
            }

            return divisionBySpecificNumberAnalysis;
        }

        private static string getEnglishStrAnalysis(string i_StrOrNumberValue)
        {
            string englishAnalysis;

            if (isStringInEnglish(i_StrOrNumberValue))
            {
                englishAnalysis = $"The string is english and it has {countLowerCaseLetters(i_StrOrNumberValue)} lower case letters";
            }
            else
            {
                englishAnalysis = "The string is not in english";
            }

            return englishAnalysis;
        }

        private static int countLowerCaseLetters(string i_Str)
        {
            int numOfLowerCaseLetters = 0;

            foreach (char letter in i_Str)
            {
                if (char.IsLower(letter))
                {
                    numOfLowerCaseLetters++;
                }
            }

            return numOfLowerCaseLetters;
        }
    }
}
