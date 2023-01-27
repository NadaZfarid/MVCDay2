using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCDay2.Models;

namespace MVCDay2.Controllers
{
    public class WorkForController : Controller
    {
        CompanyDbContext DB;
        public WorkForController()
        {
                DB= new CompanyDbContext();
        }
        public IActionResult Hours(int id)
        {
            var Hours = DB.Emp_Projs.Include(p => p.Pemployee).Where(p => p.Pemployee.Dept_id == id).Select(d => new { d.Emp_SSN,d.Proj_Id, employeeName = d.Pemployee.Fname, projectName = d.project.Name, d.Hours }).ToList();
            return View("Hours", Hours);
        }
        public IActionResult Edit(int id, int secid)
        {
            var hours = DB.Emp_Projs.Where(p=>p.Emp_SSN==id&&p.Proj_Id==secid).Select(d => new { d.Emp_SSN, d.Proj_Id, employeeName = d.Pemployee.Fname, projectName = d.project.Name, d.Hours }).SingleOrDefault();
            return View("Edit",hours);
        }
        public IActionResult EditHours(Emp_Proj emp_Proj)
        {

            Emp_Proj oldWork = DB.Emp_Projs.SingleOrDefault(c => c.Emp_SSN == emp_Proj.Emp_SSN && c.Proj_Id == emp_Proj.Proj_Id);
            oldWork.Hours = emp_Proj.Hours;
            DB.SaveChanges();
            TempData["msg"] = "you updated Hours";
            int ssn = (int)HttpContext.Session.GetInt32("SSN");
            var dept = DB.Employees.Where(e => e.SSN == ssn).Select(e => e.Dept_id).SingleOrDefault();
            var Hours = DB.Emp_Projs.Where(p => p.Pemployee.Dept_id==dept).Select(d => new { d.Emp_SSN, d.Proj_Id, employeeName = d.Pemployee.Fname, projectName = d.project.Name, d.Hours }).ToList();
            return View("Hours", Hours);
        }
        public IActionResult Delete(int id, int secid)
        {
            Emp_Proj hours = DB.Emp_Projs.Where(p => p.Emp_SSN == id && p.Proj_Id == secid).SingleOrDefault();
            DB.Emp_Projs.Remove(hours);
            DB.SaveChanges();
            TempData["msg"] = "you Deleted a dependent";
            int ssn = (int)HttpContext.Session.GetInt32("SSN");
            var dept = DB.Employees.Where(e => e.SSN == ssn).Select(e => e.Dept_id).SingleOrDefault();
            var Hours = DB.Emp_Projs.Where(p => p.Pemployee.Dept_id == dept).Select(d => new { d.Emp_SSN, d.Proj_Id, employeeName = d.Pemployee.Fname, projectName = d.project.Name, d.Hours }).ToList();
            return View("Hours", Hours);
        }
    }
}
