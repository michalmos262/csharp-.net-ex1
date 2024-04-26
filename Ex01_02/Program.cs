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
            BuildDiamond(diamond, i_DiamondHeight);
            Console.WriteLine(diamond.ToString());
        }

        static void BuildDiamond(StringBuilder o_Diamond, int i_DiamondHeight, int i_NumOfStarsToAppendToDiamond = 1)
        {
            if (IsCurrentRowBaseOfDiamond(i_DiamondHeight, i_NumOfStarsToAppendToDiamond))
            {
                AppendLineToDiamond(o_Diamond, i_DiamondHeight, i_NumOfStarsToAppendToDiamond);
                return;
            }
            AppendLineToDiamond(o_Diamond, i_DiamondHeight, i_NumOfStarsToAppendToDiamond);
            BuildDiamond(o_Diamond, i_DiamondHeight, i_NumOfStarsToAppendToDiamond + 2);
            AppendLineToDiamond(o_Diamond, i_DiamondHeight, i_NumOfStarsToAppendToDiamond);
        }

        static bool IsCurrentRowBaseOfDiamond(int i_DiamondHeight, int i_NumOfStarsInCurrentRowOfDiamond)
        {
            return i_NumOfStarsInCurrentRowOfDiamond == i_DiamondHeight;
        }

        static void AppendLineToDiamond(StringBuilder o_Diamond, int i_DiamondHeight, int i_NumOfStars)
        {
            int numOfSpacesBeforeStars = (i_DiamondHeight - i_NumOfStars) / 2;

            AppendSpacesToRowInDiamond(o_Diamond, numOfSpacesBeforeStars);
            AppendStarsToRowInDiamond(o_Diamond, i_NumOfStars);
        }

        static void AppendSpacesToRowInDiamond(StringBuilder io_Diamond, int i_NumberOfSpaces)
        {
            io_Diamond.Append(new string(' ', i_NumberOfSpaces));
        }

        static void AppendStarsToRowInDiamond(StringBuilder io_Diamond, int i_NumberOfStars)
        {
            io_Diamond.Append(new string('*', i_NumberOfStars));
            io_Diamond.AppendLine();
        }
    }
}