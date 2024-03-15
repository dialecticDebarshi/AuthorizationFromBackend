using System.Reflection;

namespace testingCore1.Models
{
    public class ApprovalModel
    {
    }
    #region Normal Approval
    public class ApprovalModelOne
    {
        public int TenantId { get; set; }

        public int APPROVAL_LVL1_KEY { get; set; }
        public int ApplicationId { get; set; }

        public int ModuleId { get; set; }

        public int APPROVAL_TYPE_KEY { get; set; }

        public int PATH_SETUP_TYPE { get; set; }
        public int APPROVER_OPTION { get; set; }
        public int ApprovalStepId { get; set; }


        //public string? GroupHeadName { get; set; }
        public int ACTIVEFLAG { get; set; }


        //public string? DIN { get; set; }
       
        //public int MyProperty { get; set; }
    }
    public class ApprovalModelTwo
    {
             
        public int APPROVAL_LVL1_KEY { get; set; }
        public int APPROVAL_LVL2_KEY { get; set; }

        public int STEP_NO { get; set; }

        public int APPROVAL_User_Type_Key { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int ACTIVEFLAG { get; set; }

      
    }
    public class ApprovalModelThree
    {
        public int APPROVAL_LVL3_KEY { get; set; }
        public int APPROVAL_LVL2_KEY { get; set; }

        public int STEP_NO { get; set; }

        public int EMPLOYEE_MASTER_KEY { get; set; }

        public int ACTIVEFLAG { get; set; }

        
    }
    #endregion

}

