using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCDay2.Models;

namespace MVCDay2.Controllers
{
    public class EmployeeController : Controller
    {
        CompanyDbContext DB = new CompanyDbContext();
        
        public ViewResult EmployeeList()
        {
            List<Employee> employees = DB.Employees.ToList();
            return View("EmployeeList",employees);
        }
        public IActionResult Add()
        {
            List<Employee> employees = DB.Employees.ToList();
            return View(employees);
        }
        public IActionResult AddEmployee(Employee employee)
        {
            DB.Employees.Add(employee);
            DB.SaveChanges();

            List<Employee> employees = DB.Employees.ToList();
            return View("EmployeeList", employees);
        }

        public IActionResult Edit(int id)
        {
            Employee employee = DB.Employees.SingleOrDefault(c => c.SSN == id);
            return View("Edit",employee);
        }
        public IActionResult EditEmployee(Employee employee)
        {
            Employee oldemployee = DB.Employees.SingleOrDefault(c => c.SSN == employee.SSN);
            oldemployee.Fname = employee.Fname;
            oldemployee.LName= employee.LName;
            oldemployee.Address= employee.Address;
            oldemployee.Salary= employee.Salary;
            oldemployee.Gender= employee.Gender;
            oldemployee.Super_SSN = employee.Super_SSN;
            DB.SaveChanges();

            List<Employee> employees = DB.Employees.ToList();
            return View("EmployeeList", employees);
        }
        public IActionResult Delete(int id)
        {
            Employee employee = DB.Employees.Where(c => c.SSN == id).SingleOrDefault();
            DB.Employees.Remove(employee);
            DB.SaveChanges();
            List<Employee> employees = DB.Employees.ToList();

            return View("EmployeeList",employees);
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult LoginEmployee(Employee employee)
        {
            var check= DB.Employees.Where(c=>c.Fname==employee.Fname && c.SSN==employee.SSN).Any();
            if (check)
            {
               
                    HttpContext.Session.SetInt32("SSN", employee.SSN);
                    return RedirectToAction("Profile");
                

            }
            else
            {
                return View("Login");

            }
        }
        public IActionResult Profile()
        {
            int id = (int)HttpContext.Session.GetInt32("SSN");
                var employee = DB.Employees.Include(e=>e.department).Where(c => c.SSN == id).Select(e => new {e.SSN,e.Fname,e.LName,e.BDate,e.Gender,manager=e.department.Manage_SSN,e.Address,e.Salary,Super=e.super.Fname}).SingleOrDefault();
                return View("Profile", employee);
            
        }
        public ViewResult Manager()
        {
            return View();
        }
    }
}
