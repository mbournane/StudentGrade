namespace StudentsGrades
{
    public class Course
    {
        public Course(string nameInput)
        {
            CourseName = nameInput;
        }

        public int Id { get; set; }
        public string CourseName { get; set; }

        public  string ReturnDetails()
        {
            return $"{CourseName}";
        }

        public override string ToString()
        {
            return $"Id: {Id}\n" +
                   $"FirstName: {CourseName}\n";
        }
    }
}
