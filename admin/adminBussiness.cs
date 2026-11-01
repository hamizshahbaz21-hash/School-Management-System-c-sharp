using AdminModel = SchoolManagementSystem.Models.Admin;

namespace school_management_sysytem.Admin
{
    public class AdminBusiness
    {
        public bool ValidateAdmin(AdminModel a)
        {
            if (a.Password == "")
                return false;

            return true;
        }

        public bool CheckLogin(AdminModel savedAdmin, AdminModel enteredAdmin)
        {
            if (savedAdmin.Password == enteredAdmin.Password)
                return true;

            return false;
        }
    }
}