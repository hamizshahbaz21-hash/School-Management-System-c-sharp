using System.Collections.Generic;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.StudentServices
{
    public class StudentService
    {
        StudentRepository repository = new StudentRepository();
        StudentBusiness business = new StudentBusiness();

        // ADD STUDENT
        public bool AddStudent(Student s)
        {
            List<Student> students = repository.GetAllStudents();

            if (students.Count >= 200)
                return false;

            if (!business.ValidateStudent(s))
                return false;

            foreach (Student oldStudent in students)
            {
                if (oldStudent.ID == s.ID &&
                    oldStudent.ClassNo == s.ClassNo)
                {
                    return false;
                }
            }

            business.CalculateResult(s);

            students.Add(s);

            repository.SaveAllStudents(students);

            return true;
        }

        // SHOW ALL STUDENTS
        public List<Student> GetAllStudents()
        {
            List<Student> students = repository.GetAllStudents();

            SortStudents(students);

            repository.SaveAllStudents(students);

            return students;
        }

        // SEARCH STUDENT
        public Student SearchStudent(int id, int classNo)
        {
            List<Student> students = repository.GetAllStudents();

            foreach (Student s in students)
            {
                if (s.ID == id && s.ClassNo == classNo)
                {
                    return s;
                }
            }

            return null;
        }

        // UPDATE STUDENT
        public bool UpdateStudent(int searchID, int searchClass, Student updatedStudent)
        {
            List<Student> students = repository.GetAllStudents();

            foreach (Student s in students)
            {
                if (s.ID == searchID && s.ClassNo == searchClass)
                {
                    if (!business.ValidateStudent(updatedStudent))
                        return false;

                    foreach (Student oldStudent in students)
                    {
                        if (oldStudent != s &&
                            oldStudent.ID == updatedStudent.ID &&
                            oldStudent.ClassNo == updatedStudent.ClassNo)
                        {
                            return false;
                        }
                    }

                    s.Name = updatedStudent.Name;
                    s.ClassNo = updatedStudent.ClassNo;

                    s.Math = updatedStudent.Math;
                    s.English = updatedStudent.English;
                    s.Computer = updatedStudent.Computer;

                    business.CalculateResult(s);

                    repository.SaveAllStudents(students);

                    return true;
                }
            }

            return false;
        }

        // DELETE STUDENT
        public bool DeleteStudent(int id, int classNo)
        {
            List<Student> students = repository.GetAllStudents();

            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].ID == id &&
                    students[i].ClassNo == classNo)
                {
                    students.RemoveAt(i);

                    repository.SaveAllStudents(students);

                    return true;
                }
            }

            return false;
        }

        // SHOW TOPPER
        public Student ShowTopper(int classNo)
        {
            if (classNo < 1 || classNo > 10)
                return null;

            List<Student> students = repository.GetAllStudents();

            Student topper = null;

            foreach (Student s in students)
            {
                if (s.ClassNo == classNo)
                {
                    if (topper == null ||
                        s.Percentage > topper.Percentage)
                    {
                        topper = s;
                    }
                }
            }

            return topper;
        }

        // SHOW FAILED STUDENTS
        public List<Student> ShowFailedStudents(int classNo)
        {
            List<Student> students = repository.GetAllStudents();

            List<Student> failedStudents = new List<Student>();

            if (classNo < 1 || classNo > 10)
                return failedStudents;

            foreach (Student s in students)
            {
                if (s.ClassNo == classNo && s.Grade == 'F')
                {
                    failedStudents.Add(s);
                }
            }

            return failedStudents;
        }

        // SORT STUDENTS BY CLASS
        public void SortStudents(List<Student> students)
        {
            for (int i = 0; i < students.Count - 1; i++)
            {
                for (int j = 0; j < students.Count - i - 1; j++)
                {
                    if (students[j].ClassNo > students[j + 1].ClassNo)
                    {
                        Student temp = students[j];

                        students[j] = students[j + 1];

                        students[j + 1] = temp;
                    }
                }
            }
        }
    }
}