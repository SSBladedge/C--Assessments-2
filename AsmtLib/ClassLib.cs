


namespace AsmtLib
{
    public class Lib
    {
        public static void NumToTxt()
        {
            int num = GetInputNum();

            if (num == 0)
                Console.WriteLine("ZERO");
            else
            {
                var numArray = GetNumArray(num);

                foreach (int item in numArray)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static int GetInputNum()
        {
            int intInput;

            while (true)
            {
                Console.WriteLine("Please input a 32-bit number");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out intInput))
                    break;
                else
                {
                    Console.Clear();
                    continue;
                }
            }

            return intInput;
        }

        private static int[] GetNumArray(int num)
        {
            List<int> numList = new List<int>();

            while (num > 0)
            {
                numList.Add(num % 10);
                num = num / 10;
            }
            numList.Reverse();
            return numList.ToArray();
        }

        private static void FirstLevelText(int[] numArray)
        {
            if (numArray.Length > 3)
            {
                Console.WriteLine("ERROR!! INVALID INPUT");
            }
            else
            {
                Dictionary<int, string> firstStage = new Dictionary<int, string>()
                {
                    {1, "ONE"}, {2, "TWO"}, {3, "THREE"}, {4, "FOUR"}, {5, "FIVE"},
                    {6, "SIX"}, {7, "SEVEN"}, {8, "EIGHT"}, {9, "NINE"}, {10, "TEN"},
                    {11, "ELEVEN"}, {12, "TWELVE"}, {13, "THIRTEEN"}, {14, "FOURTEEN"}, {15, "FIFTEEN"},
                    {16, "SIXTEEN"}, {17, "SEVENTEEN"}, {18, "EIGHTEEN"}, {19, "NINETEEN"}
                };

                Dictionary<int, string> secondStage = new Dictionary<int, string>()
                {
                    {20, "TWENTY"}, {30, "THIRTY"}, {40, "FORTY"}, {50, "FIFTY"}, {60, "SIXTY"},
                    {70, "SEVENTY"}, {80, "EIGHTY"}, {90, "NINTY"}
                };
            }
        }

        private static void SecondLevelText() { } //input and return values not yet determined
    }
}
