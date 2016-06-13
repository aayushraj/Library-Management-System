using LibraryMS.Models.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using WebMatrix.WebData;

namespace LibraryMS.Controllers.Account
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                bool success = WebSecurity.Login(login.UserName, login.Password, false);
                if(success)
                {
                    string returnUrl = Request.QueryString["ReturnUrl"];
                    if(returnUrl==null)
                    {
                        Response.Redirect("~/Home/Index");
                    }
                    else
                    {
                        Response.Redirect(returnUrl);
                    }
                }

                else
                {
                    ModelState.AddModelError("Error", "Enter Username or Password");
                }
                
            }
            return View(login); 
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Register register)
        {
            if (ModelState.IsValid)
            {
                if (!WebSecurity.UserExists(register.UserName))
                {
                    WebSecurity.CreateUserAndAccount(register.UserName, register.Password, new { FullName=register.Fullname, EmailId = register.Email },false);
                    
                    Response.Redirect("~/Account/Login");
                }

            }
            else 
            {
                ModelState.AddModelError("Error", "Please enter all details");  
            }  
            
            return View(); 
        }
         
	}
}