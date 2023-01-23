using Microsoft.AspNetCore.Mvc;
using MVCDay2.Models;

namespace MVCDay2.Controllers
{
    public class DependentController : Controller
    {
        CompanyDbContext DB = new CompanyDbContext();
        public IActionResult Dependent()
        {
            int id =(int) HttpContext.Session.GetInt32("SSN");
            var dependent= DB.Dependents.Where(d=>d.Emp_SSN== id).ToList();
            return View("Dependent",dependent);
        }
        public IActionResult Add()
        {
            //int id = (int)HttpContext.Session.GetInt32("SSN");

            List<Dependent> dependents = DB.Dependents.ToList();
            return View(dependents);
        }
        public IActionResult AddDependent(Dependent dependent)
        {
            int id = (int)HttpContext.Session.GetInt32("SSN");

            DB.Dependents.Add(dependent);
            DB.SaveChanges();
            TempData["msg"] = "you added a dependent";

            List<Dependent> dependents = DB.Dependents.Where(d => d.Emp_SSN == id).ToList();
            return View("Dependent", dependents);
        }
        public IActionResult Edit(int id)
        {

            Dependent dependent = DB.Dependents.SingleOrDefault(c => c.DepId == id);
            return View("Edit", dependent);
        }
        public IActionResult EditDependent(Dependent dependent)
        {
            Dependent oldDependent = DB.Dependents.SingleOrDefault(c => c.DepId==dependent.DepId);
            oldDependent.Name = dependent.Name;
            oldDependent.BDate=(DateTime)dependent.BDate;
            oldDependent.Gender = dependent.Gender;
            oldDependent.Relationship = dependent.Relationship;
            DB.SaveChanges();
            TempData["msg"] = "you updated dependent";
            List<Dependent> dependents = DB.Dependents.Where(d => d.Emp_SSN == dependent.Emp_SSN).ToList();
            return View("Dependent", dependents);
        }
        public IActionResult Delete(int id)
        {

            Dependent dependent = DB.Dependents.Where(c => c.DepId==id).SingleOrDefault();
            DB.Dependents.Remove(dependent);
            DB.SaveChanges();
            TempData["msg"] = "you Deleted a dependent";
            List<Dependent> dependents = DB.Dependents.Where(d => d.Emp_SSN == id).ToList();
            return View("Dependent", dependents);
        }
    }
}
