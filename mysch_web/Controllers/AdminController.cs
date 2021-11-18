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
    public class AdminController : Controller

    {
        mySChoolEntities mysch = new mySChoolEntities();
        [HttpGet]
        public ActionResult Search()
        {

            return View();

        }
        [HttpPost]
        public ActionResult Search(mysch_web.Models.Search mysearch)
        {

            
                return View(mysch.Admin_staff.Where(x => x.Name.Contains(mysearch.Search1)).ToList());
           
        }


        [HttpGet]
        public ActionResult All_staff()
        {
           

                return View(mysch.Admin_staff.ToList());
           
        }

        [HttpPost]
        // GET: All staff
        public ActionResult All_staff(mysch_web.Models.Search mySearch)
        {
                if (mySearch.Search1 == null)
                {
                    return View(mysch.Admin_staff.ToList());
                }
                return View(mysch.Admin_staff.Where(x=>x.Name.Contains(mySearch.Search1)).ToList());
         
        }
        // GET: All staff for the staff view
        public ActionResult All_staf()
        {
           

                return View(mysch.Admin_staff.ToList());
          
        }

        // GET: search


       
        // GET: Admin/Details
        public ActionResult Details(int id)
        {

           

                return View(mysch.Admin_staff.Where(s=> s.id == id).FirstOrDefault());
           

        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Admin_staff creat)
        { 
            try
                // TODO: Add insert logic here
            { 
                    var search = mysch.Admin_staff.FirstOrDefault(s => s.surname == creat.surname
                     || s.Phone == creat.Phone);
                    if (search != null)
                    {
                         creat.LoginErrorMessage = "surname or phone number alread exit";
                        return View("Create", creat);



    }


                    else
                    {
                        mysch.Admin_staff.Add(creat);
                        mysch.SaveChanges();

                        return RedirectToAction("All_staff", "Admin");
                    }

                 
                            
            }
            catch
            {
                return View();
            }
        }

        // GET: M/Edit/5
        public ActionResult Edit(int id)
        {
            

                return View(mysch.Admin_staff.Where(s => s.id == id).FirstOrDefault());
          
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Admin_staff admin)
        {
            try
            {
                // TODO: Add update logic here
               
                    mysch.Entry(admin).State = EntityState.Modified;
                    mysch.SaveChanges();
                    
                return RedirectToAction("All_staff");
             

            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
          

                return View(mysch.Admin_staff.Where(s => s.id == id).FirstOrDefault());
         
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Admin_staff admin)
        {
            try
            {
                // TODO: Add delete logic here
                 var dd = mysch.Admin_staff.Where(s => s.id == id).FirstOrDefault();
                    mysch.Admin_staff.Remove(dd);
                    mysch.SaveChanges();

                    return RedirectToAction("All_staff");
                
            }
            catch
            {
                return View();
            }
        }



        public ActionResult SetExamination(int id, Admin_staff admin)
        {
            try
            {
                // TODO: Add delete logic here
              
                    var dd = mysch.Admin_staff.Where(s => s.id == id).FirstOrDefault();
                    mysch.Admin_staff.Remove(dd);
                    mysch.SaveChanges();

                    return RedirectToAction("All_staff");
                
            }
            catch
            {
                return View();
            }
        }
    }
}
