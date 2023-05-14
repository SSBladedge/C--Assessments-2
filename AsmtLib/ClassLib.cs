


namespace AsmtLib
{
    public class Lib
    {
        public static void NumToTxt()
        {
            int num = GetInputNum();

            var numArray = GetNumList(num);

            foreach (int item in numArray)
            {
                Console.WriteLine(item);
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

        private static int[] GetNumList(int num)
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

        private static void FirstLevelTxt()
        {

        }

        private static void SecondLevelTxt() { } //input and return values not yet determined
    }
}
