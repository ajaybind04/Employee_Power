using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeePower.Models;
using System.Web.Security;
namespace EmployeePower.Controllers
{
    public class AccountController : Controller
    {
        DB_Emp_PowerEntities dbEmpContext = null;
        public AccountController()
        {
            dbEmpContext = new DB_Emp_PowerEntities();
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        #region (This Region Have - Login For All User)

        [HttpGet]
        public ActionResult Login_Page()
        {
            try
            {

                return View();
            }
            catch (Exception ex)
            {
                string exception = ex.ToString();
                return View();
            }
        }


        [HttpPost]
        public ActionResult Login_Page(Tbl_Employee_Login_Details objEmp)
        {
            try
            {
                if (!string.IsNullOrEmpty(objEmp.Emp_Email) && !string.IsNullOrEmpty(objEmp.Emp_Password_Hash))
                {
                    bool isValid = dbEmpContext.Tbl_Employee_Login_Details.Any(a => a.Emp_Email.ToLower() == objEmp.Emp_Email.ToLower() && a.Emp_Password_Hash == objEmp.Emp_Password_Hash);
                    if (isValid)
                    {
                        FormsAuthentication.SetAuthCookie(objEmp.Emp_Email, false);
                        return RedirectToAction("Employee", "Create");
                    }
                    ModelState.AddModelError("", "Invalid User Name OR Password");
                    return View(objEmp);
                }
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message.ToString());
                return View();
            }
        }

        #endregion

        #region (This Region Have - Registration For All Users)

        [HttpGet]
        public ActionResult Registration_Page()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message.ToString());
                return View();
            }
        }

        [HttpPost]
        public ActionResult Registration_Page(Tbl_Employee_Login_Details objEmp)
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message.ToString());
                return View();
            }
        }

        #endregion

    }
}