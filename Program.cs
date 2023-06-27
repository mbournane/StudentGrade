using Newtonsoft.Json;
using System;
using System.Reflection.Metadata;

namespace StudentsGrades
{
    class Program
    {
        static string jsonString;        
        static List<Student> students;
        static void Main(string[] args)
        {
            PrintPrincipalMenu();
            Console.WriteLine("Goodbye!");

            Console.ReadLine();
        }

        public static void PrintPrincipalMenu()
        {
            Console.Clear();
            string[] menuOptions = new string[]
            {
                    "Students",
                    "Courses",
                    "Exit"
            };

            Console.WriteLine("Welcome to my management system!" + Environment.NewLine);

            for (int i = 0; i < menuOptions.Length; i++)
            {
                Console.WriteLine(i + 1 + ". " + menuOptions[i]);
            }

            Console.Write("Enter your menu option: ");

            bool tryParse = int.TryParse(Console.ReadLine(), out int menuOption);

            if (tryParse)
            {
                if (menuOption == 1)
                {
                    new ManageStudent();                   
                    
                }
                else if (menuOption == 2)
                {
                    new ManageCourse();
                }              

                if (menuOption >= 1 && menuOption <= menuOptions.Length - 1)
                {
                    PrintPrincipalMenu();
                }
            }
            else
            {
                OutputMessage("Incorrect menu choice."); //hi
                PrintPrincipalMenu();
            }
        }
        public static void OutputMessage(string message)
        {
            if (message.Equals(string.Empty)) //message == "", message == string.Empty
            {
                Console.Write("Press <Enter> to return to the menu.");
            }
            else
            {
                Console.WriteLine(message + " Press <Enter> to try again.");
            }
            Console.ReadLine();
            Console.Clear();      
                    
        }

        
        
       

    }
}