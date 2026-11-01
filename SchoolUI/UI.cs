using System;
using System.Collections.Generic;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.StudentServices;
using school_management_sysytem.Admin;
using AdminModel = SchoolManagementSystem.Models.Admin;

namespace school_management_sysytem.UI
{
    public class MainUI
    {
        AdminService adminService = new AdminService();
        StudentService studentService = new StudentService();
        public void Start()
        {
            int menu = 0;
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n====================================");
                Console.WriteLine("       SCHOOL MANAGEMENT SYSTEM");
                Console.WriteLine("====================================");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1. Admin Menu");
                Console.WriteLine("2. Student Menu");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("3. Exit");
                Console.ResetColor();
                Console.WriteLine("====================================");

                Console.Write("Enter Choice: ");
                menu = int.Parse(Console.ReadLine());

                if (menu == 1)
                {
                    AdminLogin();
                }
                else if (menu == 2)
                {
                    StudentResult();
                }
                else if (menu == 3)
                {
                    Console.WriteLine("Have a nice day!!");
                }
                else
                {
                    Console.WriteLine("Invalid Choice!");
                }

            } while (menu != 3);
        }

        
        void AdminLogin()
        {
            AdminModel a = new AdminModel();

           
            Console.WriteLine("Enter Admin username");
            a.Username = Console.ReadLine();
            Console.Write("Enter Admin Password: ");
            a.Password = Console.ReadLine();

            if (adminService.LoginAdmin(a))
            {
                Console.WriteLine("Admin Login Successful!");
                AdminMenu();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong Password!");
                Console.WriteLine("Try Again!");
                Console.ResetColor();
            }
        }
        void AdminMenu()
        {
            int choice = 0;
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n====================================");
                Console.WriteLine("           ADMIN MENU");
                Console.WriteLine("====================================");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Show All Students");
                Console.WriteLine("3. Search Student");
                Console.WriteLine("4. Update Student");
                Console.WriteLine("5. Delete Student");
                Console.WriteLine("6. Show Topper");
                Console.WriteLine("7. Show Failed Students");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("8. Sign Out");
                Console.ResetColor();
                Console.WriteLine("====================================");

                Console.Write("Enter Choice: ");
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                    AddStudent();

                else if (choice == 2)
                    ShowStudents();

                else if (choice == 3)
                    SearchStudent();

                else if (choice == 4)
                    UpdateStudent();

                else if (choice == 5)
                    DeleteStudent();

                else if (choice == 6)
                    ShowTopper();

                else if (choice == 7)
                    ShowFailedStudents();

                else if (choice == 8)
                    Console.WriteLine("Admin Signed Out!");

                else
                    Console.WriteLine("Invalid Choice!");

            } while (choice != 8);
        }
        void AddStudent()
        {
            Student s = new Student();
            Console.Write("\nEnter Student ID: ");
            s.ID = int.Parse(Console.ReadLine());
            Console.Write("Enter Class (1-10): ");
            s.ClassNo = int.Parse(Console.ReadLine());
            Console.Write("Enter Student Name: ");
            s.Name = Console.ReadLine();
            Console.Write("Enter Math Marks: ");
            s.Math = int.Parse(Console.ReadLine());
            Console.Write("Enter English Marks: ");
            s.English = int.Parse(Console.ReadLine());
            Console.Write("Enter Computer Marks: ");
            s.Computer = int.Parse(Console.ReadLine());
            if (studentService.AddStudent(s))
                Console.WriteLine("Student Added Successfully!");
            else
                Console.WriteLine("Student Not Added! Check Details or Student Limit.");
        }
       
        void ShowStudents()
        {
            List<Student> students = studentService.GetAllStudents();
            if (students.Count == 0)
            {
                Console.WriteLine("No Students Found!");
                return;
            }
            Console.WriteLine("\n================ ALL STUDENTS ================");
            foreach (Student s in students)
            {
                ShowDetails(s);
            }
        }
        void SearchStudent()
        {
            Console.Write("\nEnter Student ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Student Class: ");
            int classNo = int.Parse(Console.ReadLine());
            Student s = studentService.SearchStudent(id, classNo);
            if (s != null)
                ShowDetails(s);
            else
                Console.WriteLine("Student Not Found!");
        }
        void UpdateStudent()
        {
            Console.Write("\nEnter Student ID to Update: ");
            int searchID = int.Parse(Console.ReadLine());
            Console.Write("Enter Student Class: ");
            int searchClass = int.Parse(Console.ReadLine());
            Student s = new Student();
            s.ID = searchID;
            Console.Write("Enter New Name: ");
            s.Name = Console.ReadLine();
            Console.Write("Enter New Class: ");
            s.ClassNo = int.Parse(Console.ReadLine());
            Console.Write("Enter New Math Marks: ");
            s.Math = int.Parse(Console.ReadLine());
            Console.Write("Enter New English Marks: ");
            s.English = int.Parse(Console.ReadLine());
            Console.Write("Enter New Computer Marks: ");
            s.Computer = int.Parse(Console.ReadLine());

            if (studentService.UpdateStudent(searchID, searchClass, s))
                {
                Console.WriteLine("Student Updated Successfully!");
            }
            else
            {

                Console.WriteLine("Student Not Updated!");
            }
        }
        void DeleteStudent()
        {
            Console.Write("\nEnter Student ID to Delete: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Student Class: ");
            int classNo = int.Parse(Console.ReadLine());
            if (studentService.DeleteStudent(id, classNo))
            {
                Console.WriteLine("Student Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("Student Not Found!");
            }
        }
        void ShowTopper()
        {
            Console.Write("\nEnter Class (1-10): ");
            int classNo = int.Parse(Console.ReadLine());
            if (classNo < 1 || classNo > 10)
            {
                Console.WriteLine("Invalid Class!");
                return;
            }
            Student topper = studentService.ShowTopper(classNo);
            if (topper == null)
            {
                Console.WriteLine("No Students Found in This Class!");
                return;
            }
            Console.WriteLine("\n========== CLASS " + classNo + " TOPPER ==========");
            ShowDetails(topper);
        }
        void ShowFailedStudents()
        {
            Console.Write("\nEnter Class (1-10): ");
            int classNo = int.Parse(Console.ReadLine());
            if (classNo < 1 || classNo > 10)
            {
                Console.WriteLine("Invalid Class!");
                return;
            }
            List<Student> failedStudents =
                studentService.ShowFailedStudents(classNo);
            Console.WriteLine("\n======= FAILED STUDENTS =======");
            if (failedStudents.Count == 0)
            {
                Console.WriteLine("No Failed Students in Class " + classNo);
                return;
            }
            foreach (Student s in failedStudents)
            {
                ShowDetails(s);
            }
        }
        void StudentResult()
        {
            List<Student> students = studentService.GetAllStudents();
            if (students.Count == 0)
            {
                Console.WriteLine("No Student Record Available!");
                return;
            }
            Console.Write("\nEnter Your Student ID: ");
            int searchID = int.Parse(Console.ReadLine());
            Console.Write("Enter Your Class: ");
            int searchClass = int.Parse(Console.ReadLine());
            Student s = studentService.SearchStudent(searchID, searchClass);
            if (s != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n========== YOUR RESULT ==========");
                Console.WriteLine("ID: " + s.ID);
                Console.WriteLine("Name: " + s.Name);
                Console.WriteLine("Class: " + s.ClassNo);
                Console.WriteLine("Total Marks: " + s.TotalMarks);
                Console.WriteLine("Percentage: " + s.Percentage + "%");
                Console.WriteLine("Grade: " + s.Grade);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Invalid Student ID or Class!");
            }
        }
        void ShowDetails(Student s)
        {
            Console.WriteLine("\n--------------------------------");
            Console.WriteLine("ID: " + s.ID);
            Console.WriteLine("Name: " + s.Name);
            Console.WriteLine("Class: " + s.ClassNo);
            Console.WriteLine("Math: " + s.Math);
            Console.WriteLine("English: " + s.English);
            Console.WriteLine("Computer: " + s.Computer);
            Console.WriteLine("Total: " + s.TotalMarks);
            Console.WriteLine("Percentage: " + s.Percentage + "%");
            Console.WriteLine("Grade: " + s.Grade);
            Console.WriteLine("--------------------------------");
        }
    }

}