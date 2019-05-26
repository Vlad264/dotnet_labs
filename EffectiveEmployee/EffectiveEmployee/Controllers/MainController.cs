using System.Linq;
using EffectiveEmployee.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EffectiveEmployee.Controllers
{
    [Route("/")]
    public class MainController : Controller
    {
        private readonly DataContext context;

        public MainController(DataContext context)
        {
            this.context = context;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View(context.Employees.ToList());
        }

        [Route("Employee")]
        public IActionResult Employee(int id)
        {
            Employee emp;
            if (id > 0)
            {
                emp = context.Employees.Find(id);
                ViewBag.controller = "UpdateEmployee";
            }
            else
            {
                emp = new Employee();
                ViewBag.controller = "SaveEmployee";
            }

            return View(emp);
        }

        [Route(("Project"))]
        public IActionResult Project(int id)
        {
            var employeesDesc = context.Employees.ToList().Select(s => new
            {
                s.Id,
                Description = $" {s.Surname} {s.Name} {s.Patronymic}"
            });
            ViewBag.Employees = new SelectList(employeesDesc, "Id", "Description",0);
            
            Project project;
            if (id > 0)
            {
                project = context.Projects.Find(id);
                ViewBag.controller = "UpdateProject";
            }
            else
            {
                project = new Project();
                ViewBag.controller = "SaveProject";
            }

            return View(project);
        }
        
        [Route("Projects")]
        public IActionResult Projects(int id)
        {
            var emp = context.Employees.Find(id);
            ViewBag.EmployeeInfo = $"{emp.Surname} {emp.Name} {emp.Patronymic}";
            var projects = emp.Projects.ToList();
            return View(projects);
        }
        
        [Route("RemoveEmployee")]
        public IActionResult RemoveEmployee(int id)
        {
            context.Employees.Remove(context.Employees.Find(id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [Route("RemoveProject")]
        public IActionResult RemoveProject(int id)
        {
            var project = context.Projects.Find(id);
            context.Projects.Remove(project);
            context.SaveChanges();
            return RedirectToAction("Projects", "Main", new {id = project.EmployeeId});
        }

        [Route("UpdateEmployee")]
        public IActionResult UpdateEmployee(Employee emp)
        {
            if (ModelState.IsValid)
            {
                context.Employees.Update(emp);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Employee", "Main", new {id = emp.Id});
        }

        [Route("UpdateProject")]
        public IActionResult UpdateProject(Project project)
        {
            if (ModelState.IsValid)
            {
                context.Projects.Update(project);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Project", "Main", new {id = project.Id});
        }

        [Route("Premium")]
        public IActionResult Premium()
        {
            var res = context.Projects
                .GroupBy(project => project.Employee)
                .Select(p => new Premium {Name = $"{p.Key.Name} {p.Key.Surname} {p.Key.Patronymic}", Value = p.Sum(project => project.Premium)})
                .OrderByDescending(p => p.Value)
                .ToList();
            return View(res);
        }
        
    }
}