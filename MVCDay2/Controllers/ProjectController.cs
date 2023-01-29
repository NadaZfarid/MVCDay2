using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCDay2.Models;

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
        public IActionResult Add()
        {
            var department = DB.Departments.Select(p => new { p.Number, p.Name }).ToList();
            ViewBag.Departments = new SelectList(department, "Number", "Name");
            return View();
        }
        public IActionResult AddProject(Project project)
        {
            DB.Projects.Add(project);
            DB.SaveChanges();

            var projects = DB.Projects.Select(p => new { p.Number, p.Name, p.Location, DepartmentName = p.department.Name }).ToList();
            return View("ProjectList", projects);
        }
    }
}
