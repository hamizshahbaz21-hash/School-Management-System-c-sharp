using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.StudentServices
{
    public class StudentBusiness
    {
        public bool ValidateStudent(Student s)
        {
            if (s.ID <= 0)
            {
                return false;
            }
            if (s.Name == "")
            {
                return false;
            }
            if (s.ClassNo < 1 || s.ClassNo > 10)
            {
                return false;
            }
            if (s.Math < 0 || s.Math > 100)
            {
                return false;
            }
            if (s.English < 0 || s.English > 100)
            {

                return false;
            }
            if (s.Computer < 0 || s.Computer > 100)
            {
                return false;
            }
            return true;
        }

        public void CalculateResult(Student s)
        {
            s.TotalMarks = s.Math + s.English + s.Computer;

            s.Percentage = s.TotalMarks / 3;

            if (s.Percentage >= 80)
                s.Grade = 'A';

            else if (s.Percentage >= 70)
                s.Grade = 'B';

            else if (s.Percentage >= 60)
                s.Grade = 'C';

            else if (s.Percentage >= 50)
                s.Grade = 'D';

            else
                s.Grade = 'F';
        }
    }
}