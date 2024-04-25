using System;
using System.Text;

namespace Ex01_04
{
    class Program
    {
        private const uint k_InputStringLen = 10;

        public static void Main()
        {
            StringAnalysis();
        }
        public static void StringAnalysis()
        {
            string englishStringOrNumber;

            englishStringOrNumber = getEnglishStringOrNumber();
            printStringStatistics(englishStringOrNumber);
        }

        private static void printStringStatistics(string i_EnglishStringOrNumber)
        {
            string PalindromeAnalysis, divisibleBy4Analysis, numOfLowercaseLettersAnalysis,statistics;

            PalindromeAnalysis = getPalindromeAnalysis(i_EnglishStringOrNumber);
            divisibleBy4Analysis = getDivisionBy4Analysis(i_EnglishStringOrNumber);
            numOfLowercaseLettersAnalysis = getEnglishStrAnalysis(i_EnglishStringOrNumber);

            statistics = string.Format(
                @"
----- Statistics of the string you typed -----
Palindrome analysis: {0}.
Number analysis of the string: {1}.
English analysis of the string: {2}.
"
, PalindromeAnalysis, divisibleBy4Analysis, numOfLowercaseLettersAnalysis);

            Console.WriteLine(statistics);
        }

        private static string getEnglishStringOrNumber()
        {
            string inputString, welcomeMessage = $"Please enter a string with {k_InputStringLen} characters consisting solely of either English alphabet letters or digits.";

            Console.WriteLine(welcomeMessage);
            inputString = Console.ReadLine();
            while (!isStringNumberOrInEnglish(inputString))
            {
                Console.Write("Invalid input ");
                Console.WriteLine(welcomeMessage);
                inputString = Console.ReadLine();
            }

            return inputString;
        }

        private static bool isStringNumberOrInEnglish(string i_String)
        {
            bool isNumber, isStringInEnglish, isStringOnlyLowerCase, isStringOnlyUpperCase, isStringValid;

            if (i_String.Length == k_InputStringLen) // If the length is valid
            {
                isNumber = isStringANumber(i_String);
                isStringInEnglish = IsStringInEnglish(i_String);
                isStringOnlyLowerCase = i_String == i_String.ToLower();
                isStringOnlyUpperCase = i_String == i_String.ToUpper();
                isStringValid = isNumber || (isStringInEnglish && (isStringOnlyLowerCase || isStringOnlyUpperCase));
            }
            else
                isStringValid = false;

            return isStringValid;
        }

        private static bool isStringANumber(string i_String)
        {
            int stringNumberValue;
            return int.TryParse(i_String, out stringNumberValue);
        }
        private static bool IsStringInEnglish(string i_String)
        {
            bool IsStringInEnglish = true;
            char currentChar;

            for (int i = 0; i < i_String.Length && IsStringInEnglish; i++)
            {
                currentChar = i_String[i];
                if ((currentChar < 'A' || currentChar > 'Z') && (currentChar < 'a' || currentChar > 'z') && !char.IsWhiteSpace(currentChar))
                {
                    IsStringInEnglish = false;
                }
            }

            return IsStringInEnglish;
        }

        private static string getPalindromeAnalysis(string i_EnglishStringOrNumber)
        {
            string palindromeAnalysis, isPalindromeStr;
            StringBuilder strBuilderCopy= new StringBuilder(i_EnglishStringOrNumber);

            isPalindromeStr = isPalindrome(strBuilderCopy) ? "" : " not";
            palindromeAnalysis = string.Format("The string is{0} a palindrome", isPalindromeStr);

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

        private static string getDivisionBy4Analysis(string i_EnglishStringOrNumber)
        {
            string divisionBy4Analysis, isDivisibleStr;
            int stringNumberValue;

            if (isStringANumber(i_EnglishStringOrNumber))
            {
                stringNumberValue = int.Parse(i_EnglishStringOrNumber);
                isDivisibleStr = stringNumberValue % 4 == 0 ? "" : " not";
                divisionBy4Analysis = string.Format("The string is a number and it is{0} divisible by 4", isDivisibleStr);
            }
            else
            {
                divisionBy4Analysis = "The string is not a number";
            }

            return divisionBy4Analysis;
        }

        private static string getEnglishStrAnalysis(string i_EnglishStringOrNumber)
        {
            string englishAnalysis;

            if (IsStringInEnglish(i_EnglishStringOrNumber))
            {
                englishAnalysis = $"The string is english and it has {countLowerCaseLetters(i_EnglishStringOrNumber)} lower case letters";
            }
            else
            {
                englishAnalysis = "The string is not in english";
            }

            return englishAnalysis;
        }

        private static int countLowerCaseLetters(string i_Str)
        {
            int numOfLowerCaseLettersCounter = 0;

            foreach (char letter in i_Str)
            {
                if (char.IsLower(letter))
                {
                    numOfLowerCaseLettersCounter++;
                }
            }
            return numOfLowerCaseLettersCounter;
        }

    }
}
