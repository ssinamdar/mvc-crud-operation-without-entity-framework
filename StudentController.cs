using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Crud.Models;

namespace MVC_Crud.Controllers
{
    public class StudentController : Controller
    {
        // 1. *************RETRIEVE ALL STUDENT DETAILS ******************
        // GET: Student
        public ActionResult Index()
        {
            var dbHandle = new StudentDbHandle();
            return View(dbHandle.GetStudentModels());
        }

        // 2. *************ADD NEW STUDENT ******************
        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(StudentModel smodel)
        {
            try
            {
                StudentDbHandle sdb = new StudentDbHandle();
                if (ModelState.IsValid)
                {

                    if (sdb.AddStudent(smodel))
                    {
                        ViewBag.Message = "Student Details Added Successfully";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // 3. ************* EDIT STUDENT DETAILS ******************
        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            var sdb = new StudentDbHandle();
            var sm = new StudentModel();

            sm = sdb.GetStudentModels(id).SingleOrDefault();

            return View(sm);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StudentModel smodel)
        {
            try
            {
                StudentDbHandle sdb = new StudentDbHandle();
                if (ModelState.IsValid)
                {

                    if (sdb.UpdateStudent(smodel))
                    {
                        ViewBag.Message = "Student Details Added Successfully";
                        ModelState.Clear();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            StudentDbHandle sdb = new StudentDbHandle();
            if (ModelState.IsValid)
            {

                if (sdb.DeleteStudentRecords(id))
                {
                    ViewBag.Message = "Student Details Deleted Successfully";
                    ModelState.Clear();
                }
            }

            var dbHandle = new StudentDbHandle();
            return View("Index", dbHandle.GetStudentModels());
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
