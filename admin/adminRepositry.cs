using System.IO;
using AdminModel = SchoolManagementSystem.Models.Admin;

namespace school_management_sysytem.Admin
{
    public class AdminRepository
    {
        string filePath = "admin.txt";

        public AdminModel GetAdmin()
        {
            if (File.Exists(filePath))
            {
                StreamWriter writer = new StreamWriter(filePath);
                writer.WriteLine("admin123");
                writer.WriteLine("2456");
                
                writer.Close();
                
            }

            StreamReader reader = new StreamReader(filePath);

            AdminModel a = new AdminModel();
            a.Username = reader.ReadLine();
            a.Password = reader.ReadLine();
           

            reader.Close();

            return a;
        }
    }
}