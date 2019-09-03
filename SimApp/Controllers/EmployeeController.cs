using SimApp.Models;
using System;
using System.Collections.Generic;
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
            Employee employee = new Employee();
            return View(employee);
        }

        [HttpPost]
        public ActionResult AddOrEdit()
        {
            return View();
        }
    }
}