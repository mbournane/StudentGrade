
using Newtonsoft.Json;
using System;

namespace StudentsGrades
{
    public class ManageCourse
    {
        public List<Course> lstCourse;
        private string coursePath = @"C:\WildSchoul_Formation\Projcts\StudentsGrades\JSON\course.json";
        public ManageCourse() 
        {
            lstCourse = Import(coursePath);
            PrintMenu();
        }

        public void PrintMenu()
        {
            StartOption("Menu of a course:");
            string[] menuOptions = new string[]
            {
                    "Print all Course",
                    "Add Course",
                    "Edit Course",
                    "Search Course",
                    "Remove Course",
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
                    PrintAll();
                }
                else if (menuOption == 2)
                {
                    AddCourse();
                }
                else if (menuOption == 3)
                {
                    EditCourse();
                }
                else if (menuOption == 4)
                {
                    SearchCourse();
                }
                else if (menuOption == 5)
                {
                    RemoveCourse();
                }
                else if (menuOption == 6)
                {
                    Export(lstCourse);
                }

                if (menuOption >= 1 && menuOption <= menuOptions.Length - 1)
                {
                    PrintMenu();
                }
            }
            else
            {
                OutputMessage("Incorrect menu choice."); 
                PrintMenu();
            }
        }

        private void RemoveCourse()
        {
            StartOption("Removing a course:");

            if (!isSystemEmpty())
            {
                PrintAllCourses();

                Console.Write("Enter an index: ");
                int index = Convert.ToInt32(Console.ReadLine());
                index--;

                if (index >= 0 && index <= lstCourse.Count - 1)
                {
                    Console.Write("do you want to delete:(y/n) ");
                    string input = Console.ReadLine();
                    if (input == "y")
                    { 
                        lstCourse.RemoveAt(index);
                        Console.WriteLine("Successfully removed a course.");
                    }                      

                    FinishOption();
                }
                else
                {
                    OutputMessage("Enter a valid index inside the range.");
                    RemoveCourse();
                }
            }
            else
            {
                OutputMessage("");
            }
        }

        private void SearchCourse()
        {
            StartOption("Searching courses:");

            //check if people in system
            //get name input
            //validate name
            //loop and check for name
            //output results
            //return back to menu

            if (!isSystemEmpty())
            {
                Console.Write("Enter a Name: ");
                string nameInput = Console.ReadLine();

                bool bFound = false;

                if (!string.IsNullOrEmpty(nameInput)) // "" null
                {
                    for (int i = 0; i < lstCourse.Count; i++)
                    {
                        if (lstCourse[i].CourseName.ToLower().Contains(nameInput.ToLower())) //Aba aba
                        {
                            Console.WriteLine(lstCourse[i].ReturnDetails());
                            bFound = true;
                        }
                    }

                    if (!bFound)
                    {
                        Console.WriteLine("No users found with that name.");
                    }

                    FinishOption();
                }
                else
                {
                    OutputMessage("Please enter a name.");
                    SearchCourse();
                }
            }
            else
            {
                OutputMessage("");
            }
        }

        private void EditCourse()
        {
            StartOption("Editing a course:");
            if(!isSystemEmpty())
            {
                PrintAllCourses();
                try
                {
                    Console.WriteLine("Entrer un index: ");
                    int indexSelection = Convert.ToInt32(Console.ReadLine());
                    indexSelection--;
                    if (indexSelection >= 0 && indexSelection <= lstCourse.Count - 1)
                    {
                        try
                        {
                            Course course = ReturnCourse();

                            if (course != null)
                            {
                                lstCourse[indexSelection] = course;
                                Console.WriteLine("Successfully edited a course.");
                                FinishOption();
                            }
                            else
                            {
                                OutputMessage("Something has went wrong.");
                                EditCourse();
                            }
                        }
                        catch (Exception)
                        {
                            OutputMessage("Something has went wrong.");
                            EditCourse();
                        }
                    }
                    else
                    {
                        OutputMessage("Enter a valid index range.");
                        EditCourse();
                    }

                }
                catch
                {

                    OutputMessage("Something went wrong.");
                    EditCourse();
                }

            }
            else
            {
                OutputMessage("");
            }
        }

        private void AddCourse()        
        {
            StartOption("Adding a course:");
            try
            {
                Course course = ReturnCourse();

                if (course != null)
                {
                    var lastItem = lstCourse.Last();
                    if (lastItem != null) { course.Id =  lastItem.Id + 1; }
                    lstCourse.Add(course);
                    Console.WriteLine("Successfully added a course.");
                    FinishOption();
                }
                else
                {
                    OutputMessage("Something has went wrong.");
                    AddCourse();
                }
            }
            catch (Exception)
            {
                OutputMessage("Something has went wrong.");
                AddCourse();
            }
        }

        private Course ReturnCourse()
        {
            Console.Write("Enter a name of course: ");
            string nameInput = Console.ReadLine();             

            if (!string.IsNullOrEmpty(nameInput)) //"a"
            {
              
                
                    return new Course(nameInput);               
             
            }
            else
            {
                OutputMessage("You didn't enter a name.");
            }

            return null;
        }

        private void PrintAll()
        {
            StartOption("Printing all courses:");

            if (!isSystemEmpty())
            {
                PrintAllCourses();
            }

            FinishOption();
        }

        private void FinishOption()
        {
            Console.WriteLine(Environment.NewLine + "You have finished this option. Press <Enter> to return to the menu.");
            Console.ReadLine();
            Console.Clear();
        }
    

        public void PrintAllCourses()
        {
            for (int i = 0; i < lstCourse.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + lstCourse[i].ReturnDetails());
            }
        }

        private bool isSystemEmpty()
        {
            if (lstCourse.Count == 0)
            {
                Console.WriteLine("There are no users in the system.");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void StartOption(string message)
        {
            Console.Clear();
            Console.WriteLine(message + Environment.NewLine);
        }

        private void OutputMessage(string message)
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
        public void Export(List<Course> list)
        {
            //string path = @"C:\WildSchoul_Formation\Projcts\StudentsGrades\JSON\course.json";
            if (File.Exists(coursePath))
            {
                File.Delete(coursePath);
            }
            using (FileStream fs = File.Open(coursePath, FileMode.CreateNew))
            using (StreamWriter sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;

                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, list);
            }

        }

        public List<Course> Import(string path)
        {
            using (var stremReader = new StreamReader(path))
            {
                using (var jsonReader = new JsonTextReader(stremReader))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    var list = serializer.Deserialize<List<Course>>(jsonReader);
                    return list;
                }
            }

        }
    }
}
