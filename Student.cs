using Newtonsoft.Json;
using System.Xml.Linq;

namespace StudentsGrades
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Student
    {
        [JsonProperty]
        public int Id { get; set; }
        [JsonProperty]
        public string FirstName{ get; set; }
        [JsonProperty]
        public string LastName { get; set; }
        //public DateTime BirthDate { get; set; }
        [JsonProperty]
        public int Age { get; set; }
        [JsonProperty]
        public List<Grade> GradeList { get; set; }
        [JsonProperty]
        public decimal Average { get; set; }

        public Student(string firstName, string lastName, int age, decimal average)
        {
            //Id = id;
            FirstName = firstName;
            LastName = lastName;
            this.Age = age;
            //Grade = grade;
            Average = average;
        }      

        public  string ReturnDetails()
        {
            //return name + " - " + age;
            return $"{FirstName} - {LastName}  Age: {Age}";
        }
        
        public override string ToString()
        {
            return  $"Id: {Id}\n"+
                    $"FirstName: {FirstName}\n" +
                    $"LastName: {LastName} \n" +
                    $"Age: {Age}\n" +
                    $"Average: {Average}\n";
        }

    }    
}
