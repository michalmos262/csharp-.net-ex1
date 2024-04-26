using System;
using System.Text;

namespace Ex01_02
{
    public class Program
    {
        private const int k_DiamondHeight = 9;
        public static void Main()
        {
            DrawDiamond(k_DiamondHeight);
        }

        public static void DrawDiamond(int i_DiamondHeight)
        {
            StringBuilder diamond = new StringBuilder();

            if (i_DiamondHeight % 2 == 0)
            {
                i_DiamondHeight--;
            }

            buildDiamond(diamond, i_DiamondHeight);
            Console.WriteLine(diamond.ToString());
        }

        private static void buildDiamond(StringBuilder o_Diamond, int i_DiamondHeight, int i_NumOfStarsToAppendToDiamond = 1)
        {
            appendLineToDiamond(o_Diamond, i_DiamondHeight, i_NumOfStarsToAppendToDiamond);
            if (isCurrentRowBaseOfDiamond(i_DiamondHeight, i_NumOfStarsToAppendToDiamond))
            {
                return;
            }

            buildDiamond(o_Diamond, i_DiamondHeight, i_NumOfStarsToAppendToDiamond + 2);
            appendLineToDiamond(o_Diamond, i_DiamondHeight, i_NumOfStarsToAppendToDiamond);
        }

        private static bool isCurrentRowBaseOfDiamond(int i_DiamondHeight, int i_NumOfStarsInCurrentRowOfDiamond)
        {
            return i_NumOfStarsInCurrentRowOfDiamond == i_DiamondHeight;
        }

        private static void appendLineToDiamond(StringBuilder o_Diamond, int i_DiamondHeight, int i_NumOfStars)
        {
            int numOfSpacesBeforeStars = (i_DiamondHeight - i_NumOfStars) / 2;

            appendSpacesToRowInDiamond(o_Diamond, numOfSpacesBeforeStars);
            appendStarsToRowInDiamond(o_Diamond, i_NumOfStars);
        }

        private static void appendSpacesToRowInDiamond(StringBuilder io_Diamond, int i_NumberOfSpaces)
        {
            io_Diamond.Append(new string(' ', i_NumberOfSpaces));
        }

        private static void appendStarsToRowInDiamond(StringBuilder io_Diamond, int i_NumberOfStars)
        {
            io_Diamond.Append(new string('*', i_NumberOfStars));
            io_Diamond.AppendLine();
        }
    }
}