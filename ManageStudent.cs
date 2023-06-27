using Newtonsoft.Json;

namespace StudentsGrades
{
    public class ManageStudent
    {
        public List<Student> lstStudent;
        private string studentPath = @"C:\WildSchoul_Formation\Projcts\StudentsGrades\JSON\student.json";
        
        public ManageStudent()
        {

            lstStudent = Import(studentPath);            
            PrintMenu();
        }

        public void PrintMenu()
        {
            StartOption("Menu of a student:");
            string[] menuOptions = new string[]
            {
                    "Print all Student",
                    "Add Student",
                    "Edit Student",
                    "Add Grade",
                    "Remove Student",
                    "Exit",
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
                    AddStudent();
                }
                else if (menuOption == 3)
                {
                    EditStudent();
                }
                else if (menuOption == 4)
                {
                    AddGrade();
                }
                else if (menuOption == 5)
                {
                    RemoveStudent();
                }
                else if (menuOption == 6)
                {
                    Export(lstStudent);
                }

                if (menuOption >= 1 && menuOption <= menuOptions.Length - 1)
                {
                    PrintMenu();                    
                }
            }
            else
            {
                OutputMessage("Incorrect menu choice."); //hi
                PrintMenu();
            }
        }

        private void AddGrade()
        {
            ManageGrade grade = new ManageGrade();
            grade.AddGrade();
        }

        public void EditStudent()
        {
            StartOption("Editing a student:");

            if (!isSystemEmpty())
            {
                PrintAllStudents();
                try
                {
                    Console.Write("Enter an index: ");
                    int indexSelection = Convert.ToInt32(Console.ReadLine());
                    indexSelection--;

                    if (indexSelection >= 0 && indexSelection <= lstStudent.Count - 1)
                    {
                        try
                        {
                            Student student = returnStudent();

                            if (student != null)
                            {
                                lstStudent[indexSelection] = student;
                                Console.WriteLine("Successfully edited a student.");
                                FinishOption();
                            }
                            else
                            {
                                OutputMessage("Something has went wrong.");
                                EditStudent();
                            }
                        }
                        catch (Exception)
                        {
                            OutputMessage("Something has went wrong.");
                            EditStudent();
                        }
                    }
                    else
                    {
                        OutputMessage("Enter a valid index range.");
                        EditStudent();
                    }
                }
                catch (Exception)
                {
                    OutputMessage("Something went wrong.");
                    EditStudent();
                }
            }
            else
            {
                OutputMessage("");
            }
        }

        public void RemoveStudent()
        {
            StartOption("Removing a student:");

            if (!isSystemEmpty())
            {
                PrintAllStudents();

                Console.Write("Enter an index: ");
                int index = Convert.ToInt32(Console.ReadLine());
                index--;
                if (index >= 0 && index <= lstStudent.Count - 1)
                {
                    Console.Write("do you want to delete:(y/n) ");
                    string input = Console.ReadLine();
                    if(input == "y")
                    {
                        lstStudent.RemoveAt(index);
                        Console.WriteLine("Successfully removed a student.");
                    }
                    

                    FinishOption();
                }
                else
                {
                    OutputMessage("Enter a valid index inside the range.");
                    RemoveStudent();
                }
            }
            else
            {
                OutputMessage("");
            }
        }
        public void PrintAll()
        {
            StartOption("Printing all students:");

            if (!isSystemEmpty())
            {
                PrintAllStudents();
            }

            FinishOption();

        }
        public bool isSystemEmpty()
        {
            if (lstStudent.Count == 0)
            {
                Console.WriteLine("There are no student in the system.");
                return true;
            }
            else
            {
                return false;
            }
        }
        public void PrintAllStudents()
        {
            int i = 0;
            lstStudent.ForEach(Student =>
            {
                i++;
                Console.WriteLine("index: "+i+"\n"+Student.ToString());
            });
        }

        public void SearchStudent()
        {
            StartOption("Searching students:");
            if (!isSystemEmpty())
            {
                Console.Write("Enter a lastName: ");
                string lastnameInput = Console.ReadLine();
                Console.Write("Enter a firstName: ");
                string firstnameInput = Console.ReadLine();
                bool bFound = false;

                if (!string.IsNullOrEmpty(lastnameInput) || !string.IsNullOrEmpty(firstnameInput))
                {
                    for (int i = 0; i < lstStudent.Count; i++)
                    {
                        if (lstStudent[i].LastName.ToLower().Contains(lastnameInput.ToLower()) || lstStudent[i].FirstName.ToLower().Contains(firstnameInput.ToLower()))
                        {
                            Console.WriteLine(lstStudent[i].ReturnDetails());
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
                    SearchStudent();
                }
            }
            else
            {
                OutputMessage("");
            }
        }
        public void AddStudent()
        {
            StartOption("Adding a student:");
            try
            {
                Student student = returnStudent();

                if (student != null)
                {
                    var lastItem = lstStudent.Last();
                    if (lastItem != null) { student.Id = lastItem.Id + 1; }                  
                    lstStudent.Add(student);
                    Console.WriteLine("Successfully added a student.");
                    FinishOption();
                }
                else
                {
                    OutputMessage("Something has went wrong.");
                    AddStudent();
                }
            }
            catch (Exception)
            {
                OutputMessage("Something has went wrong.");
                AddStudent();
            }
        }
       
        public Student returnStudent()
        {
            Console.Write("Enter a Lastname: ");
            string lastNameInput = Console.ReadLine();
            Console.Write("Enter a Firstname: ");
            string firstNameInput = Console.ReadLine();

            Console.Write("Enter age: ");
            int ageInput = Convert.ToInt32(Console.ReadLine());

            if (!string.IsNullOrEmpty(lastNameInput))
            {
                if (ageInput >= 0 && ageInput <= 150)
                {
                    return new Student(firstNameInput, lastNameInput, ageInput, 0);
                }
                else
                {
                    OutputMessage("Enter a sensible age.");
                }
            }
            else
            {
                OutputMessage("You didn't enter a name.");
            }

            return null;
        }

        private void OutputMessage(string message)
        {
            if (message.Equals(String.Empty))
            {
                Console.WriteLine("Press <Enter> to return to the menu.");
            }
            else
            {
                Console.WriteLine(message + " Press <Enter> to try again.");
            }
        }
        public void StartOption(string message)
        {
            Console.Clear();
            Console.WriteLine(message + Environment.NewLine);
        }
        public void FinishOption()
        {
            Console.WriteLine(Environment.NewLine + "You have finished this option. Press <Enter> to return to the menu.");
            Console.ReadLine();
            Console.Clear();
        }
        public void Export(List<Student> list)
        {            
            if (File.Exists(studentPath))
            {
                File.Delete(studentPath);
            }
            using (FileStream fs = File.Open(studentPath, FileMode.CreateNew))
            using (StreamWriter sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;

                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, list);
            }
           
        }

        public  List<Student> Import(string path)
        {
            using (var stremReader = new StreamReader(path))
            {
                using (var jsonReader = new JsonTextReader(stremReader))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    var liststudents = serializer.Deserialize<List<Student>>(jsonReader);
                    return liststudents;
                }
            }

        }
    }
}
