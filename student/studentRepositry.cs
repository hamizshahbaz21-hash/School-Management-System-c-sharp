using System.Collections.Generic;
using System.IO;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.StudentServices
{
    public class StudentRepository
    {
        string filePath = "students.txt";

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            if (File.Exists(filePath))
            {
                StreamReader reader = new StreamReader(filePath);

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    string[] data = line.Split(',');

                    Student s = new Student();

                    s.ID = int.Parse(data[0]);
                    s.Name = data[1];
                    s.ClassNo = int.Parse(data[2]);

                    s.Math = int.Parse(data[3]);
                    s.English = int.Parse(data[4]);
                    s.Computer = int.Parse(data[5]);

                    s.TotalMarks = int.Parse(data[6]);
                    s.Percentage = int.Parse(data[7]);
                    s.Grade = char.Parse(data[8]);

                    students.Add(s);
                }

                reader.Close();
            }

            return students;
        }

        public void SaveAllStudents(List<Student> students)
        {
            StreamWriter writer = new StreamWriter(filePath);

            foreach (Student s in students)
            {
                writer.WriteLine(s.ID + "," +s.Name + "," +s.ClassNo + "," +s.Math + "," +s.English + "," +s.Computer + "," +s.TotalMarks + "," +s.Percentage + "," +s.Grade);
            }

            writer.Close();
        }
    }
}