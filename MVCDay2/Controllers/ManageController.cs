using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCDay2.Models;

namespace MVCDay2.Controllers
{
    public class ManageController : Controller
    {
        CompanyDbContext DB = new CompanyDbContext();
        public IActionResult DepartmentDetails()
        {
            int id = (int)HttpContext.Session.GetInt32("SSN");
            var department = DB.Departments.Where(d=>d.Manage_SSN==id).Select(d=> new {d.Number,d.Name,ManagerName=d.employee.Fname,d.StartDate,projects=d.Projects}).SingleOrDefault();
            var employee = DB.Employees.Where(d=>d.Dept_id==department.Number).ToList();
            ViewBag.Employees = employee;
            return View("DepartmentDetails",department);
        }
        public IActionResult Projects(int id)
        {
           var projects = DB.Departments.Where(p => p.Number == id).Select(d => new { projects = d.Projects }).SingleOrDefault();
            return View("Projects", projects);
        }
        [HttpGet]
        public IActionResult AddEmpProj(int id)
        {
            var projects = DB.Departments.Where(p => p.Number == id ).Select(d => new { projects = d.Projects }).SingleOrDefault();
            var employee = DB.Employees.Where(d => d.Dept_id == id).ToList();
            ViewBag.Employees = employee;
            return View("AddEmpProj",projects);
        }
        [HttpPost]
        public IActionResult Add(Emp_Proj emp_Proj, int[]Pnum)
        {
            foreach(var item in Pnum)
            {
                Emp_Proj emp = new Emp_Proj()
                {
                    Emp_SSN = emp_Proj.Emp_SSN,
                    Proj_Id = item
                };
                DB.Emp_Projs.Add(emp);
                DB.SaveChanges();

            }
            int id = (int)HttpContext.Session.GetInt32("SSN");
            var department = DB.Departments.Where(d => d.Manage_SSN == id).Select(d => new { d.Number, d.Name, ManagerName = d.employee.Fname, d.StartDate }).SingleOrDefault();
            return RedirectToAction("DepartmentDetails", department);
        }
        

    }
}
