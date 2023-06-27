
using Newtonsoft.Json;
using System.IO;

namespace StudentsGrades
{
    public class Manager
    {
        private string pathCourse = @"C:\WildSchoul_Formation\Projcts\StudentsGradesold\JSON\course.json";
        private string studentPath = @"C:\WildSchoul_Formation\Projcts\StudentsGrades\JSON\student.json";
        private string gradePath = @"C:\WildSchoul_Formation\Projcts\StudentsGrades\JSON\Grade.json";
        public List<Course> lstCourse;
        public List<Student> lstStudent;
        public List<Grade> lstGrade;

        public Manager() 
        {
           Import();
        }
        public void Import()
        {
            using (var stremReader = new StreamReader(studentPath))
            {
                using (var jsonReader = new JsonTextReader(stremReader))
                {
                    JsonSerializer serializer = new JsonSerializer();
                     lstStudent = serializer.Deserialize<List<Student>>(jsonReader);
                   
                }

            }
            using (var stremReader = new StreamReader(pathCourse))
            {
                using (var jsonReader = new JsonTextReader(stremReader))
                {
                    JsonSerializer serializer = new JsonSerializer();
                     lstCourse = serializer.Deserialize<List<Course>>(jsonReader);
                    
                }

            }
            using (var stremReader = new StreamReader(gradePath))
            {
                using (var jsonReader = new JsonTextReader(stremReader))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    lstGrade = serializer.Deserialize<List<Grade>>(jsonReader);
                    
                }

            }

        }
        //public void Remove()
        //{
        //    StartOption("Removing a student:");

        //    if (!isSystemEmpty())
        //    {
        //        PrintAllObjects();

        //        Console.Write("Enter an index: ");
        //        int index = Convert.ToInt32(Console.ReadLine());
        //        index--;
        //        if (index >= 0 && index <= lstObject.Count - 1)
        //        {
        //            lstObject.RemoveAt(index);
        //            Console.WriteLine("Successfully removed a student.");

        //           // FinishOption();
        //        }
        //        else
        //        {
        //            OutputMessage("Enter a valid index inside the range.");
        //            Remove();
        //        }
        //    }
        //    else
        //    {
        //        OutputMessage("");
        //    }
        //}
        //public void Add(Entity objet)
        //{
        //    StartOption("Adding a student:");
        //    try
        //    {     
                
        //        if (objet != null )
        //        {
        //            lstGrades.Add(objet);
        //            Console.WriteLine("Successfully added a student.");
        //            FinishOption();
        //        }
        //        else
        //        {
        //            OutputMessage("Something has went wrong.");
        //            Add(objet);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        OutputMessage("Something has went wrong.");
        //        Add(objet);
        //    }
        //}
        //public void Edit(Entity objet)
        //{
        //    StartOption("Editing a student:");

        //    if (!isSystemEmpty())
        //    {
        //        PrintAllObjects();
        //        try
        //        {
        //            Console.Write("Enter an index: ");
        //            int indexSelection = Convert.ToInt32(Console.ReadLine());
        //            indexSelection--;

        //            if (indexSelection >= 0 && indexSelection <= lstObject.Count - 1)
        //            {
        //                try
        //                {
        //                    ///MagicObject objet = MagicObject.ReturnStudent();

        //                    if (objet != null)
        //                    {
        //                        lstObject[indexSelection] = objet;
        //                        Console.WriteLine("Successfully edited a student.");
        //                        FinishOption();
        //                    }
        //                    else
        //                    {
        //                        OutputMessage("Something has went wrong.");
        //                        Edit(objet);
        //                    }
        //                }
        //                catch (Exception)
        //                {
        //                    OutputMessage("Something has went wrong.");
        //                    Edit(objet);
        //                }
        //            }
        //            else
        //            {
        //                OutputMessage("Enter a valid index range.");
        //                Edit(objet);
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            OutputMessage("Something went wrong.");
        //            Edit(objet);
        //        }
        //    }
        //    else
        //    {
        //        OutputMessage("");
        //    }
        //}
        //public void PrintAll()
        //{
        //    StartOption("Printing all:");

        //    if (!isSystemEmpty())
        //    {
        //        PrintAllObjects();
        //    }

        //    FinishOption();

        //}
        //public void PrintAllObjects()
        //{
        //    int i = 0;
        //    lstObject.ForEach(MagicObject =>
        //    {
        //        i++;
        //        Console.WriteLine(i + ". " + MagicObject.ReturnDetails());
        //    });
        //}     

        //public bool isSystemEmpty() 
        //{
        //    if (lstObject.Count == 0)
        //    {
        //        Console.WriteLine("There are no student in the system.");
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        //public void StartOption(string message)
        //{
        //    Console.Clear();
        //    Console.WriteLine(message + Environment.NewLine);
        //}
        //public void FinishOption()
        //{
        //    Console.WriteLine(Environment.NewLine + "You have finished this option. Press <Enter> to return to the menu.");
        //    Console.ReadLine();
        //    Console.Clear();
        //}
        //public void OutputMessage(string message)
        //{
        //    if (message.Equals(String.Empty))
        //    {
        //        Console.WriteLine("Press <Enter> to return to the menu.");
        //    }
        //    else
        //    {
        //        Console.WriteLine(message + " Press <Enter> to try again.");
        //    }
        //}
    }
}
