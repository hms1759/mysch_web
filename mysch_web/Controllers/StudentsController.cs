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
    public class StudentsController : Controller
    {
        mySChoolEntities mysch = new mySChoolEntities();
        // GET: Students
        [HttpGet]
        public ActionResult StudentDetails()
        {

                return View(mysch.student_details.ToList());
            

        }
        // GET: Students/Create
        public ActionResult Studentcreate()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Studentcreate(student_details cc)
        {
            try
            // TODO: Add insert logic here
            {
               
                    var search = mysch.student_details.FirstOrDefault(s => s.Email == cc.Email
                     || s.Name == cc.Name);
                    if (search != null)
                    {
                        cc.LoginErrorMessage = "Students Already exist";
                        return View("Studentcreate", cc);



                    }


                    else
                    {
                        mysch.student_details.Add(cc);
                        cc.LoginErrorMessage = " Already exist";
                        mysch.SaveChanges();


                        return RedirectToAction("StudentDetails", "Students");
                    }

                

            }
            catch
            {
                return View();
            }
        }

        public ActionResult Dashboard()
        {
            return View();

        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
           
                return View(mysch.student_details.Where(s => s.id 
                == id).FirstOrDefault());
            
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, student_details student)
        {
            try
            {
                // TODO: Add update logic here
              
                    mysch.Entry(student).State = EntityState.Modified;
                    mysch.SaveChanges();

                    return RedirectToAction("StudentDetails");
                

            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
           

                return View(mysch.student_details.Where(s => s.id == id).FirstOrDefault());
            
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, student_details admin)
        {
            try
            {
               
                    var dd = mysch.student_details.Where(s => s.id == id).FirstOrDefault();
                    mysch.student_details.Remove(dd);
                    mysch.SaveChanges();

                    return RedirectToAction("StudentDetails");
                
            }
            catch
            {
                return View();
            }
        }
        // GET: Students/Details/5
        public ActionResult Details(int id)
        {

            using (mysch_webEntities1 db = new mysch_webEntities1())
            {

                return View(db.student_details.Where(s => s.Id == id).FirstOrDefault());
            }
        }
        public ActionResult detail ()
        {
            return View();
        }

        public ActionResult Getlist()
        {
            List<student_details> mylist = new List<student_details>();
           
                mylist = mysch.student_details.ToList<student_details>();
                return Json(new { data = mylist }, JsonRequestBehavior.AllowGet);

            

        }
    }
}     






