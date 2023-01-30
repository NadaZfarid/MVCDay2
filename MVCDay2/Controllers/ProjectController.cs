using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCDay2.Models;
using MVCDay2.ViewModels;

namespace MVCDay2.Controllers
{
    public class ProjectController : Controller
    {
        CompanyDbContext DB;
        public ProjectController()
        {
            DB= new CompanyDbContext();
        }
        public IActionResult ProjectList()
        {
            var projects = DB.Projects.Select(p => new {p.Number,p.Name,p.Location,DepartmentName=p.department.Name}).ToList();
            return View("ProjectList", projects);
        }
        public IActionResult Edit(int id)
        {
            Project project = DB.Projects.Where(d => d.Number == id).SingleOrDefault();
            var department = DB.Departments.Select(p => new {p.Number,p.Name}).ToList();
            ViewBag.Departments = new SelectList(department, "Number", "Name");
            return View("Edit", project);
        }
        public IActionResult EditProject(Project project)
        {
            Project oldProject = DB.Projects.Where(d => d.Number == project.Number).SingleOrDefault();
            oldProject.Name = project.Name;
            oldProject.Location= project.Location;
            oldProject.Dept_id= project.Dept_id;
            DB.SaveChanges();
            var projects = DB.Projects.Select(p => new { p.Number, p.Name, p.Location, DepartmentName = p.department.Name }).ToList();
            return View("ProjectList", projects);
        }
        public IActionResult Delete(int id)
        {
            Project project = DB.Projects.Where(d => d.Number == id).SingleOrDefault();
            DB.Projects.Remove(project);
            DB.SaveChanges();
            var projects = DB.Projects.Select(p => new { p.Number, p.Name, p.Location, DepartmentName = p.department.Name }).ToList();
            return View("ProjectList", projects);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var department = DB.Departments.Select(p => new { p.Number, p.Name }).ToList();
            ViewBag.Departments = new SelectList(department, "Number", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Add(ProjectVM project)
        {
            if (ModelState.GetFieldValidationState("Name") == ModelValidationState.Valid
                && ModelState.GetFieldValidationState("Location") == ModelValidationState.Valid
                && !(project.Location.Contains("Cairo") || project.Location.Contains("Alex") || project.Location.Contains("Giza")))
            {
                ModelState.AddModelError("Location", "Location Must be in Cairo, Alex or Giza.");
            }
            if (ModelState.IsValid)
            {
                Project newProject = new Project()
                {
                    Name = project.Name,
                    Location = project.Location,
                    Dept_id= project.Dept_id,
                };
                DB.Projects.Add(newProject);
                DB.SaveChanges();
                var projec = DB.Projects.Select(p => new { p.Number, p.Name, p.Location, DepartmentName = p.department.Name }).ToList();
                return View("ProjectList", projec);
            }
            var department = DB.Departments.Select(p => new { p.Number, p.Name }).ToList();
            ViewBag.Departments = new SelectList(department, "Number", "Name");
            return View();

        }
        //public IActionResult validateLocation(string Location)
        //{
        //    if (Location.Contains("Cairo")||Location.Contains("Alex")|| Location.Contains("Giza"))
        //    {
              
        //        return Json(true);
        //    }
        //    return Json(false);
        //}

        public IActionResult EditEmpProj()
        {
            var employees = DB.Employees.Select(e => new {e.SSN,FullName=e.Fname+" "+e.LName}).ToList();
            ViewBag.Employees = new SelectList(employees,"SSN","FullName");
            return View();
        }
        public IActionResult EditEmpProj_emp(int id)
        {
            var project = DB.Emp_Projs.Where(e => e.Emp_SSN == id).Select(e => new { e.Proj_Id, Name = e.project.Name }).ToList();
            ViewBag.projects = new SelectList(project, "Proj_Id", "Name");
            return PartialView("_ProjectList");
        }
    }
}

