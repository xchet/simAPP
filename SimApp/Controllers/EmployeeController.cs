using SimApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimApp.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            return View(GetAllEmployee());
        }

        IEnumerable<Employee> GetAllEmployee()
        {
            using (SimAppEntities db = new SimAppEntities())
            {
                return db.Employees.ToList<Employee>();
            }
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            Employee emp = new Employee();
            if (id != 0)
            {
                using (SimAppEntities db = new SimAppEntities())
                {
                    emp = db.Employees.Where(x => x.EmployeeID == id).FirstOrDefault<Employee>();
                }
            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult AddOrEdit(Employee employee)
        {
            try
            {
                if (employee.imageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(employee.imageFile.FileName);
                    string extension = Path.GetExtension(employee.imageFile.FileName);
                    fileName = "SimApp" + DateTime.Now.ToString("yymmssfff") + extension;
                    employee.EmployeeImage = "~/Docs/Images/" + fileName;
                    employee.imageFile.SaveAs(Path.Combine(Server.MapPath("~/Docs/Images/"), fileName));
                }
                using (SimAppEntities db = new SimAppEntities())
                {
                    if (employee.EmployeeID == 0)
                    {
                        db.Employees.Add(employee);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(employee).State = EntityState.Modified;
                        db.SaveChanges();

                    }
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllEmployee()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (SimAppEntities db = new SimAppEntities())
                {
                    Employee emp = db.Employees.Where(x => x.EmployeeID == id).FirstOrDefault<Employee>();
                    db.Employees.Remove(emp);
                    db.SaveChanges();
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllEmployee()), message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}