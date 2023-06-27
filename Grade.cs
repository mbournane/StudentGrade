namespace StudentsGrades
{
    public class Grade
    { 
        public int Id { get; set; }
        public int IdStudent { get; set; }
        public int IdCourse { get; set; }
        public decimal Grades { get; set; }      
        public string AppreciationsStudent { get;  set; }

        public Grade(int id, int idStudent, int idCourse, decimal grades, string appreciationsStudent)
        {
            Id = id;
            IdStudent = idStudent;
            IdCourse = idCourse;
            Grades = grades;
            AppreciationsStudent = appreciationsStudent;
        }
    } 
}
