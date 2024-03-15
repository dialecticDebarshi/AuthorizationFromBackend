using testingCore1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace testingCore1.Interface
{
    public interface IAuthModuleMaster
    {

        string CompanyList(int? EmpID);
        IEnumerable<AuthorizationAPIModel> GetEmployee(string Prefix);
        IEnumerable<AuthorizationAPIModel> GetEmployeeDetailsById(int? EmployeeID);

        int SaveLebelOne(AuthorizationAPIModel authmodel);
        int SaveCompanyList(AuthorizationAPIModel authmodel);
        int SaveEmpLogin(AuthorizationAPIModel authmodel);
        List<SelectListItem> GetUserType();
        string GetempCompany(AuthorizationAPIModel authmodel);
        string GetAllUserTypeList();
        string GetempUserTypeList(AuthorizationAPIModel authmodel);
        int SaveAccessMapDetls(AuthorizationAPIModel authmodel);

        int SaveAccessMapDetls_Modules(BusinessAdminProfileAccessMapDtls2 authmodel);
        int DELETEAccessMapDetls_Modules(int ID);
        IEnumerable<AuthorizationModelView> GetViewAuthorization();
        List<SelectListItem> FetchApplicationNames();
        string GetModuleAccess(int id);
        DataSet GetUserTypebyBusinessAdminProfile(AuthorizationAPIModel model);
         string GetempUserTypeListBusinessAdminProfile(AuthorizationAPIModel model);
        DataSet GetAllUserActions();
        string GetempUserActionList();

        string FetchAuthorizationByUserID(int UserID, int CompanyKey,int DesignationKey);

        public string GetActionID(int company, int designationId, int appID, int employee_Master_Key, int moduleID);


    }
}
