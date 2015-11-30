using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduleenum3
{
    public class Program
    {
        [Flags]
        enum Days
        {
            NoClasses = 0,
            Monday = 1,
            Tuesday = 2,
            Wednesday = 4,
            Thursday = 8,
            Friday = 16,
            Saturday = 32,
            Sunday = 64

        }

        public static void Main(string[] args)
        {

            Days student = Days.NoClasses;//  хранение расписания
            int checker = 9;
            int dayChecker = 0;
            bool checkResult;


            Console.WriteLine(" Let make the week schedule");
            Console.WriteLine();

            student = MakeSchedule();



            while (checker != 0)
            {
                Console.WriteLine();
                Console.WriteLine("Well done. Now you can:");
                Console.WriteLine("Input number of day from 1 to 7 to check schedule for a day");
                Console.WriteLine("Input 8 to see whole week schedule");
                Console.WriteLine("Input 0 to exit");
                checker = CheckInput(0, 8);
                Console.Clear();
                switch (checker)
                {
                    case 0:

                        break;

                    case 8:

                        Console.WriteLine("Classes will be on the following days: {0}", student);
                        break;

                    default:

                        dayChecker = 1 << checker - 1;

                        checkResult = checkResult = student.HasFlag((Days)dayChecker);

                        Console.WriteLine("On {0} {1} classes", (Days)dayChecker, checkResult == true ? "will be" : "will not be");

                        break;
                }
            }


        }

        // метод ввода и записи расписания

        private static Days MakeSchedule()

        {
            string schedule = "";
            string[] schedule1;
            Days student2 = Days.NoClasses;
            bool checkFormat = false;



            Console.WriteLine(" Input number of days when there are classes");
            Console.WriteLine(" (Number of days starting from 1 for Monday to 7 for Sunday");
            Console.WriteLine(" Each number shall be separeted by coma");
            Console.WriteLine(" For example: 1,5,7 means that the classes will be on Monday, Friday and Sunday)");


            do
            {
                schedule = Console.ReadLine().Trim(',');

                schedule1 = schedule.Split(',');

                checkFormat = CheckStrInput(schedule1);
                if (!checkFormat)
                {
                    Console.WriteLine("Invalid input. Try Again");
                }

            }
            while (!checkFormat);

            foreach (string s in schedule1)
            {
                int s2 = 0;
                s2 = 1 << Convert.ToInt32(s) - 1;
                student2 = student2 | (Days)s2;

            }
            Console.Clear();
            return student2;
        }


        // метод ввода числовых данных с проверкой
        private static int CheckInput(int s, int f)
        {
            bool result = false;
            int input = 0;

            do
            {

                result = Int32.TryParse(Console.ReadLine(), out input);
                if (!result | input > f | input < s)
                {
                    Console.WriteLine("Invalid input. Try Again!");
                }
            }
            while (!result | input > f | input < s);

            return input;
        }


        // метод проверки формата ввода расписания
        private static bool CheckStrInput(string[] str)
        {
            List<string> checkList = new List<string>() { "1", "2", "3", "4", "5", "6", "7" };

            foreach (string s in str)
            {
                if (!checkList.Contains(s))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
