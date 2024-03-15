using testingCore1.DAL;
using testingCore1.Interface;
using testingCore1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Data;
using System.Reflection.Metadata;

namespace testingCore1.Repositoris
{
    public class AuthModuleMasterRepo : IAuthModuleMaster
    {
        private readonly IConfiguration _configuration;
        private readonly DbAccess _dbAccess;
        public AuthModuleMasterRepo(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbAccess = new DbAccess(_configuration);

        }

        public IEnumerable<AuthorizationModelView> GetViewAuthorization()
        {
            try
            {
                string[] parameterNames = { };
                string[] parameterValues = { };
                DataSet dataSet = _dbAccess.Ds_Process("SP_GET_ALL_AUTHORIZATION", parameterNames, parameterValues);


                List<AuthorizationModelView> lst = new List<AuthorizationModelView>();

                if (dataSet.Tables.Count > 0)
                {
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        var mdl = new AuthorizationModelView();
                        mdl.SERIAL_NO = Convert.ToInt32(row["SerialNo"]);
                        mdl.EMPLOYEE_MASTER_KEY = Convert.ToInt32(row["EMPLOYEE_MASTER_KEY"]);
                        mdl.Employee_Name = row["Employee_Name"].ToString();
                        mdl.REPORTING_HEAD = Convert.ToString(row["REPORTING_HEAD"]);
                        mdl.Department = Convert.ToString(row["Department_Desc"]);
                        mdl.Designation = Convert.ToString(row["DesignationName"]);
                        mdl.Comapny = Convert.ToString(row["COMPANY_NAME"]);
                        mdl.CostCenter = Convert.ToString(row["COSTCENTER_NAME"]);
                        mdl.Division = Convert.ToString(row["DIVISION_NAME"]);
                        mdl.WareHouse = Convert.ToString(row["WAREHOUSE_NAME"]);
                        lst.Add(mdl);
                    }
                }
                return lst;
            }
            catch
            {
                throw;
            }
        }
        public IEnumerable<AuthorizationAPIModel> GetEmployee(String Prefix)
        {
            try
            {
                DataSet dataSet = GetSingleEmployee(Prefix);
                List<AuthorizationAPIModel> lst = new List<AuthorizationAPIModel>();
                if (dataSet != null)
                {
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        var info = new AuthorizationAPIModel();
                        info.EmployeeID = Convert.ToInt32(row["EMPLOYEE_MASTER_KEY"]);
                        info.Costcenter_Key = Convert.ToInt32(row["COSTCENTER_KEY"]);
                        info.Division_Key = Convert.ToInt32(row["DIVISION_KEY"]);
                        info.WareHouse_Key = Convert.ToInt32(row["WAREHOUSE_KEY"]);
                        info.EmployeeName = row["Employee_Name"].ToString();
                        info.EmployeeCostCenter = row["COSTCENTER_NAME"].ToString();
                        info.EmployeeDevision = row["DIVISION_NAME"].ToString();
                        info.EmployeeWareHouse = row["WAREHOUSE_NAME"].ToString();
                        info.Category = row["CATEGORY_DESC"].ToString();
                        info.Category_Key = Convert.ToInt32(row["MAST_CATEGORY_KEY"]);
                        info.Designation = row["DesignationName"].ToString();
                        info.Designation_Key = Convert.ToInt32(row["DesignationId"]);
                        info.Department = row["Department_Desc"].ToString();
                        info.Department_Key = Convert.ToInt32(row["DepartmentId"]);
                        info.StaffType = row["StaffType_Desc"].ToString();
                        info.StaffType_Key = Convert.ToInt32(row["StaffTypeId"]);
                        info.JobType = row["JOBTYPE_DESCRIPTION"].ToString();
                        info.JobType_Key = Convert.ToInt32(row["MAST_HRD_JOBTYPE_KEY"]);
                        info.Company_Key = Convert.ToInt32(row["CompanyId"]);
                        info.Company_Name = row["COMPANY_NAME"].ToString();
                        info.ReportingHead_Key = Convert.ToInt32(row["reporting_Boss_key"]);
                        info.EmailID = row["Email_ID"].ToString();
                        info.PersonnelKey = Convert.ToInt32(row["MAST_HRD_DRAFT_PERSONNEL_KEY"]);
                        info.EmployeeReportingBoss = row["REPORTING_HEAD"].ToString();
                        info.Personnel_NAME = row["PERSONNEL_NAME"].ToString();
                        info.BusinessUserPwd = row["BusinessUserPwd"].ToString();
                        //info.Personnel_Id = row["PERSONNEL_ID"].ToString();       


                        lst.Add(info);
                    }

                }
                return lst;
            }
            catch
            {
                throw;
            }
        }
        public DataSet GetSingleEmployee(string Name)
        {
            try
            {
                string[] parameterNames = { "@Prefix" };
                string[] parameterValues = { Name };
                return _dbAccess.Ds_Process("[SP_FETCH_EMPLOYEE_AUTHORIZATION]", parameterNames, parameterValues);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<AuthorizationAPIModel> GetEmployeeDetailsById(int? EmployeeID)
        {
            try
            {
                DataSet dataSet = GetEmployeeById(EmployeeID);
                List<AuthorizationAPIModel> lst = new List<AuthorizationAPIModel>();
                if (dataSet != null)
                {
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        var info = new AuthorizationAPIModel();
                        
                        info.EmployeeID = Convert.ToInt32(row["EMPLOYEE_MASTER_KEY"]);
                        info.Costcenter_Key = Convert.ToInt32(row["COSTCENTER_KEY"]);
                        info.Division_Key = Convert.ToInt32(row["DIVISION_KEY"]);
                        info.WareHouse_Key = Convert.ToInt32(row["WAREHOUSE_KEY"]);
                        info.EmployeeName = row["Employee_Name"].ToString();
                        info.EmployeeCostCenter = row["COSTCENTER_NAME"].ToString();
                        info.EmployeeDevision = row["DIVISION_NAME"].ToString();
                        info.EmployeeWareHouse = row["WAREHOUSE_NAME"].ToString();
                        info.Category = row["CATEGORY_DESC"].ToString();
                        info.Category_Key = Convert.ToInt32(row["MAST_CATEGORY_KEY"]);
                        info.Designation = row["DesignationName"].ToString();
                        info.Designation_Key = Convert.ToInt32(row["DesignationId"]);
                        info.Department = row["Department_Desc"].ToString();
                        info.Department_Key = Convert.ToInt32(row["DepartmentId"]);
                        info.StaffType = row["StaffType_Desc"].ToString();
                        info.StaffType_Key = Convert.ToInt32(row["StaffTypeId"]);
                        info.JobType = row["JOBTYPE_DESCRIPTION"].ToString();
                        info.JobType_Key = Convert.ToInt32(row["MAST_HRD_JOBTYPE_KEY"]);
                        info.Company_Key = Convert.ToInt32(row["CompanyId"]);
                        info.Company_Name = row["COMPANY_NAME"].ToString();
                        info.ReportingHead_Key = Convert.ToInt32(row["reporting_Boss_key"]);
                        info.EmailID = row["Email_ID"].ToString();
                        info.PersonnelKey = Convert.ToInt32(row["MAST_HRD_DRAFT_PERSONNEL_KEY"]);
                        info.EmployeeReportingBoss = row["REPORTING_HEAD"].ToString();
                        info.BusinessAdminProfileID = Convert.ToInt32(row["BusinessAdminProfileID"]);
                        info.BusinessUserPwd = row["BusinessUserPwd"].ToString();
                        info.EmpName = row["BusinessUserLoginId"].ToString();
                        info.empCompanyId = Convert.ToInt32(row["CompanyId"]);
                        info.UserTypeId = Convert.ToInt32(row["UserTypeId"]);
                        info.empCompanyId_lbl3 = Convert.ToInt32(row["CompanyId"]);
                        info.application_ID = Convert.ToInt32(row["ApplicationId"]);
                        string moduleIdString = row["ModuleId"].ToString();
                        string actionIdString = row["UserType_Module_Action_Concatenated"].ToString();
                        string combinedString = moduleIdString + "_" + actionIdString;
                        //string[] actionIds = actionIdString.Split(',');
                        info.ModuleId ??= new List<string>();
                        //info.ActionId ??= new List<int>();
                        info.ModuleId.Add(combinedString);
                        // Add module and action IDs to the model
                        //foreach (var moduleId in moduleIds)
                        //{
                        //    if (int.TryParse(moduleId, out int moduleIdValue))
                        //    {
                        //        info.ModuleId.Add(moduleIdValue);
                        //    }
                        //}

                        //foreach (var actionId in actionIds)
                        //{
                        //    if (int.TryParse(actionId, out int actionIdValue))
                        //    {
                        //        info.ActionId.Add(actionIdValue);
                        //    }
                        //}

                        


                        lst.Add(info);
                    }

                }
                return lst;
            }
            catch
            {
                throw;
            }
        }

        public DataSet GetEmployeeById(int? EmployeeID)
        {
            try
            {
                string[] parameterNames = { "@ID" };
                string[] parameterValues = { EmployeeID.ToString() };
                return _dbAccess.Ds_Process("[SP_GET_ALL_AUTHORIZATION_BY_ID]", parameterNames, parameterValues);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public string CompanyList(int? EmpID)
        {
            string ii = "";
            try
            {
                DataSet dataSet = AllCompanyList();
                ii += "<ul class='list-group' id='ItemList'>";
                foreach (DataRow item in dataSet.Tables[0].Rows)
                {
                    var CompanyId = Convert.ToInt32(item["CompanyId"]).ToString();

                    int Info = EmpWiseCompany(CompanyId, EmpID);

                    ii += "<li class='list-group-item'>";
                    ii += "<div class='checkbox'>";
                    if (Info == 1)
                    {
                        ii += "<input type='checkbox' id=" + CompanyId + " checked />&nbsp;&nbsp;&nbsp;";
                    }
                    else
                    {
                        ii += "<input type='checkbox' id=" + CompanyId + "  />&nbsp;&nbsp;&nbsp;";
                    }

                    ii += "<label for=" + CompanyId + " >" + item["COMPANY_NAME"].ToString() + "</ label > ";
                    ii += "</div>";
                    ii += "</li>";
                }
                ii += "</ul>";
                return ii;


            }
            catch (Exception ex)
            {

                throw;
            }



        }

        private int EmpWiseCompany(string companyId, int? empID)
        {
            try
            {
                string[] parameterNames = { "@CompanyID", "@EmpID" };
                string[] parameterValues = { companyId.ToString(), empID.ToString() };
                return _dbAccess.int_Process("SP_FATCH_EMPWISECOMPANIES", parameterNames, parameterValues);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private DataSet AllCompanyList()
        {
            try
            {
                string[] parameterNames = { };
                string[] parameterValues = { };
                return _dbAccess.Ds_Process("SP_FATCH_COMPANIES", parameterNames, parameterValues);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int SaveLebelOne(AuthorizationAPIModel model)
        {
            try
            {
                string[] parameterNames = { "@EMPLOYEE_MASTER_KEY", "@BusinessAdminProfileID", "@UserTypeId", "@UserID", "@BusinessUserLoginId", "@BusinessUserPwd", "@EmailID" };
                string[] parameterValues = { model.EmployeeID.ToString(), model.BusinessAdminProfileID.ToString(), model.UserTypeId.ToString(), model.PersonnelKey.ToString(), model.EmployeeName, model.EmployeePassword, model.EmailID };
                return _dbAccess.int_Process("SP_SAVE_EMPLOYEE_USERID", parameterNames, parameterValues);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int SaveCompanyList(AuthorizationAPIModel model)
        {
            try
            {
                string[] parameterNames = { "@EMPLOYEE_MASTER_KEY", "@BusinessAdminProfileID", "@CompanyId" };
                string[] parameterValues = { model.EmployeeID.ToString(), model.BusinessAdminProfileID.ToString(), model.CompanyId.ToString() };
                return _dbAccess.int_Process("SP_SAVE_EMPLOYEE_COMPANYACCESS", parameterNames, parameterValues);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int SaveEmpLogin(AuthorizationAPIModel model)
        {
            try
            {
                string[] parameterNames = { "@EMPLOYEE_MASTER_KEY", "@BusinessAdminProfileID", "@CompanyId" };
                string[] parameterValues = { model.EmployeeID.ToString(), model.BusinessAdminProfileID.ToString(), model.CompanyId.ToString() };
                return _dbAccess.int_Process("", parameterNames, parameterValues);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<SelectListItem> GetUserType()
        {
            try
            {
                string[] pname = { };
                string[] pvalue = { };
                DataSet DS = _dbAccess.Ds_Process("SP_GET_UserType", pname, pvalue);
                List<SelectListItem> types = new List<SelectListItem>();

                types.Add(new SelectListItem { Text = "-Select-", Value = "0" });
                foreach (DataRow dr in DS.Tables[0].Rows)
                {
                    types.Add(new SelectListItem { Text = dr["USER_TYPE_DESC"].ToString(), Value = dr["USER_TYPE_KEY"].ToString() });
                }
                return types;

            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public string GetempCompany(AuthorizationAPIModel authmodel)
        {
            string dropdown = "";
            try
            {
                DataSet dataSet = empCompanyList(authmodel);
                List<SelectListItem> Company = new List<SelectListItem>();
                dropdown = "<select>";
                dropdown += $"<option value='{0}'>{"--Select Company--"}</option>";
                foreach (DataRow item in dataSet.Tables[0].Rows)
                {
                    dropdown += $"<option value='{Convert.ToInt32(item["CompanyId"])}'>{item["COMPANY_NAME"].ToString()}</option>";
                }
                dropdown += "</select>";
                return dropdown;


            }
            catch (Exception ex)
            {

                throw;
            }



        }
        public DataSet empCompanyList(AuthorizationAPIModel authmodel)
        {
            try
            {
                string[] parameterNames = { "@EmployeeId" };
                string[] parameterValues = { authmodel.EmployeeID.ToString() };
                return _dbAccess.Ds_Process("Sp_Get_empWiseCompanyList", parameterNames, parameterValues);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public string GetAllUserTypeList()
        {
            string ii = "";
            try
            {
                DataSet dataSet = GetAllUserType();
                ii += "<ul class='list-group' id='ItemUserTypeList'>";
                foreach (DataRow item in dataSet.Tables[0].Rows)
                {
                    var UserTypeId = Convert.ToInt32(item["USER_TYPE_KEY"]).ToString();


                    ii += "<li class='list-group-item'>";
                    ii += "<div class='checkbox'>";
                    ii += "<input type='checkbox' TypeId=" + UserTypeId + "  />&nbsp;&nbsp;&nbsp;";
                    ii += "<label for=" + UserTypeId + " >" + item["USER_TYPE_DESC"].ToString() + "</ label > ";
                    ii += "</div>";
                    ii += "</li>";
                }
                ii += "</ul>";
                return ii;


            }
            catch (Exception ex)
            {

                throw;
            }



        }
        public DataSet GetAllUserType()
        {
            try
            {
                string[] parameterNames = { };
                string[] parameterValues = { };
                return _dbAccess.Ds_Process("SP_GET_UserType", parameterNames, parameterValues);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string GetempUserTypeList(AuthorizationAPIModel Authmodel)
        {
            string ii = "";
            try
            {
                DataSet dataSet = GetAllUserType();
                ii += "<ul class='list-group' id='ItemUserTypeList'>";
                foreach (DataRow item in dataSet.Tables[0].Rows)
                {
                    var TypeId = Convert.ToInt32(item["USER_TYPE_KEY"]).ToString();

                    Authmodel.UserTypeId = Convert.ToInt32(TypeId);

                    int info = EmpWiseUserType(Authmodel);

                    ii += "<li class='list-group-item'>";
                    ii += "<div class='checkbox'>";
                    if (info == 1)
                    {
                        ii += "<input type='checkbox' class='checkbox-item data-typeid' value=" + TypeId + " checked />&nbsp;&nbsp;&nbsp;";
                    }
                    else
                    {
                        ii += "<input type='checkbox' class='checkbox-item data-typeid' value=" + TypeId + "  />&nbsp;&nbsp;&nbsp;";
                    }
                    
                    ii += "<label for=" + TypeId + " >" + item["USER_TYPE_DESC"].ToString() + "</ label > ";
                    ii += "</div>";
                    ii += "</li>";
                }
                ii += "</ul>";
                return ii;


            }
            catch (Exception ex)
            {

                throw;
            }



        }
        public DataSet GetempUserType()
        {
            try
            {
                string[] parameterNames = { };
                string[] parameterValues = { };
                return _dbAccess.Ds_Process("SP_GET_UserType", parameterNames, parameterValues);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int EmpWiseUserType(AuthorizationAPIModel Authmodel)
        {
            try
            {
                string[] parameterNames = { "@EmpId","@CompanyId","@UserTypeId" };
                string[] parameterValues = {Authmodel.EmployeeID.ToString(),Authmodel.empCompanyId.ToString(),Authmodel.UserTypeId.ToString() };
                return _dbAccess.int_Process("SP_GET_UserTypeEmpCompWise", parameterNames, parameterValues);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int SaveAccessMapDetls_Modules(BusinessAdminProfileAccessMapDtls2 model)
        {
            try
            {
                
                string[] parameterNames = { "@EMPLOYEE_MASTER_KEY", "@BusinessAdminProfileID", "@CompanyId", "@UserTypeId", "@ApplicationId", "@ModuleId", "@ActionId", "@CreatedBy", "@RECTYPE" };
                string[] parameterValues = { model.EMPLOYEE_MASTER_KEY.ToString(), model.BusinessAdminProfileID.ToString(), model.CompanyId.ToString(), model.UserTypeId.ToString(), model.ApplicationId.ToString(), model.ModuleId.ToString(), model.ActionId.ToString(), model.CreatedBy.ToString() , "INSERT" };
                return _dbAccess.int_Process("SP_Save_BusinessAdminProfile_Access_Map_Dtls2", parameterNames, parameterValues);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int DELETEAccessMapDetls_Modules(int ID)
        {
            try
            {

                string[] parameterNames = { "@EMPLOYEE_MASTER_KEY", "@BusinessAdminProfileID", "@CompanyId", "@UserTypeId", "@ApplicationId", "@ModuleId", "@ActionId", "@CreatedBy", "@RECTYPE" };
                string[] parameterValues = {"0",ID.ToString(), "0" ,"0", "0", "0", "0", "0", "dELETE" };
                return _dbAccess.int_Process("SP_Save_BusinessAdminProfile_Access_Map_Dtls2", parameterNames, parameterValues);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int SaveAccessMapDetls(AuthorizationAPIModel model)
        {
            try
            {
                string[] parameterNames = { "@EMPLOYEE_MASTER_KEY", "@BusinessAdminProfileID", "@CompanyId","@UserTypeId" };
                string[] parameterValues = { model.EmployeeID.ToString(), model.BusinessAdminProfileID.ToString(), model.empCompanyId.ToString(),model.UserTypeId.ToString() };
                return _dbAccess.int_Process("SP_Save_BusinessAdminProfile_Access_Map_Dtls1", parameterNames, parameterValues);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<SelectListItem> FetchApplicationNames()
        {
            try
            {
                string[] pname = { };
                string[] pvalue = { };
                DataSet DS = _dbAccess.Ds_Process("SP_FETCH_APPROVAL_SETUP", pname, pvalue);
                List<SelectListItem> types = new List<SelectListItem>();

                types.Add(new SelectListItem { Text = "-Select-", Value = "0" });
                foreach (DataRow dr in DS.Tables[0].Rows)
                {
                    types.Add(new SelectListItem { Text = dr["ApplicationName"].ToString(), Value = dr["ApplicationId"].ToString() });
                }
                return types;

            }
            catch (Exception ex)
            {

                throw;
            }

        }
       
        public string GetModuleAccess(int id)
        {
            string ii = "";
            int moduleTypeid = 0;
            int count = 0;
            try
            {
                string[] pname = { "@id" };
                string[] pvalue = { id.ToString() };
                DataSet ds = _dbAccess.Ds_Process("SP_GET_Authorization_SETUP_MAIN_MENU", pname, pvalue);
                List<object> types = new List<object>();


                foreach (DataRow item in ds.Tables[0].Rows)
                    {
                    
                    moduleTypeid = Convert.ToInt32(item["ModuleTypeId"]);
                         
                        
                    
                    if (moduleTypeid == 100)
                    {
                        ii += "<tr><th style='text-align:left;background-color: honeydew;font-size: medium;color: black;' colspan='9'>" + item["ModuleName"].ToString() + "</th></tr>";
                        
                    }
                    if (moduleTypeid == 800)
                    {
                        count++;
                        ii += "<tr>";
                        ii += "<td align='center' width='6%'><input type='hidden' id='hdn_User_Module_" + Convert.ToInt32(item["ModuleId"]) + "' value='" + Convert.ToInt32(item["ModuleId"]) + "' />" + count + "</td>";

                        ii += "<td align='center' width='10%'>" + item["ModuleName"].ToString() + "</td>";


                        DataSet dataSet = GetAllUserActions();

                        foreach (DataRow itemchk in dataSet.Tables[0].Rows)
                        {
                            ii += "<td align='center' width='8%'>";
                            //ii += "<input type='checkbox' id='" + itemchk["ActionName"].ToString() + "_" + Convert.ToInt32(item["ModuleId"]) + "'  />&nbsp;&nbsp;&nbsp;";
                            ii += "<input type='checkbox' id='" + Convert.ToInt32(itemchk["ActionId"]) + "_" + Convert.ToInt32(item["ModuleId"]) + "'  />&nbsp;&nbsp;&nbsp;";
                            ii += "</td>";
                        }
                        ii += "<td align='center' width='8%'>";
                        ii += "<input type='checkbox' id='deny_" + Convert.ToInt32(item["ModuleId"]) + "' checked/>&nbsp;&nbsp;&nbsp;";
                        ii += "</td>";
                        ii += "</tr>";
                    }
                    

                 }
                


                return ii;


            }
            catch (Exception ex)
            {

                throw;
            }



        }

        public DataSet GetUserTypebyBusinessAdminProfile(AuthorizationAPIModel model)
        {
            try
            {
                string[] parameterNames = { "@EMPLOYEE_MASTER_KEY", "@COMPANY_ID" };
                string[] parameterValues = { model.EmployeeID.ToString(),model.empCompanyId.ToString() };
                return _dbAccess.Ds_Process("SP_GET_USER_TYPE_BUSINESS_ADMIN", parameterNames, parameterValues);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public string GetempUserTypeListBusinessAdminProfile(AuthorizationAPIModel model)
        {
            string ii = "";
            try
            {
                DataSet dataSet = GetUserTypebyBusinessAdminProfile(model);
                ii += "<ul class='list-group' id='ItemUserTypeList'>";
                foreach (DataRow item in dataSet.Tables[0].Rows)
                {
                    var TypeId = Convert.ToInt32(item["UserTypeId"]).ToString();

                    model.UserTypeId = Convert.ToInt32(TypeId);

                    int info = EmpWiseUserType(model);

                    ii += "<li class='list-group-item'>";
                    ii += "<div class='checkbox'>";
                    if (info == 1)
                    {
                        ii += "<input type='checkbox' class='checkbox-item blue-checkbox' value=" + TypeId + " checked />&nbsp;&nbsp;&nbsp;";
                    }
                    else
                    {
                        ii += "<input type='checkbox' class='checkbox-item' value=" + TypeId + "  />&nbsp;&nbsp;&nbsp;";
                    }

                    ii += "<label for=" + TypeId + " >" + item["USER_TYPE_DESC"].ToString() + "</ label > ";
                    ii += "</div>";
                    ii += "</li>";
                }
                ii += "</ul>";
                return ii;


            }
            catch (Exception ex)
            {

                throw;
            }



        }
        public DataSet GetAllUserActions()
        {
            try
            {
                string[] parameterNames = {  };
                string[] parameterValues = { };
                return _dbAccess.Ds_Process("SP_FETCH_USER_ACTIONS_ACCESS", parameterNames, parameterValues);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        public string GetempUserActionList()
        {
            string ii = "";
           
          
                try
                {
                      
                            DataSet dataSet = GetAllUserActions();

                            ii += "<ul class='list-group' id='ItemUserTypeList'>";
                            foreach (DataRow item in dataSet.Tables[0].Rows)
                            {
                                var ActionId = Convert.ToInt32(item["ActionId"]).ToString();


                                ii += "<li class='list-group-item'>";
                                ii += "<div class='checkbox'>";
                                ii += "<input type='checkbox' TypeId=" + ActionId + "  />&nbsp;&nbsp;&nbsp;";
                                ii += "<label for=" + ActionId + " >" + item["ActionName"].ToString() + "</ label > ";
                                ii += "</div>";
                                ii += "</li>";
                            }
                            ii += "</ul>";
                    
                        
                return ii;
                }
                catch (Exception ex)
                {

                    throw;
                }
               

            




        }

        //public string FetchAuthorizationByUserID(int UserID, int CompanyKey, int DesignationKey)
        //{
        //    try
        //    {
        //        string div = "";
        //        DataSet ds = GetAuthorizationByUserID(UserID, CompanyKey,DesignationKey);

        //        foreach (DataRow dr in ds.Tables[0].Rows)
        //        {
        //            div = div + "<li style=\"padding-bottom:10px;\">";
        //            string ModuleType = dr["MODULETYPE"].ToString();
        //            if (ModuleType == "1")
        //            {
        //                string Moduleid = dr["MODULEID"].ToString();
        //                string moname = dr["MODULENAME"].ToString();
        //                foreach (DataRow drM in ds.Tables[1].Rows)
        //                {
        //                    if (drM["MENU"].ToString() == dr["MENU"].ToString())
        //                    {

        //                        string MenuType = drM["MODULETYPE"].ToString();
        //                        if (MenuType == "100")
        //                        {
        //                            string Menuid = drM["MENU"].ToString();
        //                            string mename = drM["MODULENAME"].ToString();

        //                            div = div + "<a href=\"#" + mename + "\" data-bs-toggle=\"collapse\">";
        //                            //div = div + "<i data-feather=\"bookmark\"></i>\r\n" +
        //                            div = div + "<i data-feather=\"airplay\"></i>\r\n" +
        //                                        "<span class=\"menu-title cursor-pointer fs-5\" aria-expanded=\"false\">" + mename + "</span>\r\n" +
        //                                        "<span class=\"menu-arrow\"></span>\r\n\r\n" +
        //                                        "</a>";
        //                            div = div + "<div style=\"margin-left:2vw;\" class=\"collapse\" id=\"" + mename + "\">\r\n" +
        //                                                    "<ul class=\"nav-second-level ml-2\">";
        //                            foreach (DataRow drSM in ds.Tables[2].Rows)
        //                            {
        //                                //if ( drSM["MENU"].ToString() == drM["MENU"].ToString() && drSM["SUBMENU"].ToString() == drM["SUBMENU"].ToString() && drSM["MODULE"].ToString() == drM["MODULE"].ToString() )
        //                                if (drSM["MODULE"].ToString() == drM["MODULE"].ToString())
        //                                //if ( drSM["MODULE"].ToString() == drM["MODULE"].ToString() )
        //                                {

        //                                    string SubMenu = drSM["MODULETYPE"].ToString();

        //                                    if (SubMenu == "800")
        //                                    {

        //                                        // string SubMid = drSM["SUBMENU"].ToString();
        //                                        string SubMname = drSM["MODULENAME"].ToString();
        //                                        string ModuleLink = drSM["MODULELINK"].ToString();





        //                                        div = div + "<li>\r\n" +
        //                                                     //"<a class=\"nav-link\" href=\"" + ModuleLink + "? param1"+ drSM["row"] +\">" + SubMname + "</a>\r\n" +
        //                                                     "<a class=\"nav-link\" href=\"" + ModuleLink + "?param1=" + drSM["ActionIds"] + "\">" + SubMname + "</a>\r\n" +
        //                                                   "</li>";



        //                                    }
        //                                }

        //                                //else
        //                                //{

        //                                //    continue;
        //                                //}

        //                            }
        //                            div = div + "</ul>\r\n " +
        //                                                    "</div>\r\n";
        //                        }


        //                    }
        //                    else
        //                    {

        //                        continue;
        //                    }


        //                }


        //            }
        //            div = div + "</li>";
        //            continue;

        //        }

        //        return div;

        //        //return (string.Empty);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //================------------------============ Designed   =================----------------=============================

        public string FetchAuthorizationByUserID(int UserID, int CompanyKey, int DesignationKey)
        {
            try
            {
                string div = "";
                DataSet ds = GetAuthorizationByUserID(UserID, CompanyKey, DesignationKey);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    div = div + "<li>";
                    string ModuleType = dr["MODULETYPE"].ToString();
                    if (ModuleType == "1")
                    {
                        string Moduleid = dr["MODULEID"].ToString();
                        string moname = dr["MODULENAME"].ToString();
                        foreach (DataRow drM in ds.Tables[1].Rows)
                        {
                            if (drM["MENU"].ToString() == dr["MENU"].ToString())
                            {

                                string MenuType = drM["MODULETYPE"].ToString();
                                if (MenuType == "100")
                                {
                                    string Menuid = drM["MENU"].ToString();
                                    string mename = drM["MODULENAME"].ToString();

                                    div = div + "<a href=\"#" + mename + "\" data-bs-toggle=\"collapse\">";



                                    div = div + "<i class=\"material-symbols-outlined\" style=\"color:#01a8c9 !important;\" onmouseover=\"this.style.color='#003e4a'\" onmouseout=\"this.style.color='#01a8c9'\" > auto_stories</i>\r\n" +

                                              "<span style=\"color:#7136fe !important;  font-family: oswald; font-size:20px;\" onmouseover=\"this.style.color='#600000'\" onmouseout=\"this.style.color='#7136fe'\">" + mename + "</span>\r\n" +

                                            "<span class=\"menu-arrow\" style=\"color:#01a8c9 !important;\" onmouseover=\"this.style.color='#003e4a'\" onmouseout=\"this.style.color='#01a8c9'\"></span>\r\n\r\n" +
                                           "</a>";




                                    div = div + "<div class=\"collapse\"onmouseout=\"this.style.color='#01a8c9'\" id=\"" + mename + "\">\r\n" +
                                                           "<ul class=\"nav-second-level \">";
                                    foreach (DataRow drSM in ds.Tables[2].Rows)
                                    {

                                        if (drSM["MODULE"].ToString() == drM["MODULE"].ToString())

                                        {

                                            string SubMenu = drSM["MODULETYPE"].ToString();

                                            if (SubMenu == "800")
                                            {


                                                string SubMname = drSM["MODULENAME"].ToString();
                                                string ModuleLink = drSM["MODULELINK"].ToString();





                                                div = div + "<li>\r\n" +


                                                                    //"<a href=\"" + ModuleLink + "?param1=" + drSM["ActionIds"] + "\" style=\"font-weight: bold;font-family: oswald; color:#01a8c9 !important; font-size:15px;\" onmouseover=\"this.style.color='#003e4a'\" onmouseout=\"this.style.color='#01a8c9'\">" + "<i class=\"material-symbols-outlined\" onmouseover=\"this.style.color='#003e4a'\" onmouseout=\"this.style.color='#01a8c9'\">switch_left</i>" + SubMname + "</a>\r\n" +


                                                                    "<a href=\"" + ModuleLink + "?param1=" + drSM["ActionIds"] + "\" style=\"font-weight: bold;font-family: oswald; color:#01a8c9 !important; font-size:15px;\" onmouseover=\"this.style.color='#003e4a' ;  this.style.fontSize='20px'\" onmouseout=\"this.style.color='#01a8c9' ;  this.style.fontSize='15px'\">" + "<i class=\"material-symbols-outlined\" onmouseover=\"this.style.color='#003e4a'\" onmouseout=\"this.style.color='#01a8c9'\">switch_left</i>" + SubMname + "</a>\r\n" +
                                                "</li>";

                                            }
                                        }



                                    }
                                    div = div + "</ul>\r\n " +
                                                            "</div>\r\n";
                                }


                            }
                            else
                            {

                                continue;
                            }


                        }


                    }
                    div = div + "</li>";
                    continue;

                }

                return div;

                //return (string.Empty);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataSet GetAuthorizationByUserID(int userID, int CompanyKey, int DesignationKey)
        {
            try
            {
                string[] parameterNames = { "@EMPLOYEE_MASTER_KEY", "@COMPANY_KEY", "@DESIGNATION_KEY","@TENANTID" };
                string[] parameterValues = { userID.ToString(), CompanyKey.ToString(), DesignationKey.ToString(),"2" };
                return _dbAccess.Ds_Process("[SP_GET_AUTHORIZATIOIN_DATA_BY_BAP_ID]", parameterNames, parameterValues);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string GetActionID(int company, int designationId, int appID, int employee_Master_Key, int moduleID)
        {
            try
            {
                string[] parameterNames = { "@EMPLOYEE_MASTER_KEY", "@APPLICATION_ID", "@MODULE_ID", "@COMPANY_KEY", "@USER_TYPE_ID" };
                string[] parameterValues = { employee_Master_Key.ToString(), appID.ToString(), moduleID.ToString(), company.ToString(), designationId.ToString() };

                DataSet ds = _dbAccess.Ds_Process("SP_GET_EMPLOYEE_ACTION_ID", parameterNames, parameterValues);

                if (ds.Tables.Count > 0)
                {
                    // Assuming you want to extract the ActionIds column from the first table
                    DataTable dataTable = ds.Tables[0];

                    if (dataTable.Columns.Contains("ActionIds"))
                    {
                        // Extract values from the "ActionIds" column and concatenate them
                        string result = string.Join(",", dataTable.AsEnumerable().Select(row => row.Field<string>("ActionIds")));

                        return result;
                    }
                    else
                    {
                        // Handle the case where the "ActionIds" column is not present
                        return "ActionIds column not found";
                    }
                }
                else
                {
                    // Handle the case where the DataSet is empty
                    return "No data available";
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, log or handle differently
                throw;
            }
        }





    }
}
