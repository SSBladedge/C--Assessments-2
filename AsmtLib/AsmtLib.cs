
//ASK ISAAC ABOUT POSSIBLE GLOBAL SOLUTION

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

                string text = SecondLevelText(numArray);

                Console.WriteLine(text);
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

            while (numList.Count % 3 != 0)
                numList.Insert(0, 0);

            return numList.ToArray();
        }

        private static string FirstLevelText(int[] numArray)
        {
            string textValue = "";
            Dictionary<int, string> singleDigit = new Dictionary<int, string>()
            {
                {1, "ONE"}, {2, "TWO"}, {3, "THREE"}, {4, "FOUR"}, {5, "FIVE"},
                {6, "SIX"}, {7, "SEVEN"}, {8, "EIGHT"}, {9, "NINE"}
            };

            Dictionary<int, string> doubleDigit = new Dictionary<int, string>()
            {
                {1, "TEN"}, {2, "TWENTY"}, {3, "THIRTY"}, {4, "FORTY"}, {5, "FIFTY"},
                {6, "SIXTY"}, {7, "SEVENTY"}, {8, "EIGHTY"}, {9, "NINTY"}
            };

            Dictionary<int, string> exceptions = new Dictionary<int, string>()
            {
                {1, "ELEVEN"}, {2, "TWELVE"}, {3, "THIRTEEN"}, {4, "FOURTEEN"}, {5, "FIFTEEN"},
                {6, "SIXTEEN"}, {7, "SEVENTEEN"}, {8, "EIGHTEEN"}, {9, "NINETEEN"}
            };

            if (numArray[0] != 0)                                                   //NOTE: EMPTY SPACES ARE ASSUMED TO BE ZEROES
            {
                textValue = string.Concat(textValue, singleDigit[numArray[0]] + " HUNDRED");

                if (numArray[1] != 0 || numArray[2] != 0)
                {
                    textValue = string.Concat(textValue, " AND ");
                }

                else
                    return textValue;
            }

            if (numArray[1] == 1 && numArray[2] != 0)
            {
                textValue = string.Concat(textValue, exceptions[numArray[2]]);
                return textValue;
            }

            else if (numArray[1] != 0)
            {
                textValue = string.Concat(textValue, doubleDigit[numArray[1]]);

                if (numArray[2] == 0)
                    return textValue;
                else
                {
                    textValue = string.Concat(textValue, " " + singleDigit[numArray[2]]);
                    return textValue;
                }
            }

            else if (numArray[0] == 0 && numArray[1] == 0 && numArray[2] == 0)
            {
                return textValue;
            }

            else
            {
                textValue = string.Concat(textValue, singleDigit[numArray[2]]);
                return textValue;
            }
        }

        private static string SecondLevelText(int[] numArray)
        {
            string finalWord = "";
            string[] magnitudes = { "", " THOUSAND ", " MILLION ", " BILLION ", " TRILLION " };
            int j = (numArray.Length / 3) - 1;

            for (int i = 0; i < numArray.Length; i += 3)
            {
                int[] values = { numArray[i], numArray[i + 1], numArray[i + 2] };
                string words = FirstLevelText(values);


                string unit = magnitudes[j - (i / 3)];

                finalWord = string.Concat(finalWord, words + unit);
            }

            return finalWord;
        }


        // Write a program to Register students, and also retrieve the students data by their IDs.  Use text file as your database


        class Student
        {
            //class props
            private string _lastName;
            private string _firstName;
            private string _id;

            //constructor
            public Student(string lastName, string firstName, string id)
            {
                this._firstName = firstName;
                this._lastName = lastName;
                this._id = id;
            }


            //getters and setters 
            public string LastName
            {
                get { return _lastName; }
                set { _lastName = value; }
            }

            public string FirstName
            {
                get { return _firstName; }
                set { _firstName = value; }
            }

            public string ID
            {
                get { return _id; }
                set { _id = value; }
            }
        }

        public static void StudentRecords()
        {
            Console.WriteLine("Welcome to Student Records");
            Console.WriteLine("What would you like to engage in?");

            Console.WriteLine("1. View records of students");
            Console.WriteLine("2. Register a student");
            Console.WriteLine("3. Search for student using student ID");

            Student[] studentRecords = RetrieveData();

            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine($"There are {studentRecords.Length} students in record");
            Console.WriteLine("-----------------------------------------------");


            string? choice = Console.ReadLine();
            int intChoice;

            int.TryParse(choice, out intChoice);

            if (intChoice == 1)
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("-----------------------------------------------");
                for (int i = 0; i < studentRecords.Length; i++)
                {
                    Console.WriteLine($"First name: {studentRecords[i].FirstName}");
                    Console.WriteLine($"Last name: {studentRecords[i].LastName}");
                    Console.WriteLine($"Student ID: {studentRecords[i].ID}");
                    Console.WriteLine("-----------------------------------------------");
                    Console.WriteLine("-----------------------------------------------");
                }
                ReDo();
            }
            else if (intChoice == 2)
            {
                Console.WriteLine("Please give student last name:");
                string? lastName = Console.ReadLine();

                Console.WriteLine("Please give student first name:");
                string? firstName = Console.ReadLine();

                string id = GenerateFiveDigitNumber();

                Student newStudent = new Student(lastName!, firstName!, id);

                StoreData(newStudent);

                ReDo();
            }
            else if (intChoice == 3)
            {
                Console.WriteLine("Please input student ID:");

                int intInput;

                while (true)
                {
                    string? input = Console.ReadLine();
                    if (int.TryParse(input, out intInput))
                        break;
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Please provide valid numerical input");
                        continue;
                    }
                }

                string requestedID = intInput.ToString();
                bool found = false;

                for (int i = 0; i < studentRecords.Length; i++)
                {
                    if (studentRecords[i].ID == requestedID)
                    {
                        found = true;

                        Console.WriteLine("WE FOUND YOUR REQUESTED RECORD");
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine($"First name: {studentRecords[i].FirstName}");
                        Console.WriteLine($"Last name: {studentRecords[i].LastName}");
                        Console.WriteLine($"Student ID: {studentRecords[i].ID}");
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine("-----------------------------------------------");
                        break;
                    }
                    else
                        continue;
                }
                if (!found)
                    Console.WriteLine("NO RECORDS WERE FOUND");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please select 1, 2, or 3 from the options");
                Console.WriteLine("");
                StudentRecords();
            }
        }

        private static string GenerateFiveDigitNumber()
        {
            Random generator = new Random();
            string r = generator.Next(100000, 1000000).ToString();
            Console.WriteLine($"Student ID is {r}");
            return r;
        }

        private static void ReDo()
        {
            Console.WriteLine("would you like to go back to records? (Y/N)");
            string? choice = Console.ReadLine()!;
            string theChoice = choice.ToUpper();
            if (theChoice == "Y")
            {
                Console.Clear();
                StudentRecords();
            }

            else
            {
                Console.Clear();
                Console.WriteLine("Thank you for your time");
            }
        }

        private static Student[] RetrieveData()
        {
            List<Student> records = new List<Student>();

            string[] readText = File.ReadAllLines("../TextDocs/TextFile1.txt");

            foreach (string s in readText)
            {
                string[] data = s.Split(' ');
                Student student = new Student(data[2], data[1], data[0]);

                // Console.WriteLine("-----------------------------------------------");
                // Console.WriteLine($"{data[1]} {data[2]} has been retrieved. ID number {data[0]}");
                // Console.WriteLine("-----------------------------------------------");

                records.Add(student);
            }
            // Console.WriteLine("");
            // Console.WriteLine($"In the store function, there are {records.ToArray().Length} students in records");

            return records.ToArray();
        }

        private static void StoreData(Student record)
        {
            using (StreamWriter sw = File.AppendText("../TextDocs/TextFile1.txt"))
            {
                sw.WriteLine($"{record.ID} {record.FirstName} {record.LastName}");
            }
        }
    }
    //DOTNET 7 IS USED 
}



//Model - OOP 
//class ***
//.... 

//Controller - Methods 
//class : controllerbase 
//Database query

//Data - data 
// class : dboptions

//Migration - generated 



//Craete an API for a school (Divinity Highschool)
//API should register and manage students in a database 

// An api for a school.
// Divinity college
// Apis to register and manage students.
// The students records will be housed on a db
// There will be a table for student records. Things like firstname, lastname, dob,address, class assigned - grade 10 to 12, class teachers name.
// Api to get all students
// Api to get students by grade eg grade 10 to 12.
// Api to get an individual student
// Api to register students with the ppts
