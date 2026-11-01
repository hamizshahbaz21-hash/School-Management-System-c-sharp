using AdminModel = SchoolManagementSystem.Models.Admin;

namespace school_management_sysytem.Admin
{
    public class AdminService
    {
        AdminRepository repository = new AdminRepository();
        AdminBusiness business = new AdminBusiness();

        public bool LoginAdmin(AdminModel a)
        {
            if (!business.ValidateAdmin(a))
                return false;

            AdminModel savedAdmin = repository.GetAdmin();

            if (business.CheckLogin(savedAdmin, a))
                return true;

            return false;
        }
    }
}