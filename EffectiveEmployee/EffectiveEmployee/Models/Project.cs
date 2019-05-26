namespace EffectiveEmployee.Models
{
    public class Project
    {
        public int Id { get; set; }
        
        public int EmployeeId { get; set; }
        
        public string Name { get; set; }
        
        public int Premium { get; set; }
        
        public virtual Employee Employee { get; set; }
    }
}