using AsmtLib;


namespace AssessmentUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Welcome();
            UI();
        }

        private static void Welcome()
        {
            Console.WriteLine("Welcome to Assessment-2 of C#");
            Console.WriteLine("What is your name?");
            string? name = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("{0}, {1}", Greeting(), name);
        }

        private static string Greeting()
        {
            int hrOfDay = DateTime.Now.Hour;

            if (hrOfDay < 12)
                return "Good morning";
            else if (hrOfDay >= 12 && hrOfDay < 17)
                return "Good afternoon";
            else
                return "Good evening";
        }

        private static void UI()
        {
            string[] tasks = new string[2]
            {
                "Number to text",
                "Student Records"
            };

            Console.WriteLine("Please select from the available options below:");

            for (int i = 0; i < tasks.Length; i++)
            {
                int num = i + 1;
                Console.WriteLine("{0} - {1}", num, tasks[i]);
            }

            Console.WriteLine("What option will you choose?");
            string? choice = Console.ReadLine();


            if (choice == "1")
            {
                Console.Clear();
                Lib.NumToTxt();
                ReDo();
            }
            else if (choice == "2")
            {
                Console.Clear();
                Lib.StudentRecords();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please select 1, 2, or 3 from the options");
                Console.WriteLine("");
                ReDo();
            }
        }

        private static void ReDo()
        {
            Console.WriteLine("would you like to go again? (Y/N)");
            string? choice = Console.ReadLine()!;
            string theChoice = choice.ToUpper();
            if (theChoice == "Y")
            {
                Console.Clear();
                UI();
            }

            else
            {
                Console.Clear();
                Console.WriteLine("Thank you for your time");
            }
        }
    }
}



