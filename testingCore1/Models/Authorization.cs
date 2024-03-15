using System.Reflection;

namespace testingCore1.Models
{
    public class AuthorizationAPIModel
    {
        #region EmpDtlsFetch
        public int? Costcenter_Key { get; set; }
        public int? Division_Key { get; set; }
        public int? WareHouse_Key { get; set; }
        public int? StaffType_Key { get; set; }
        public string? StaffType { get; set; }
        public int? Designation_Key { get; set; }
        public string? Designation { get; set; }
        public int? Department_Key { get; set; }
        public string? Department { get; set; }
        public int? JobType_Key { get; set; }
        public string? JobType { get; set; }
        public int? Category_Key { get; set; }
        public string? Category { get; set; }
        public int? Company_Key { get; set; }
        public string? Company_Name { get; set; }
        public int? ReportingHead_Key { get; set; }
        public string? EmailID { get; set; }
        #endregion

        #region Employee
        public int? EmployeeID { get; set; }
        public int? PersonnelKey { get; set; }
        public int? BusinessAdminProfileID { get; set; }
        public string? EmployeeName { get; set; }
        public string? EmployeeCostCenter { get; set; }
        public string? EmployeeDevision { get; set; }
        public string? EmployeeWareHouse { get; set; }
        public string? EmployeeReportingBoss { get; set; }
        public string? EmployeePassword { get; set; }
        public int? UserTypeId { get; set; }
        public string? UserType { get; set; }
        public string? BusinessUserPwd { get; set; }
        public string? Personnel_NAME { get; set; }
        public string? EmpName { get; set; }
        #endregion

        #region Company
        public int? CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public int? empCompanyId { get; set; }
        public string? empCompanyName { get; set; }

        public int? empCompanyId_lbl3 { get; set; }
        public string? empCompanyName_lbl3 { get; set; }

        public int? application_ID { get; set; }
        public string? applicationName { get; set; }

        public int? UserTypeId_lbl3 { get; set; }
        public string? UserType_lbl3 { get; set; }

        public List<string>? ModuleId { get; set; }
        public List<int>? ActionId { get; set; }
        #endregion
    }
    public class BusinessAdminProfileAccessMapDtls2
    {
        //public int? TenantId { get; set; }
        public int? EMPLOYEE_MASTER_KEY { get; set; }
        public int? BusinessAdminProfileID { get; set; }
        public int? CompanyId { get; set; }
        public int? UserTypeId { get; set; }
        //public int? HeadAccessId { get; set; }
        public int? ApplicationId { get; set; }
        public int? ModuleId { get; set; }
        public int? ActionId { get; set; }
        //public int? ActionValue { get; set; }
        public int? CreatedBy { get; set; }
        public int ActiveFlag { get; set; }
    }

    public class AuthorizationModelView
    {
        public int SERIAL_NO { get; set; }
        public int EMPLOYEE_MASTER_KEY { get; set; }
        public string Employee_Name { get; set; }
        public string REPORTING_HEAD { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string Comapny { get; set; }
        public string CostCenter { get; set; }
        public string Division { get; set; }
        public string WareHouse { get; set; }

    }
}
