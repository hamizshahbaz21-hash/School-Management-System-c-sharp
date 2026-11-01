namespace SchoolManagementSystem.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int ClassNo { get; set; }

        public int Math { get; set; }
        public int English { get; set; }
        public int Computer { get; set; }

        public int TotalMarks { get; set; }
        public int Percentage { get; set; }

        public char Grade { get; set; }

        public Student()
        {
            Name = "";
            Grade = 'F';
        }
    }
}