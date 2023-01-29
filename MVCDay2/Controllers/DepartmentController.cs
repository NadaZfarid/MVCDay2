using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCDay2.Models;

namespace MVCDay2.Controllers
{
    public class DepartmentController : Controller
    {
        CompanyDbContext DB;
        public DepartmentController()
        {
            DB= new CompanyDbContext();
        }
        public IActionResult Departments()
        {
            var departments = DB.Departments.Select(d=> new {d.Name,d.Number,manager = d.employee.Fname,d.StartDate}).ToList();
            return View("Departments",departments);
        }
        public IActionResult Edit(int id)
        {
            Department department = DB.Departments.Where(d=>d.Number==id).SingleOrDefault();
            List<Employee> employees = DB.Employees.Where(e=>e.Dept_id==id).ToList();
            ViewBag.Employees = new SelectList(employees, "SSN", "Fname");
            return View("Edit",department);
        }
        public IActionResult EditDepartment(Department department)
        {
            Department oldDepartment = DB.Departments.Where(d => d.Number == department.Number).SingleOrDefault();
            oldDepartment.Name = department.Name;
            oldDepartment.StartDate = department.StartDate;
            DB.SaveChanges();
            var departments = DB.Departments.Select(d => new { d.Name, d.Number, manager = d.employee.Fname, d.StartDate }).ToList();
            return View("Departments", departments);
        }
        public IActionResult Delete(int id)
        {
            Department department =DB.Departments.Where(d=>d.Number==id).SingleOrDefault();
            DB.Departments.Remove(department);
            DB.SaveChanges();
            var departments = DB.Departments.Select(d => new { d.Name, d.Number, manager = d.employee.Fname, d.StartDate }).ToList();
            return View("Departments", departments);
        }
        public IActionResult Add()
        {
            List<Employee> employees = DB.Employees.ToList();
            ViewBag.Employees = new SelectList(employees,"SSN","Fname");
            return View();
        }
        public IActionResult AddDepartment(Department department)
        {
            DB.Departments.Add(department);
            DB.SaveChanges();
            Employee employee = DB.Employees.Where(e=>e.SSN==department.Manage_SSN).SingleOrDefault();
            employee.Dept_id = department.Number;
            DB.SaveChanges();
            var departments = DB.Departments.Select(d => new { d.Name, d.Number, manager = d.employee.Fname, d.StartDate }).ToList();
            return RedirectToAction("Departments", departments);
        }
    }
}
