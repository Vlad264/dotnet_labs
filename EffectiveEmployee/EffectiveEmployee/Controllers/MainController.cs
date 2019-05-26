using System.Linq;
using EffectiveEmployee.Models;
using Microsoft.AspNetCore.Mvc;

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
            }
            else
            {
                emp = new Employee();
            }

            return View(emp);
        }

        [Route(("Project"))]
        public IActionResult Project(int id)
        {
            Project project;
            if (id > 0)
            {
                project = context.Projects.Find(id);
            }
            else
            {
                project = new Project();
            }

            return View(project);
        }
    }
}