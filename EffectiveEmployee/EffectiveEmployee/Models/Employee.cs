using System.Collections.Generic;

namespace EffectiveEmployee.Models
{
    public class Employee
    {
        public Employee()
        {
            Projects = new HashSet<Project>();
        }
        
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Surname { get; set; }
        
        public string Patronymic { get; set; }
        
        public string City { get; set; }
        
        public virtual ICollection<Project> Projects { get; set; }
    }
}