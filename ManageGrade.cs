

using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace StudentsGrades
{
    public class ManageGrade :Manager
    {
        public List<Grade> lstGrades;
        private string gradePath = @"C:\WildSchoul_Formation\Projcts\StudentsGrades\JSON\Grade.json";
        public ManageGrade() {
            lstGrades = Import(gradePath);
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
                    AddGrade();
                }
               
                else if (menuOption == 3)
                {
                    Export(lstGrade);
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

        private void PrintAll()
        {
            throw new NotImplementedException();
        }

        public void AddGrade()
        {
            StartOption("Add a grade:");
            try
            {
                Grade grade = returnGrade();

                if (grade != null)
                {
                    var lastItem = lstGrades.Last();
                    if (lastItem != null) { grade.Id = lastItem.Id + 1; }
                    lstGrade.Add(grade);
                    Console.WriteLine("Successfully added a grade.");                    
                    FinishOption();
                }
                else
                {
                    OutputMessage("Something has went wrong.");
                    AddGrade();
                }
            }
            catch (Exception)
            {
                OutputMessage("Something has went wrong.");
                AddGrade();
            }
        }
        public void Export(List<Grade> list)
        {
            //string path = @"C:\WildSchoul_Formation\Projcts\StudentsGrades\JSON\course.json";
            if (File.Exists(gradePath))
            {
                File.Delete(gradePath);
            }
            using (FileStream fs = File.Open(gradePath, FileMode.CreateNew))
            using (StreamWriter sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;

                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, list);
            }

        }
        public void FinishOption()
        {
            Console.WriteLine(Environment.NewLine + "You have finished this option. Press <Enter> to return to the menu.");
            Console.ReadLine();
            Console.Clear();
        }       

        public void StartOption(string message)
        {
            Console.Clear();
            Console.WriteLine(message + Environment.NewLine);
        }
        public Grade returnGrade()
        {
            int i = 0;
            lstStudent.ForEach(Student =>
            {
                i++;
                Console.WriteLine("index: " + i + "\n" + Student.ToString());
            });
            Console.Write("Chose a student: ");
            int index = Convert.ToInt32(Console.ReadLine());
            index--;
            int idStudent = lstStudent[index].Id;
            

            for (int j = 0; j < lstCourse.Count; j++)
            {
                Console.WriteLine(j + 1 + ". " + lstCourse[j].ReturnDetails());
            }
            Console.Write("Chose a course: ");

            int indexSelection = Convert.ToInt32(Console.ReadLine());
            indexSelection--;
            int idcourse = lstCourse[indexSelection].Id;
            string nameCourse = lstCourse[indexSelection].CourseName;

            Console.Write("Entre a Grade: ");
            decimal grade = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Entre an appreciation: ");
            string apprecition = Console.ReadLine();


            if (grade >= 0 && grade <= 20)
            {
                return new Grade(0, idStudent, idcourse, grade, apprecition);
            }
            else
            {
                OutputMessage("Enter a sensible grade.");
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
        private List<Grade> Import(string gradePath)
        {
            using (var stremReader = new StreamReader(gradePath))
            {
                using (var jsonReader = new JsonTextReader(stremReader))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    var list = serializer.Deserialize<List<Grade>>(jsonReader);
                    return list;
                }
            }
        }
    }
}
