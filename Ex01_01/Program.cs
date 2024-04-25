using System;

namespace Ex01_01
{
    class Program
    {
        private const int k_NumOfInputNumbers = 3;
        private const int k_BinarySeriesLength = 9;

        public static void Main()
        {
            BinarySeriesAnalysis();
        }

        public static void BinarySeriesAnalysis()
        {
            string[] binaryStringsArray = getBinarySeriesFromUser();
            uint[] binarySeriesDecimalValues = getBinarySeriesDecimalValues(binaryStringsArray);

            Array.Sort(binarySeriesDecimalValues);
            Console.Write("The numbers in ascending manner are:");
            printArray(binarySeriesDecimalValues);
            printStatisticsOfNumbers(binarySeriesDecimalValues, binaryStringsArray);
        }

        private static string[] getBinarySeriesFromUser()
        {
            string[] binaryNumbers = new string[k_NumOfInputNumbers];
            int validCount = 0;
            string userInput;
            
            Console.WriteLine($"Please enter {k_NumOfInputNumbers} binary numbers of {k_BinarySeriesLength} digits each:");

            while (validCount < k_NumOfInputNumbers)
            {
                userInput = Console.ReadLine();

                if (userInput.Length == k_BinarySeriesLength && isInputValid(userInput))
                {
                    binaryNumbers[validCount] = userInput;
                    validCount++;
                }
                else
                {
                    Console.WriteLine("Invalid binary number. Please enter a positive binary number of 9 digits.");
                }
            }

            return binaryNumbers;
        }

        private static bool isInputValid(string i_UserInput)
        {
            bool isBinaryNum = true, isPositiveNum = false;

            for (int i = 0; i < i_UserInput.Length && isBinaryNum; i++)
            {
                if (i_UserInput[i] != '0' && i_UserInput[i] != '1')
                {
                    isBinaryNum = false;
                }
                else if(i_UserInput[i] == '1')
                {
                    isPositiveNum = true;
                }
            }
            
            return isBinaryNum && isPositiveNum;
        }

        private static uint[] getBinarySeriesDecimalValues(string[] i_BinaryStringsArray)
        {
            uint[] decimalValues = new uint[i_BinaryStringsArray.Length];

            for (int i = 0; i < i_BinaryStringsArray.Length; i++)
            {
                decimalValues[i] = BinaryStringToDecimal(i_BinaryStringsArray[i]);
            }

            return decimalValues;
        }

        private static uint BinaryStringToDecimal(string i_BinaryString)
        {
            uint decimalValue = 0;
            int power = 0;

            for (int i = i_BinaryString.Length - 1; i >= 0; i--)
            {
                if (i_BinaryString[i] == '1')
                {
                    decimalValue += (uint)Math.Pow(2, power);
                }
                power++; 
            }

            return decimalValue;
        }

        private static void printArray(uint[] i_Array)
        {
            for (int i = 0; i < i_Array.Length; i++)
            {
                if (i != 0)
                {
                    Console.Write(" ");
                }
                Console.Write(i_Array[i]);
            }
            Console.Write(Environment.NewLine);
        }

        private static void printStatisticsOfNumbers(uint[] i_Array, string [] i_BinaryStringsArray)
        {
            uint[] zerosInBinaryStringCounters = new uint[i_BinaryStringsArray.Length], onesInBinaryStringCounters = new uint[i_BinaryStringsArray.Length];
            uint powerOfTwoNumbersCounter, ascendingSeriesNumberCounter = 0;
            float averageNumOfZeros, averageNumOfOnes;
            string statistics;

            CountZerosAndOnesInBinaryNumsArray(i_BinaryStringsArray, zerosInBinaryStringCounters, onesInBinaryStringCounters);
            averageNumOfZeros = (float)SumArray(zerosInBinaryStringCounters) / (float)i_BinaryStringsArray.Length;
            averageNumOfOnes = (float)SumArray(onesInBinaryStringCounters) / (float)i_BinaryStringsArray.Length;
            powerOfTwoNumbersCounter = countPowerOfTwoNumbers(onesInBinaryStringCounters);
            ascendingSeriesNumberCounter = countAscendingSeriesNumbers(i_Array);
            statistics = string.Format(
                @"
The average number of zeros in the binary number is {0}.
The average number of ones in the binary number is {1}.
There are {2} numbers which are a power of 2.
There are {3} numbers which their decimal digits are an ascending series
The largest number is {4} and the smallest is {5}", averageNumOfZeros, averageNumOfOnes, powerOfTwoNumbersCounter, ascendingSeriesNumberCounter, i_Array[i_Array.Length - 1], i_Array[0]);
            Console.WriteLine(statistics);
        }

        private static void CountZerosAndOnesInBinaryNumsArray(string[] i_BinaryStringsArray, uint[] io_ZerosInBinaryStringCounters, uint[] io_OnesInBinaryStringCounters)
        {
            uint currentBinaryStringZerosCounter, currentBinaryStringOnesCounter;

            for (int i = 0; i < i_BinaryStringsArray.Length; i++)
            {
                currentBinaryStringZerosCounter = currentBinaryStringOnesCounter = 0;
                CountZerosAndOnesInBinarySeries(i_BinaryStringsArray[i], ref currentBinaryStringZerosCounter, ref currentBinaryStringOnesCounter);
                io_ZerosInBinaryStringCounters[i] = currentBinaryStringZerosCounter;
                io_OnesInBinaryStringCounters[i] = currentBinaryStringOnesCounter;
            }
        }

        private static void CountZerosAndOnesInBinarySeries(string i_BinaryString, ref uint io_ZerosCounter, ref uint io_OnesCounter)
        {
            foreach (char digit in i_BinaryString)
            {
                if (digit == '0')
                {
                    io_ZerosCounter++;
                }
                else if (digit == '1')
                {
                    io_OnesCounter++;
                }
            }
        }

        private static uint SumArray(uint[] i_Array)
        {
            uint total = 0;
            foreach (uint num in i_Array)
            {
                total += num;
            }
            return total;
        }

        private static uint countPowerOfTwoNumbers(uint[] i_OnesInBinaryStringCounters)
        {
            uint powerOfTwoNumbersCounter = 0;

            foreach(uint numOfOnes in i_OnesInBinaryStringCounters)
            {
                if (numOfOnes == 1)
                    powerOfTwoNumbersCounter++;
            }

            return powerOfTwoNumbersCounter;
        }

        private static uint countAscendingSeriesNumbers(uint[] i_Numbers)
        {
            uint count = 0;

            foreach (uint num in i_Numbers)
            {
                if (isDigitsAnAscendingSeries(num))
                {
                    count++;
                }
            }

            return count;
        }

        private static bool isDigitsAnAscendingSeries(uint i_Number)
        {
            string numberString = i_Number.ToString();
            bool isDigitsAnAscendingSeries = true;

            for (int i = 1; i < numberString.Length && isDigitsAnAscendingSeries; i++)
            {
                if (numberString[i] <= numberString[i - 1])
                {
                    isDigitsAnAscendingSeries = false;
                }
            }

            return isDigitsAnAscendingSeries;
        }
    }


}
