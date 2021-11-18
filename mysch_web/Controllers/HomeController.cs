using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mysch_web.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace mysch_web.Controllers
{
  
    // @Html.ActionLink("Edit", "Edit", new { id = Model.Id }) |
    public class HomeController : Controller
    {

        mySChoolEntities mysch = new mySChoolEntities();
        [HttpGet]
        public ActionResult Index()
        {
            
            return View();
        }
       
        [HttpPost]
        public ActionResult Autorize(mysch_web.Models.login Log)
        {
            if (Log.Password == null || Log.Username == null)
            {
                Log.LoginErrorMessage = "Username or Password is empty";

                return View("Index", Log);
            }
            else
                {

              
                    var db = mysch.Admin_staff.Where
                        (s => s.Email == Log.Username && s.passWord == Log.Password).FirstOrDefault();
                    if (db == null)
                    {
                        Log.LoginErrorMessage = "Wrong Username or Password.";
                        return View("Index", Log);
                    }
                    else
                    {
                        Session["userID"] = db.id;
                        Session["userName"] = db.Name;
                        return RedirectToAction("Admin", "Home");
                    }
                } 
           

        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return View("Index");
        }
        public ActionResult Admin()
        {
            if (@Session["userID"] == null)
            {
                return RedirectToAction("Index", "Home");

            }

            return View();
            
        }

        public ActionResult Admission()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Student()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Std(mysch_web.Models.login Log)
        {
            if (Log.Password == null || Log.Username == null)
                {
                    Log.LoginErrorMessage = "Username or Password is empty";
                    return View("Student", Log);
                }
 
                else
                {
                    
               
                            var db = mysch.student_details.Where
                        (s => s.Email == Log.Username && s.Phone == Log.Password).FirstOrDefault();
                    if (db == null)
                    {
                        Log.LoginErrorMessage = "Wrong Username or Password.";
                        return View("Student", Log);
                    }
                    else
                    {
                        Session["userID"] = db.id;
                        Session["userName"] = db.Name;
                        return RedirectToAction("Dashboard", "Students");
                    }

                }
            

        }

        public ActionResult Dashboard()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}