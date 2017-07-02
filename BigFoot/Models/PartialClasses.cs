using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Mvc; for dynamic roles
//using Microsoft.AspNet.Identity;for dynamic roles
//using BigFoot.Models;for dynamic roles
//using Microsoft.AspNet.Identity.EntityFramework;for dynamic roles

namespace BigFoot
{
    //[MetadataType(typeof(ConfigMetadata))]
    //public partial class Config
    //{
    //}

    //[MetadataType(typeof(EmpTypeMetadata))]
    //public partial class EmpTypes
    //{
    //}

    //[MetadataType(typeof(EDocTypeMetadata))]
    //public partial class EDocTypes
    //{
    //}

    //[MetadataType(typeof(AllowanceTypeMetadata))]
    //public partial class AllowanceTypes
    //{
    //}

    //[MetadataType(typeof(EmployeesMetadata))]
    //public partial class Employees
    //{
    //}

    //[MetadataType(typeof(EmpDocsMetadata))]
    //public partial class EmpDocs
    //{
    //}

    //[MetadataType(typeof(EmploymentHistoryMetadata))]
    //public partial class EmploymentHistory
    //{
    //}
    //[MetadataType(typeof(LoansMetadata))]
    //public partial class Loans
    //{
    //}
    //[MetadataType(typeof(LoanSkipMetadata))]
    //public partial class LoanSkip
    //{
    //}

    //[MetadataType(typeof(AllowanceMetadata))]
    //public partial class Allowance
    //{
    //}

    //[MetadataType(typeof(AdvanceMetadata))]
    //public partial class Advance
    //{
    //}

    //[MetadataType(typeof(BonusMetadata))]
    //public partial class Bonus
    //{        
    //}

    //[MetadataType(typeof(WagesMetadata))]
    //public partial class Wages
    //{
    //}

    //[MetadataType(typeof(PayrollMetadata))]
    //public partial class Payroll
    //{
    //}

    //public class DailyAllowEvent
    //{
    //    public string title { get; set; }
    //    public string start { get; set; }
    //    public bool allDay { get; set; }
    //}


    ///// <summary>
    ///// Used to Create a new Employee with an auto created Join date
    ///// </summary>
    //public class NewEmp
    //{
    //    public Employees emp { get; set; }

    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    //    [Display(Name = "Join Date")]        
    //    [Required]
    //    public DateTime JoinDate { get; set; }

    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    //    [Display(Name = "Drivers Lic. Expiry Date")]
    //    [RequiredIf(CompareToInt =1)] //EmpTypeID 1 has to be driver
    //    public Nullable<System.DateTime> DrivLicExp { get; set; }
        
    //}

    ///// <summary>
    ///// Used instead of the DailyAllowance class in order to allow null dates
    ///// </summary>
    //public class DA
    //{
    //    public int EmpID { get; set; }
    //    public string EmpName { get; set; }
    //    public Nullable<System.DateTime> SaveTime { get; set; }
    //    public Nullable<System.DateTime> AllowDate { get; set; }
    //}

    //    /// <summary>
    //    /// As the name suggests> Done only after payroll freeze
    //    /// </summary>
    //    public class AdjustPay
    //{
    //    public int EmpID { get; set; }
    //    public string EmpName { get; set; }
    //    public int GenMonth { get; set; }
    //    public int GenYear { get; set; }
    //    public decimal AdjAmt { get; set; }
    //    public string AdjRemark { get; set; }
    //}


    ///// <summary>
    ///// Export sal of reg emps to excel
    ///// </summary>
    //public class RegExport
    //{
    //    public string AccountNo { get; set; }
    //    public char c { get; set; } = 'c';
    //    public decimal Amount { get; set; }
    //    public string Narration { get; set; }
    //}

    ///// <summary>
    ///// Export sal of reg emps to excel
    ///// </summary>
    //public class NonRegExport
    //{
    //    public string ForMonth { get; set; }
    //    public string Name { get; set; }
    //    public string AccountNo { get; set; }
    //    public string IFSC { get; set; }
    //    public int Ten { get; set; } = 10;
    //    public decimal Amount { get; set; }
    //    public string ExportDate { get; set; }
    //}

    ///// /// <summary>
    ///// Employee Card
    ///// </summary>
    //public class EmployeeCard
    //{
    //    public Employees emp { get; set; }
    //    public IEnumerable<EmploymentHistory> emphist { get; set; }
    //    public IEnumerable<Wages> wages { get; set; }
    //    public IEnumerable<EmpDocs> empdocs { get; set; }
    //    public EmpLoanHistory elh { get; set; }
    //}

    ///// <summary>
    ///// Employee Loan History Report
    ///// </summary>
    //public class EmpLoanHistory
    //{
    //    public IEnumerable<Loans> Ln { get; set; }
    //    public IEnumerable<GetLoanHistory_Result> Lhist { get; set; }

    //}

    ///// <summary>
    ///// Used to upload Employee Documents with image
    ///// </summary>
    //public class EmpDocsImg
    //{        
    //    public int EDID { get; set; }
    //    public int EmpID { get; set; }
    //    public int EDocTypeID { get; set; }
    //    public HttpPostedFileBase UploadedFile { get; set; }

    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    //    [Display(Name = "Expiry Date")]
    //    [CheckDateRange(AddMonths =1 , ForceMore =true) ]
    //    public Nullable<System.DateTime> ExpiryDate { get; set; }
    //}

    ///// <summary>
    ///// For marking Leave
    ///// </summary>
    //public class LeaveDays
    //{
    //    public int EmpID { get; set; }
    //    public DateTime Dayt { get; set; }
        
    //    public bool IsLeave { get; set; }
    //}

    ///// <summary>
    ///// Date limiter
    ///// </summary>
    //public class CheckDateRangeAttribute : ValidationAttribute
    //{
    //    public int AddMonths { get; set; }
    //    public int AddDays { get; set; }
    //    public bool ForceMore { get; set; }

    //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //    {
    //        if (value == null)
    //        {
    //            return ValidationResult.Success;
    //        }

    //        string comparer;

    //        DateTime CompareDate = DateTime.UtcNow.Date;
    //        CompareDate= CompareDate.AddMonths(AddMonths);
    //        CompareDate = CompareDate.AddDays(AddDays);

    //        DateTime dt = (DateTime)value;

    //        if (ForceMore)
    //        {
    //            if (dt >= CompareDate)
    //                return ValidationResult.Success;
    //            comparer = " greater than or equal to ";
    //        }else
    //        {
    //            if (dt <= CompareDate)
    //                return ValidationResult.Success;
    //            comparer = " less than or equal to ";
    //        }
            
    //        return new ValidationResult(ErrorMessage ?? "Make sure your date is " + comparer + CompareDate.ToString("dd-MMM-yyyy"));
    //    }

    //}

    //public class RequiredIfAttribute : ValidationAttribute
    //{
    //    public int CompareToInt { get; set; }
        

    //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //    {
    //        NewEmp ne = (NewEmp) validationContext.ObjectInstance;

    //        if (ne.emp.EmpTypeID == CompareToInt)
    //        {
    //            if (value != null && (value.GetType() == typeof(DateTime)) )
    //                return ValidationResult.Success;
    //        }
    //        else
    //            return ValidationResult.Success;

    //        return new ValidationResult("Drivers have to have a licence with a future expiry date");
    //    }

    //}
    ///// <summary>
    ///// Custom authorization attribute for setting per-method accessibility 
    ///// </summary>
    ////[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    ////public class SetPermissionsAttribute : AuthorizeAttribute
    ////{
    ////    /// <summary>
    ////    /// The name of each action that must be permissible for this method, separated by a comma.
    ////    /// </summary>
    ////    public string Permissions { get; set; }

    ////    protected override bool AuthorizeCore(HttpContextBase httpContext)
    ////    {
    ////        NTHRPayEntities1 db = new NTHRPayEntities1();            
    ////        UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
    ////        ApplicationDbContext dbu = new ApplicationDbContext();

    ////        bool isUserAuthorized = base.AuthorizeCore(httpContext);

    ////        string[] permissions = Permissions.Split(',').ToArray();

    ////        IEnumerable<string> perms = permissions.Intersect(db.Permissions.Select(p => p.ActionName));
    ////        List<IdentityRole> roles = new List<IdentityRole>();

    ////        if (perms.Count() > 0)
    ////        {
    ////            foreach (var item in perms)
    ////            {
    ////                var currentUserId = httpContext.User.Identity.GetUserId();
    ////                var relatedPermisssionRole = dbu.Roles.Find(db.Permissions.Single(p => p.ActionName == item).RoleId).Name;
    ////                if (userManager.IsInRole(currentUserId, relatedPermisssionRole))
    ////                {
    ////                    return true;
    ////                }
    ////            }
    ////        }
    ////        return false;
    ////    }
    ////}
}